class CreatePaymentClaims < ActiveRecord::Migration[8.1]
  def change
    create_table :payment_claims do |t|
      t.references :user, null: false, foreign_key: true
      t.references :purchase, null: false, foreign_key: true
      t.references :seller, null: false, foreign_key: true
      t.integer :expected_amount
      t.integer :claimed_amount
      t.string :player_nickname
      t.string :receiver_nickname
      t.integer :payment_claim_status
      t.references :reviewer, null: false, foreign_key: { to_table: :users }
      t.datetime :reviewed_at
      t.text :rejection_reason

      t.timestamps
    end
  end
end
