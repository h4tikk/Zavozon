class CreateSellers < ActiveRecord::Migration[8.1]
  def change
    create_table :sellers do |t|
      t.string :store_name
      t.text :descriprion
      t.references :user, null: false, foreign_key: true
      t.datetime :paid_until
      t.integer :approval_status
      t.datetime :reviewed_at
      t.text :rejection_reason

      t.timestamps
    end
  end
end
