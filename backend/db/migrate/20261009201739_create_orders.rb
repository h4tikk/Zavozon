class CreateOrders < ActiveRecord::Migration[8.1]
  def change
    create_table :orders do |t|
      t.references :purchase, null: false, foreign_key: true
      t.references :seller, null: false, foreign_key: true
      t.references :courier, null: false, foreign_key: true
      t.integer :products_amount
      t.integer :seller_reward
      t.integer :courier_reward
      t.integer :pick_up_point_reward
      t.integer :platform_commission
      t.integer :order_status
      t.datetime :courier_accepted_at
      t.datetime :delivered_by_courier_at
      t.datetime :received_by_user_at

      t.timestamps
    end
  end
end
