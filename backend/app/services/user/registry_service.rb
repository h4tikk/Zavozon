require_relative "check_user_on_server_service"
module User
  class RegistryService
    def initialize(mine_nick, tg_username, tg_id)
      @mine_nick = mine_nick
      @tg_username = tg_username
      @tg_id = tg_id
    end

    def register
      unless CheckUserOnServerService.is_online?(nickname: @mine_nick)
        raise InvalidArgumentError, "Вы не на онлайн"
      end

      if User.find_by_telegram(@tg_username, @tg_id) || User.find_by_minecraft_nickname(@nickname)
        raise InvalidArgumentError, "Вы цже зарегистрированы"
      end

      User.create(minecraft_nickname: @mine_nick, telegram_username: @tg_username)
    end
  end
end