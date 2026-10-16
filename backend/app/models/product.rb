class Product < ApplicationRecord
  validates :name, presence: true
  validates :price, :stock, numericality: { only_integer: true, greater_than: 0 }

  has_many :order_items, dependent: :destroy
  has_many :cart_items, dependent: :destroy

  belongs_to :seller
  has_one_attached :image
end
