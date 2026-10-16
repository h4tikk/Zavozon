class CreateApiSessions < ActiveRecord::Migration[8.1]
  def change
    create_table :api_sessions do |t|
      t.references :user, null: false, foreign_key: true
      t.string :token_digest
      t.datetime :expires_at
      t.datetime :revoked_at

      t.timestamps
    end
  end
end
