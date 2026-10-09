class CreateCouriers < ActiveRecord::Migration[8.1]
  def change
    create_table :couriers do |t|
      t.references :user, null: false, foreign_key: true
      t.boolean :is_available

      t.timestamps
    end
  end
end
