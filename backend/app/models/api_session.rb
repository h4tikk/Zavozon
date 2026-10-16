class ApiSession < ApplicationRecord
  belongs_to :user

  validates :token, :expires_at, presence: true

  scope :active, -> {
    where(expires_at: nil)
      .where("expires_at > ?", Time.current)
  }

  def revoke!
    update!(revoked_at: Time.current)
  end
end
