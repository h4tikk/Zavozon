class User < ApplicationRecord
  validates :telegram_user_id, presence: true, numericality: { only_integer: true, greater_than: 0 }

  has_one :courier
  has_one :seller

  has_one :cart
  has_many :purchases
  has_many :payment_claims

  has_many :api_sessions, dependent: :destroy
  has_many :minecraft_link_requests

  has_many :pick_up_points, foreign_key: :owner_id

  has_many :reviewed_sellers,
           class_name: "Seller",
           foreign_key: :reviewer_id

  has_many :reviewed_couriers,
           class_name: "Courier",
           foreign_key: :reviewer_id

  has_many :reviewed_pick_up_points,
           class_name: "PickUpPoint",
           foreign_key: :reviewer_id

  has_many :reviewed_payment_claims,
           class_name: "PaymentClaim",
           foreign_key: :reviewer_id

  has_one_attached :avatar

  def blocked?
    blocked_at.present?
  end

  def seller?
    seller.present?
  end

  def courier?
    courier.present?
  end

  def may_review_sellers?
    !blocked? && (admin? || can_review_sellers?)
  end

  def may_review_couriers?
    !blocked? && (admin? || can_review_couriers?)
  end

  def may_review_pick_up_points?
    !blocked? && (admin? || can_review_pick_up_points?)
  end

  def may_review_payments?
    !blocked? && (admin? || can_review_payments?)
  end
end
