class AddRejectionReasonToCouriers < ActiveRecord::Migration[8.1]
  def change
    add_column :couriers, :rejection_reason, :text, null: true
  end
end
