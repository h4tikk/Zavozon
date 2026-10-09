class CreateUsers < ActiveRecord::Migration[8.1]
  def change
    create_table :users do |t|
      t.string :minecraft_nickname
      t.string :telegram_username
      t.integer :telegram_user_id

      t.timestamps
    end
  end
end
