class CreatePickUpPoints < ActiveRecord::Migration[8.1]
  def change
    create_table :pick_up_points do |t|
      t.string :name
      t.text :description
      t.integer :x
      t.integer :y
      t.integer :z
      t.integer :pick_up_point_status
      t.references :owner, null: false, foreign_key: { to_table: :users }
      t.references :reviewer, null: false, foreign_key: { to_table: :users }
      t.datetime :reviewed_at
      t.text :rejection_reason
      t.text :suspension_reason

      t.timestamps
    end
  end
end
