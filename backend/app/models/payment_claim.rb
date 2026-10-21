class PaymentClaim < ApplicationRecord
  enum :purpose, {
    purchase:0,
    seller_access:1
  }, prefix: true, validate: true

  enum payment_claim_status, {
    awaiting_transfer: 0,
    pending_review: 1,
    approved: 2,
    rejected: 3,
    expired: 4,
    canceled: 5
  }, validate: true

  validates :player_nickname, :receiver_nickname, presence: true
  validates :expected_amount, numericality: { only_integer: true, greater_than: 0 }
  validates :claimed_amount, numericality: { only_integer: true, greater_than: 0 }, allow_nil: true
  validates :claimed_amount, presence: true, if: -> { pending_review? || approved? }
  validates :rejection_reason, presence: true, if: :rejected?
  validate :validate_payment_target

  belongs_to :user
  belongs_to :purchase, optional: true
  belongs_to :seller, optional: true
  belongs_to :reviewer, class_name: "User", optional: true

  has_one_attached :screenshot

  private

  def validate_payment_target
    if purpose_purchase?
      errors.add(:purchase, "обязательна") unless purchase

      if purchase && purchase.user_id != user_id
        errors.add(:purchase, "принадлежит другому пользователю")
      end

      errors.add(:seller, "не должен быть указан") if seller_id.present?
    elsif purpose_seller_access?
      errors.add(:seller, "обязателен") unless seller

      if seller && seller.user_id != user_id
        errors.add(:seller, "принадлежит другому пользователю")
      end

      errors.add(:purchase, "не должна быть указана") if purchase_id.present?
    end
  end
end
