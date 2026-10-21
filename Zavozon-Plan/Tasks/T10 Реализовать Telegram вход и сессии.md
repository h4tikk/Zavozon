---
type: task
id: T10
phase: 2
status: todo
priority: P1
---
# T10 Реализовать Telegram вход и сессии

## Результат

Выдавать отзываемую Bearer-сессию после проверки initData.

## Пользовательские истории

[[US01 Вход через Telegram]]

## Модели

[[M01 User]], [[M02 ApiSession]], [[M14 Wallet]]

## Зависимости

- [[T02 Подготовить User и ApiSession]]
- [[T07 Создать кошельки журнал и заявки на вывод]]

## Работа

- Проверить raw initData HMAC, auth_date, типы, размер и дубли ключей.
- Найти/создать User по проверенному ID, идемпотентно обеспечить Wallet.
- Отказать blocked User; выдать случайный токен, сохранить digest; logout и logout all.
- Принять MVP TTL initData 5 минут и сессии 24 часа как настраиваемые предложения, не требование Telegram.

## Предлагаемые сервисы

Telegram::InitDataVerifier; Auth::TelegramLogin; Auth::IssueSession; Auth::RevokeSession; Auth::RevokeAllSessions

## Входные точки

POST /auth/telegram; DELETE /auth/session; DELETE /auth/sessions; GET /me

## Готово, когда

- [ ] Подмена user.id, неверный hash, stale/future timestamp отвергаются.
- [ ] Одновременный первый вход не создаёт два User/Wallet.
- [ ] Нет секретов в URL/логах; initData replay в пределах TTL явно документирован.

## Проверка

Проверять наблюдаемое поведение и ограничения БД, а не только наличие методов. Для рискованных операций обязательны rollback, повтор запроса и гонка. Набор сценариев: [[06 Проверка и готовность]].

Карточка описывает будущую работу. Наличие похожих полей в исходниках не означает, что задача выполнена.

Навигация: [[Канбан]] · [[03 Каталог сервисов]] · [[05 API и события]]
