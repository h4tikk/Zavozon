class Order < ApplicationRecord
  enum order_status: [ :awaiting_payment, :paid, :accepted_by_seller, :packing, :ready_for_courier, :in_transit, :delivered_by_courier, :ready_for_pick_up, :received, :cancelled, :diputed ]

  validates :products_amount,
    :seller_reward,
    :courier_reward,
    :pick_up_point_reward,
    :platform_commission, numericality: {only_integer: true, greater_then: 0 }

  belongs_to :purchase
  belongs_to :seller
  belongs_to :courier
end
