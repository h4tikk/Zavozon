require "net/http"
require "json"
module User
  class CheckUserOnServerService
    def initialize(nickname)
      @nickname = nickname
    end

    def is_online?
      find_player.nil?
    end

    private

    API_URL = "https://zlp.onl/map/maps/world/live/players.json"

    def get_online_players
      uri = URI(API_URL)
      headers = {
        "User-Agent" => "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36",
        "Referer" => "https://zlp.onl/map/",
        "Accept" => "application/json, text/plain, */*"
      }
      request = Net::HTTP::Get.new(uri.request_uri, headers)

      response = Net::HTTP.start(uri.host, uri.port, use_ssl: true) do |http|
        http.request(request)
      end

      response.body
    end

    def find_player
      players = JSON.parse(get_online_playes)

      if players.blank?
        return nil
      end

      players["players"]["name"].each do |player|
        if player.downcase == @nickname.downcase
          return player
        end
      end
    end
  end
end
