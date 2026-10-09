class AddPurposeToPaymentClaims < ActiveRecord::Migration[8.1]
  def change
    add_column :payment_claims, :purpose, :integer
  end
end
