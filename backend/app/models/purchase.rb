class Purchase < ApplicationRecord
  enum purchase_status, {
    awaiting_payment:0,
    payment_review: 1,
    paid: 2,
    processing: 3,
    ready_for_pick_up: 4,
    completed: 5,
    expired: 6,
    canceled: 7,
    disputed: 8
  }, validate: true

  validates :products_amount, :delivery_amount, :total_amount, numericality: { only_integer: true, greater_than: 0 }

  has_many :orders
  has_many :payment_claims

  belongs_to :user
  belongs_to :pick_up_point
end
