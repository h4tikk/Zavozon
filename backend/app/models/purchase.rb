class Purchase < ApplicationRecord
  enum purchace_status: [ :awaiting_payment, :payment_review, :paid, :processing, :ready_for_pick_up, :completed, :expired, :cancelled, :disputed ]

  validates :products_amount, :delivery_amount, :total_amount, numericality: { greater_than: 0 }

  has_many :orders, dependent: :destroy

  belongs_to :user
  belongs_to :pick_up_point
  belongs_to :payment_claim
end
