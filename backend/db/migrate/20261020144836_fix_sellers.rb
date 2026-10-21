class FixSellers < ActiveRecord::Migration[8.1]
  def change
    rename_column :sellers, :reviewer_id_id, :reviewer_id
    rename_column :sellers, :descriprion, :description
  end
end
