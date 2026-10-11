class Seller < ApplicationRecord
  enum seller_approval_status: [ :pending_review, :approved, :rejected, :cancelled ]

  validates :store_name, presence: true

  has_many :orders, dependent: :destroy
  has_many :products, dependent: :destroy
  has_many :payment_claims, dependent: :destroy

  belongs_to :user
  belongs_to :reviewer, class_name: "User", optional: true
end
