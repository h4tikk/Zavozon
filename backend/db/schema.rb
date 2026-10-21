# This file is auto-generated from the current state of the database. Instead
# of editing this file, please use the migrations feature of Active Record to
# incrementally modify your database, and then regenerate this schema definition.
#
# This file is the source Rails uses to define your schema when running `bin/rails
# db:schema:load`. When creating a new database, `bin/rails db:schema:load` tends to
# be faster and is potentially less error prone than running all of your
# migrations from scratch. Old migrations may fail to apply correctly if those
# migrations use external dependencies or application code.
#
# It's strongly recommended that you check this file into your version control system.

ActiveRecord::Schema[8.1].define(version: 2026_10_20_152154) do
  # These are extensions that must be enabled in order to support this database
  enable_extension "pg_catalog.plpgsql"

  create_table "api_sessions", force: :cascade do |t|
    t.bigint "user_id", null: false
    t.string "token_digest"
    t.datetime "expires_at"
    t.datetime "revoked_at"
    t.datetime "created_at", null: false
    t.datetime "updated_at", null: false
    t.index ["user_id"], name: "index_api_sessions_on_user_id"
  end

  create_table "cart_items", force: :cascade do |t|
    t.bigint "cart_id", null: false
    t.bigint "product_id", null: false
    t.integer "quantity"
    t.datetime "created_at", null: false
    t.datetime "updated_at", null: false
    t.index ["cart_id"], name: "index_cart_items_on_cart_id"
    t.index ["product_id"], name: "index_cart_items_on_product_id"
  end

  create_table "carts", force: :cascade do |t|
    t.bigint "user_id", null: false
    t.datetime "created_at", null: false
    t.datetime "updated_at", null: false
    t.index ["user_id"], name: "index_carts_on_user_id"
  end

  create_table "couriers", force: :cascade do |t|
    t.bigint "user_id", null: false
    t.boolean "is_available"
    t.datetime "created_at", null: false
    t.datetime "updated_at", null: false
    t.integer "approval_status", default: 0, null: false
    t.datetime "reviewed_at"
    t.bigint "reviewer_id"
    t.text "rejection_reason"
    t.index ["reviewer_id"], name: "index_couriers_on_reviewer_id"
    t.index ["user_id"], name: "index_couriers_on_user_id"
  end

  create_table "order_items", force: :cascade do |t|
    t.bigint "order_id", null: false
    t.bigint "product_id", null: false
    t.string "product_title"
    t.integer "unit_price"
    t.integer "quantity"
    t.integer "total_price"
    t.datetime "created_at", null: false
    t.datetime "updated_at", null: false
    t.index ["order_id"], name: "index_order_items_on_order_id"
    t.index ["product_id"], name: "index_order_items_on_product_id"
  end

  create_table "orders", force: :cascade do |t|
    t.bigint "purchase_id", null: false
    t.bigint "seller_id", null: false
    t.bigint "courier_id", null: false
    t.integer "products_amount"
    t.integer "seller_reward"
    t.integer "courier_reward"
    t.integer "pick_up_point_reward"
    t.integer "platform_commission"
    t.integer "order_status"
    t.datetime "courier_accepted_at"
    t.datetime "delivered_by_courier_at"
    t.datetime "received_by_user_at"
    t.datetime "created_at", null: false
    t.datetime "updated_at", null: false
    t.index ["courier_id"], name: "index_orders_on_courier_id"
    t.index ["purchase_id"], name: "index_orders_on_purchase_id"
    t.index ["seller_id"], name: "index_orders_on_seller_id"
  end

  create_table "payment_claims", force: :cascade do |t|
    t.bigint "user_id", null: false
    t.bigint "purchase_id"
    t.bigint "seller_id"
    t.integer "expected_amount"
    t.integer "claimed_amount"
    t.string "player_nickname"
    t.string "receiver_nickname"
    t.integer "payment_claim_status"
    t.bigint "reviewer_id"
    t.datetime "reviewed_at"
    t.text "rejection_reason"
    t.datetime "created_at", null: false
    t.datetime "updated_at", null: false
    t.integer "purpose"
    t.index ["purchase_id"], name: "index_payment_claims_on_purchase_id"
    t.index ["reviewer_id"], name: "index_payment_claims_on_reviewer_id"
    t.index ["seller_id"], name: "index_payment_claims_on_seller_id"
    t.index ["user_id"], name: "index_payment_claims_on_user_id"
  end

  create_table "pick_up_points", force: :cascade do |t|
    t.string "name"
    t.text "description"
    t.integer "x"
    t.integer "y"
    t.integer "z"
    t.integer "pick_up_point_status", default: 0, null: false
    t.bigint "owner_id", null: false
    t.bigint "reviewer_id"
    t.datetime "reviewed_at"
    t.text "rejection_reason"
    t.text "suspension_reason"
    t.datetime "created_at", null: false
    t.datetime "updated_at", null: false
    t.index ["owner_id"], name: "index_pick_up_points_on_owner_id"
    t.index ["reviewer_id"], name: "index_pick_up_points_on_reviewer_id"
  end

  create_table "products", force: :cascade do |t|
    t.string "name"
    t.text "description"
    t.integer "price"
    t.integer "stock"
    t.boolean "is_active"
    t.bigint "seller_id", null: false
    t.datetime "created_at", null: false
    t.datetime "updated_at", null: false
    t.index ["seller_id"], name: "index_products_on_seller_id"
  end

  create_table "purchases", force: :cascade do |t|
    t.bigint "user_id", null: false
    t.bigint "pick_up_point_id", null: false
    t.integer "product_amount"
    t.integer "delivery_amount"
    t.integer "total_amount"
    t.integer "purchase_status"
    t.datetime "payment_expire_at"
    t.datetime "created_at", null: false
    t.datetime "updated_at", null: false
    t.index ["pick_up_point_id"], name: "index_purchases_on_pick_up_point_id"
    t.index ["user_id"], name: "index_purchases_on_user_id"
  end

  create_table "sellers", force: :cascade do |t|
    t.string "store_name"
    t.text "description"
    t.bigint "user_id", null: false
    t.datetime "paid_until"
    t.integer "approval_status", default: 0, null: false
    t.datetime "reviewed_at"
    t.text "rejection_reason"
    t.datetime "created_at", null: false
    t.datetime "updated_at", null: false
    t.bigint "reviewer_id"
    t.index ["reviewer_id"], name: "index_sellers_on_reviewer_id"
    t.index ["user_id"], name: "index_sellers_on_user_id"
  end

  create_table "users", force: :cascade do |t|
    t.string "minecraft_nickname"
    t.string "telegram_username"
    t.bigint "telegram_user_id"
    t.datetime "created_at", null: false
    t.datetime "updated_at", null: false
    t.boolean "admin", default: false, null: false
    t.datetime "blocked_at"
    t.boolean "can_review_sellers", default: false, null: false
    t.boolean "can_review_couriers", default: false, null: false
    t.boolean "can_review_pick_up_points", default: false, null: false
    t.boolean "can_review_payments", default: false, null: false
    t.index ["telegram_user_id"], name: "index_users_on_telegram_user_id", unique: true
  end

  add_foreign_key "api_sessions", "users"
  add_foreign_key "cart_items", "carts"
  add_foreign_key "cart_items", "products"
  add_foreign_key "carts", "users"
  add_foreign_key "couriers", "users"
  add_foreign_key "couriers", "users", column: "reviewer_id"
  add_foreign_key "order_items", "orders"
  add_foreign_key "order_items", "products"
  add_foreign_key "orders", "couriers"
  add_foreign_key "orders", "purchases"
  add_foreign_key "orders", "sellers"
  add_foreign_key "payment_claims", "purchases"
  add_foreign_key "payment_claims", "sellers"
  add_foreign_key "payment_claims", "users"
  add_foreign_key "payment_claims", "users", column: "reviewer_id"
  add_foreign_key "pick_up_points", "users", column: "owner_id"
  add_foreign_key "pick_up_points", "users", column: "reviewer_id"
  add_foreign_key "products", "sellers"
  add_foreign_key "purchases", "pick_up_points"
  add_foreign_key "purchases", "users"
  add_foreign_key "sellers", "users"
  add_foreign_key "sellers", "users", column: "reviewer_id"
end
