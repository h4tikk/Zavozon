class CreatePurchases < ActiveRecord::Migration[8.1]
  def change
    create_table :purchases do |t|
      t.references :user, null: false, foreign_key: true
      t.references :pick_up_point, null: false, foreign_key: true
      t.integer :product_amount
      t.integer :delivery_amount
      t.integer :total_amount
      t.integer :purchase_status
      t.datetime :payment_expire_at
      t.references :payment_claim, null: false, foreign_key: true

      t.timestamps
    end
  end
end
