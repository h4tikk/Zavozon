class FixUser < ActiveRecord::Migration[8.1]
  def change
    change_column_null :users, :telegram_user_id, false

    add_column :users, :can_review_withdrawals, :boolean,
      null: false, default: false

    add_column :users, :telegram_private_chat_id, :bigint

    add_column :users, :bot_blocked_at, :datetime

    add_column :users, :minecraft_verified_at, :datetime

    add_index :users,
      "lower(minecraft_nickname)",
      unique: true,
      where: "minecraft_verified_at IS NOT NULL",
      name: "index_users_on_verified_minecraft_nickname"

    add_check_constraint :users,
      "telegram_user_id > 0",
      name: "users_positive_telegram_id"

    add_check_constraint :users,
      <<~SQL.squish,
        minecraft_verified_at IS NULL OR (
          minecraft_nickname IS NOT NULL AND
          length(btrim(minecraft_nickname)) > 0
        )
      SQL
      name: "users_verified_nickname_present"
  end
end
