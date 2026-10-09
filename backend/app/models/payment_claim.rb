class PaymentClaim < ApplicationRecord
  enum purpose: [ :purchase, :seller_access ]
  enum payment_claim_status: [ :awaiting_transfer, :pending_review, :approved, :rejected, :expired, :cancelled ]
  validates :player_nickname, :receiver_nickname, presence: true
  validates :expected_amount, :claimed_amount, numericality: { greater_than: 0 }

  has_one :purchase, dependent: :destroy

  belongs_to :user
  belongs_to :seller
  belongs_to :reviewer, class_name: "User", optional: true
  has_one_attached :screenshot
end
