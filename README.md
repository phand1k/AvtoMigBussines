AvtoMigBussines API предназначен для управления данными и операциями в системе автоматизации работы автомоек и центров детейлинга.
Описание
AvtoMigBussines API предоставляет RESTful интерфейс для взаимодействия с данными пользователей, организаций, услуг и заказов. API поддерживает аутентификацию с использованием JWT токенов.
Функционал
Управление пользователями (регистрация, аутентификация, обновление профиля).
Управление организациями (создание, обновление, удаление).
Управление услугами (создание, обновление, удаление).
Управление заказами (создание, обновление, удаление, получение статуса).
Лицензия
Этот проект лицензирован под лицензией MIT. Подробности см. в файле LICENSE.
Ссылка для тестирования апи:
https://avtosat-001-site1.ftempurl.com/swagger/index.html
Основные эндпоинты:
https://avtosat-001-site1.ftempurl.com/api/Authenticate/Login
Вход:
![image](https://github.com/user-attachments/assets/87155ed0-c4cf-4fd5-8665-7de9b58db75a)
https://avtosat-001-site1.ftempurl.com/api/Authenticate/Register
Регистрация:
![image](https://github.com/user-attachments/assets/72033f52-0df1-4b67-a486-7c742b013126)
https://avtosat-001-site1.ftempurl.com/api/Authenticate/GetRole
Получение роли текущего пользователя (текущий пользователь идентифицируется с помощью jwt токена)
![image](https://github.com/user-attachments/assets/4ed98976-92b9-4ea6-a065-d67060add047)
https://avtosat-001-site1.ftempurl.com/api/token/RegisterToken
Получение токена пользователя для отправки push уведомлений в мобильном приложении, так же авторизация проходит с помощью JWT токена (react native expo go)
![image](https://github.com/user-attachments/assets/b8c3ae5d-f150-4050-8192-fc8eac9debc7)
