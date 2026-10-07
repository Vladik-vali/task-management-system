# Система управления задачами проекта

Приложение для постановки и контроля выполнения задач. Реализует проекты, задачи, исполнителей, приоритеты, сроки и статусы выполнения. Предусматривает поиск, фильтрацию и получение информации о состоянии проекта.

## Требования

* .NET SDK 9
* Git

Проверка версии .NET:

```bash
dotnet --version
```

## Получение проекта

```bash
git clone https://github.com/Vladik-vali/task-management-system.git
cd task-management-system
```

## Восстановление зависимостей

```bash
dotnet restore
```

## Сборка

```bash
dotnet build
```

## Выполнение тестов

```bash
dotnet test
```

## Запуск

```bash
dotnet run --project src/TaskManagement.Api
```

После запуска API становится доступно по адресу, указанному приложением в консоли.
