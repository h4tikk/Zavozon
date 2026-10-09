class CartItem < ApplicationRecord
  validates :quantity, numricality: { greater_than: 0 }

  belongs_to :cart
  belongs_to :product
end
