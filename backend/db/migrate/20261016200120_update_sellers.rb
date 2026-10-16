class UpdateSellers < ActiveRecord::Migration[8.1]
  def change
    change_column :sellers, :approval_status, :integer, default: 0, null: false
    add_reference :sellers, :reviewer_id, foreign_key: { to_table: :users}, null: true
  end
end
