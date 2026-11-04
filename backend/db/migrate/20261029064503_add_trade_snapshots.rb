class AddTradeSnapshots < ActiveRecord::Migration[8.1]
  def change
    add_column :purchases, :checkout_key, :string
    add_column :purchases, :checkout_fingerprint, :string

    add_index :purchases, %i[user_id checkout_key], unique: true

    add_column :purchases, :delivery_snapshot, :jsonb, null: false, default: {}

    add_column :orders, :pickup_snapshot, :jsonb, null: false, default: {}

    add_column :orders, :delivery_snapshot, :jsonb, null: false, default: {}

    add_column :orders, :pricing_version, :string
    add_column :orders, :settled_at, :datetime

    add_reference :orders, :seller_user, foreign_key: { to_table: :users }

    add_reference :orders, :courier_user, foreign_key: { to_table: :users }

    add_reference :orders, :pick_up_point_owner, foreign_key: { to_table: :users }

    add column :payment_claims, :verified_transfer_reference, :string
    add_index :payment_claims,
      :verified_transfer_reference,
      unique: true,
      where: "verified_transfer_reference IS NOT NULL",
      name: "index_payment_claims_on_transfer_reference"

    %i[sellers couriers pick_up_points payment_claims].each do |table|
      add_column table, :lock_version,
        :integer, null: false, default: 0
    end
  end
end
