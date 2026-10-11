class User < ApplicationRecord
  validates :minecraft_nickname, presence: true

  has_one :courier, dependent: :destroy
  has_one :seller, dependent: :destroy

  has_many :reviewed_sellers, class_name: "Seller", foreign_key: :reviewer_id
  has_many :reviewed_pick_up_points, class_name: "PickUpPoint", foreign_key: :reviewer_id
  has_many :pick_up_points, foreign_key: :owner_id
  has_many :reviewed_payment_claims, class_name: "PaymentClaim", foreign_key: :reviewer_id

  has_one_attached :avatar
end
