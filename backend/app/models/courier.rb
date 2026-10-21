class Courier < ApplicationRecord
  enum :approval_status, {
    pending_review: 0,
    approved: 1,
    rejected: 2,
    suspended: 3
  }, validate: true

  validates :is_available, inclusion: [ true, false ]
  validates :rejection_reason, presence: true, if: :rejected?

  has_many :orders

  belongs_to :user
  belongs_to :reviewer, class_name: "User", foreign_key: "reviewer_id"

  def can_take_orders?
    !user.blocked? && approved? && is_available?
  end
end
