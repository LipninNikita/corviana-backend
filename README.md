MicroServices:
  1. Answer - апи для взаимодействия с вопросами
  2. Identity - апи авторизации, регистрации и юзеров
  3. Membership - Подписка на платные услуги
  4. Membership.BackgroundTasks - Работа с платными услугами
  5. Point - апи для взаимодействия с лидербордом
  6. Quest - Дейлики, виклики и в целом квесты
  7. Quest.BackgroundTasks - Бэкграунд работа с платными услугами
  8. Statistic - апи сбора статистики
  9. Test - фпи для тестов с вопроами
  10. Theme - Темы (Финансовые нарушения, защита персональных данных и тп)

  Запуск проекта:
  - Win + R
  - cmd
  - cd /path/to/project
  - docker-compose up

  Использование:
  - http://localhost:5000 - apigateway
  - http://localhost:(5001 - 5008)/swagger апи документация
