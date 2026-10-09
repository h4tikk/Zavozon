class CreateProducts < ActiveRecord::Migration[8.1]
  def change
    create_table :products do |t|
      t.string :name
      t.text :description
      t.integer :price
      t.integer :stock
      t.boolean :is_active
      t.references :seller, null: false, foreign_key: true

      t.timestamps
    end
  end
end
