class UpdatePickUpPoints < ActiveRecord::Migration[8.1]
  def change
    change_column_null :pick_up_points, :reviewer_id, true
    change_column :pick_up_points, :pick_up_point_status, :integer, null: false, default: 0
  end
end
