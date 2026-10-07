# Протокол №1. Назначение исполнителя на задачу

**Инициатор:** `TaskModule`
**Получатель:** `UserModule`
**Механизм вызова:** асинхронный вызов `IUserService.AssignUserAsync`
**Версия контракта:** UserAssignmentContract v1

## Назначение

Протокол используется при назначении исполнителя на задачу. Необходимо убедиться, что пользователь существует и может быть назначен.

## Точка входа

```csharp
Task<AssignUserResult> AssignUserAsync(
    AssignTaskRequest request,
    CancellationToken cancellationToken);
```

## Формат запроса

```json
{
  "taskId": "8939af05-2a59-4758-a263-75df01c6d3f0",
  "userId": "4f7fb20d-b92c-4082-a031-7eb643216a18"
}
```

## Формат успешного ответа

```json
{ "success": true, "errorCode": null }
```

## Ошибки

| Код | Описание |
|---|---|
| `USER_NOT_FOUND` | Пользователь не существует |
| `USER_NOT_AVAILABLE` | Пользователь не может быть назначен |

## Таймаут

3 секунды. Отмена — через `CancellationToken`.

## Повторная отправка

Автоматический повтор не выполняется.

## Аутентификация

Не требуется — вызов внутри одного приложения.

## Пример обмена

```text
TaskModule
      │
      │ AssignUserAsync(...)
      ▼
UserModule
      │
      │ Проверка пользователя
      ▼
AssignUserResult
      │
      ▼
TaskModule
```