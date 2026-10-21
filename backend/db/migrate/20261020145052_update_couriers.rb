class UpdateCouriers < ActiveRecord::Migration[8.1]
  def change
    add_column :couriers, :approval_status, :integer, default: 0, null: false
    add_column :couriers, :reviewed_at, :datetime, null: true
    add_reference :couriers, :reviewer, foreign_key: { to_table: :users}, null: true
  end
end
