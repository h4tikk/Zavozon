class PickUpPoint < ApplicationRecord
  enum pick_up_point_status, {
    pending_review: 0,
    active: 1,
    rejected: 2,
    suspended: 3,
    closed: 4
  }, validate: true

  validates :name, presence: true
  validates :x, :y, :z, numericality: { only_integer: true }
  validates :rejection_reason, presence: true, if: :rejected

  has_many :purchases

  belongs_to :owner, class_name: "User"
  belongs_to :reviewer, class_name: "User", optional: true
end
