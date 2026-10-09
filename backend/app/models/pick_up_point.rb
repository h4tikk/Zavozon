class PickUpPoint < ApplicationRecord
  enum pick_up_point_status: [ :pending_review, :active, :rejected, :suspended, :closed ]

  validates :name, presence: true
  validates :x, :y, :z, numerical: { greater_than: 0 }

  has_many :purchases, dependent: :destroy

  belongs_to :owner, class_name: "User", optional: false
  belongs_to :reviewer, class_name: "User", optional: true
end
