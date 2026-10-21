class Seller < ApplicationRecord
  enum :approval_status, {
    pending_review: 0,
    approved: 1,
    rejected: 2,
    suspended: 3
  }, validate: true

  validates :store_name, presence: true
  validates :refection_reason, presence: true, if: :rejected?

  has_many :orders
  has_many :products
  has_many :payment_claims

  belongs_to :user
  belongs_to :reviewer, class_name: "User", optional: true

  def can_trade?
    !user.blocked &&
      approved &&
      paid_until.present? &&
      paid_until > Time.current
  end
end
