class UpdateUsers < ActiveRecord::Migration[8.1]
  def change
    add_column :users, :admin, :boolean, default: false, null: false
    add_column :users, :blocked_at, :datetime, default: nil
    add_column :users, :can_review_sellers, :boolean, default: false, null: false
    add_column :users, :can_review_couriers, :boolean, default: false, null: false
    add_column :users, :can_review_pick_up_points, :boolean, default: false, null: false
    add_column :users, :can_review_payments, :boolean, default: false, null: false
    add_index :users, :telegram_user_id, unique: true
  end
end
