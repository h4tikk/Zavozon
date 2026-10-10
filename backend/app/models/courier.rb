class Courier < ApplicationRecord
  vallidates :is_available, inclusion: [ true, false ]
  belongs_to :user
  has_many :orders, dependent: :set_null
end
