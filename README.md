MicroServices:
  1. Answer - апи для взаимодействия с ответами на вопросы
  2. Identity - апи авторизации, регистрации и юзеров
  3. Membership - апи для взаимодействия с подписками
  4. Membership.BackgroundTasks - Бекграунд работа с платными услугами
  5. Point - апи для взаимодействия с лидербордом и поинтами
  6. Quest - Дейлики, виклики и в целом квесты
  7. Quest.BackgroundTasks - Бэкграунд работа с квестами (Просрок выполнения и тп)
  8. Statistic - апи статистики (выполнено вопросов за день и тп)
  9. Test - апи для подборок с вопросами
  10. Theme - Темы (Финансовые нарушения, защита персональных данных и тп)

<img width="884" alt="Snimok_Ekrana_2023-12-09_V_20_37_23" src="https://github.com/LipninNikita/corviana-backend/assets/121155160/ef7481c7-95be-41df-bbd9-60c6f77ee5c8">

  Запуск проекта:
  - Git clone "url"
  - Win + R
  - cmd
  - cd /path/to/project
  - docker-compose up

  Использование:
  - http://localhost:5000 - apigateway
  - http://localhost:(5000 - 5008)/swagger апи документация
