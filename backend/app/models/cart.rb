class Cart < ApplicationRecord
  validates :is_available, inclusion: [ true, false ]

  has_one :user, dependent: :destroy
  has_many :cart_items, dependent: :destroy
end
