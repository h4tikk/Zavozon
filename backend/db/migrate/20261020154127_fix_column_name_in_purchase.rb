class FixColumnNameInPurchase < ActiveRecord::Migration[8.1]
  def change
    rename_column :purchases, :product_amount, :products_amount
  end
end
