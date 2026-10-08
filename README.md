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

## Структура репозитория

```
task-management-system/
├── docs/               # проектная документация
│   └── decisions/      # журнал архитектурных решений (ADR)
├── img/                # схемы и скриншоты
├── README.md           # этот файл
├── Этап_1_task-management-system.md   # отчёт по этапу 1
└── Этап_2_task-management-system.md   # отчёт по этапу 2
```

## Инструменты разработки

В проекте используются:

- `.gitignore` — исключение служебных файлов (`bin`, `obj`, `.vs`, `secrets.json` и т.д.)
- `.editorconfig` — единые правила форматирования для всех разработчиков

## Отчёты по этапам

- [Этап 1. Артефакты и протоколы проекта](Этап_1_task-management-system.md)
- [Этап 2. Настройка Git](Этап_2_task-management-system.md)