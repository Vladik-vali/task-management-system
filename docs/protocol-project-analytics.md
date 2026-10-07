# Протокол №2. Получение аналитики по проекту

**Инициатор:** `ApiHost`
**Получатель:** `AnalyticsModule`
**Механизм вызова:** асинхронный вызов `IAnalyticsService.GetProjectAnalyticsAsync`
**Версия контракта:** AnalyticsContract v1

## Назначение

Получение сводной информации о состоянии проекта: количество задач по статусам, число просроченных задач.

## Точка входа

```csharp
Task<ProjectAnalyticsDto> GetProjectAnalyticsAsync(
    Guid projectId,
    CancellationToken cancellationToken);
```

## Формат запроса

Параметр пути: `projectId`.

## Формат успешного ответа

```json
{
  "projectId": "8939af05-2a59-4758-a263-75df01c6d3f0",
  "totalTasks": 10,
  "completedTasks": 5,
  "inProgressTasks": 3,
  "overdueTasks": 2
}
```

## Ошибки

| Код | Описание |
|---|---|
| `PROJECT_NOT_FOUND` | Проект не существует |

## Таймаут

3 секунды.

## Повторная отправка

Допускается — операция идемпотентна.

## Аутентификация

Не требуется.

## Пример обмена

```text
ApiHost
      │
      │ GetProjectAnalyticsAsync(projectId)
      ▼
AnalyticsModule
      │
      │ Сбор данных
      ▼
ProjectAnalyticsDto
      │
      ▼
ApiHost
```