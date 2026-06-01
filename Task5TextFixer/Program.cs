using Task5TextFixer.Services; // Подключение пространства имен с сервисами

Console.WriteLine("Введите путь к директории:"); // Запрос пути у пользователя
string? directoryPath = Console.ReadLine(); // Чтение введенного пути

if (string.IsNullOrWhiteSpace(directoryPath)) // Проверка, что путь не пустой и не состоит из пробелов
{
    Console.WriteLine("Путь не может быть пустым."); // Сообщение об ошибке
    return; // Досрочный выход из программы
}

FileProcessor processor = new FileProcessor(); // Создание экземпляра обработчика файлов
processor.ProcessDirectory(directoryPath); // Запуск обработки всех файлов в указанной директории

Console.WriteLine("Обработка завершена."); // Уведомление об окончании работы
