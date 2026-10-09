class OrderItem < ApplicationRecord
  validate :product_title, presence: true
  validates :unit_price, :quantity, :total_price, numericality: { greater_than: 0 }
  belongs_to :order
  belongs_to :product
end
