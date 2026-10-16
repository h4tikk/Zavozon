class ChangeTelegramUserIdTypeInUsers < ActiveRecord::Migration[8.1]
  def change
    change_column :users, :telegram_user_id, :bigint
  end
end
