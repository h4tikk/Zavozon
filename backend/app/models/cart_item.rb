class CartItem < ApplicationRecord
  validates :quantity, numericality: { only_integer: true, greater_than: 0 }

  belongs_to :cart
  belongs_to :product
end
