class HardenExistingModels < ActiveRecord::Migration[8.1]
  MONEY_COLUMNS = {
    products: %i[price],
    order_items: %i[unit_price total_price],
    purchases: %i[products_amount delivery_amount total_amount],
    orders: %i[
      products_amount
      seller_reward
      courier_reward
      pick_up_point_reward
      platform_commission
    ],
    payment_claims: %i[expected_amount claimed_amount]
    }.freeze

  def change
    reversible do |direction|
      direction.up do
        MONEY_COLUMNS.each do |table, columns|
          columns.each do |column|
            change_column table, column, :bigint
          end
        end
      end

      direction.down do
        MONEY_COLUMNS.each do |table, columns|
          columns.each do |column|
            change table, column, :integer
          end
        end
      end
    end

    change_column_null :api_sessions, :token_digest, false
    change_column_null :api_sessions, :expires_at, false

    add_index :api_sessions, :token_digest, unique: true
    add_index :api_sessions, :expires_at

    %i[sellers couriers carts].each do |table|
      remove_index table, :user_id
      add_index table, :user_id, unique: true
    end

    add_index :cart_items, %i[cart_id product_id], unique: true

    change_column_null :couriers, :is_available, false

    change_column_default :products, :is_active, from: nil, to: false

    reversible do |direction|
      direction.up do
        execute <<~SQL
          UPDATE products
          SET is_active = FALSE
          WHERE is_active IS NULL
        SQL
      end
    end

    change_column_null :products, :is_active, false
    change_column_null :products, :price, false
    change_column_null :products, :stock, false

    change_column_null :cart_items, :quantity, false

    change_column_null :orders, :courier_id, true

    {
      purchases: :purchase_status,
      orders: :order_status,
      payment_claims: :payment_claim_status
    }.each do |table, column|
      change_column_default table, column, from: nil, to: 0
      change_column_null table, column, false
    end

    change_column_null :payment_claims, :purpose, false

    add_check_constraint :products,
      "price > 0 AND stock >= 0",
      name: "products_valid_price_and_stock"

    add_check_constraint :cart_items,
      "quantity > 0",
      name: "cart_items_positive_quantity"

    add_check_constraint :order_items,
      "unit_price > 0 AND quantity > 0 AND " \
      "total_price = unit_price * quantity",
      name: "order_items_valid_totals"

    add_check_constraint :payment_claims,
      <<~SQL.squish,
        (
          purpose = 0 AND
          purchase_id IS NOT NULL AND
          seller_id IS NULL
        ) OR (
          purpose = 1 AND
          seller_id IS NOT NULL AND
          purchase_id IS NULL
        )
      SQL
      name: "payment_claims_valid_target"
  end
end
