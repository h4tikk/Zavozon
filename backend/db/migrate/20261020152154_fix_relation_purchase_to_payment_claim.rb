class FixRelationPurchaseToPaymentClaim < ActiveRecord::Migration[8.1]
  def change
    change_column_null :payment_claims, :purchase_id, true
    change_column_null :payment_claims, :seller_id, true
    change_column_null :payment_claims, :reviewer_id, true
  end
end
