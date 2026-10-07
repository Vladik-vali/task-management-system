# Контракты взаимодействия

## Точки входа HTTP API

| Метод | Адрес | Назначение |
|---|---|---|
| `GET` | `/api/projects` | Список проектов |
| `POST` | `/api/projects` | Создание проекта |
| `GET` | `/api/projects/{id}/tasks` | Задачи проекта |
| `POST` | `/api/tasks` | Создание задачи |
| `GET` | `/api/tasks/{id}` | Получение задачи |
| `PUT` | `/api/tasks/{id}/status` | Обновление статуса |
| `PUT` | `/api/tasks/{id}/assignee` | Назначение исполнителя |
| `GET` | `/api/analytics/projects/{id}` | Аналитика по проекту |

## Протоколы взаимодействия модулей

* [Протокол №1. Назначение исполнителя на задачу](protocol-task-assignment.md)
* [Протокол №2. Получение аналитики по проекту](protocol-project-analytics.md)