---
type: task
id: T29
phase: 2
status: todo
priority: P1
---
# T29 Настроить jobs scheduler и восстановление

## Результат

Запускать jobs на durable queue с наблюдаемым восстановлением.

## Пользовательские истории

[[US16 Уведомления через бота]], [[US17 Привязка Minecraft]], [[US18 Поддержка и восстановление]]

## Модели

[[M17 TelegramNotification]], [[M19 TelegramUpdate]], [[M09 Purchase]], [[M16 WithdrawalRequest]]

## Зависимости

- [[T08 Создать TelegramNotification TelegramUpdate и AuditEvent]]
- [[T25 Реализовать Telegram webhook и команды]]
- [[T26 Реализовать уведомления только через бота]]

## Работа

- Выбрать Solid Queue в dev при проверке отдельных worker; memory cache не делится между процессами.
- Подготовить queue DB и migrations, bin/jobs, scheduler и очереди приоритетов.
- Recovery pending notifications/updates, lease timeout, истёкшие сессии, purchase expiry и зависшие presence.
- Payout processing никогда не восстанавливать автоматическим повторным переводом; вывести оператору.
- Job получает ID, после загрузки проверяет актуальное состояние; transient retry отличить от бизнес-отказа.

## Предлагаемые сервисы

Active Job wrappers: ProcessTelegramUpdateJob, DeliverTelegramNotificationJob, CheckMinecraftPresenceJob, RecoverPendingJob, ExpirePurchasesJob, ReconcileWalletsJob

## Входные точки

Операционные команды и recurring schedule, без публичного cron endpoint

## Готово, когда

- [ ] Рестарт worker между commit и enqueue не теряет событие.
- [ ] Несколько worker не выполняют одну бизнес-операцию дважды.
- [ ] Есть метрики возраста pending, dead jobs и needs_reconciliation.

## Проверка

Проверять наблюдаемое поведение и ограничения БД, а не только наличие методов. Для рискованных операций обязательны rollback, повтор запроса и гонка. Набор сценариев: [[06 Проверка и готовность]].

Карточка описывает будущую работу. Наличие похожих полей в исходниках не означает, что задача выполнена.

Навигация: [[Канбан]] · [[03 Каталог сервисов]] · [[05 API и события]]
