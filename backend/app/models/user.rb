class User < ApplicationRecord
  has_one :courier
  has_one :seller
  has_many :reviewed_sellers, class_name: "Seller", foreign_key: :reviewer_id
  has_many :reviewed_pick_up_points, class_name: "PickUpPoint", foreign_key: :reviewer_id
  has_many :reviewed_payment_claims, class_name: "PaymentClaim", foreign_key: :reviewer_id
  has_one_attached :avatar
end
