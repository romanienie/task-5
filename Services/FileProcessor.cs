namespace Task5TextFixer.Services; // Пространство имен для сервисов

public class FileProcessor // Класс для обработки файлов в директории
{
    private readonly WordCorrector _wordCorrector = new(); // Сервис исправления слов
    private readonly PhoneNumberFormatter _phoneFormatter = new(); // Сервис форматирования телефонов

    public void ProcessDirectory(string directoryPath) // Метод обработки всех txt-файлов
    {
        if (!Directory.Exists(directoryPath)) // Проверка существования директории
        {
            Console.WriteLine("Директория не найдена.");
            return; // Выход, если директории нет
        }

        string[] files = Directory.GetFiles( // Получение всех txt-файлов
            directoryPath,
            "*.txt", // Только файлы с расширением .txt
            SearchOption.AllDirectories // Включая вложенные папки
        );

        foreach (string file in files) // Перебор каждого найденного файла
        {
            string originalText = File.ReadAllText(file); // Оригинальное содержимое файла
            string updatedText = originalText; // Копия для изменений

            updatedText = _wordCorrector.CorrectWords(updatedText); // Исправление ошибок в словах
            updatedText = _phoneFormatter.FormatPhoneNumbers(updatedText); // Форматирование номеров телефонов

            if (updatedText != originalText) // Если были изменения
            {
                File.WriteAllText(file, updatedText); // Сохраняем изменения в файл
                Console.WriteLine($"Изменен файл: {file}");
            }
            else // Если изменений не было
            {
                Console.WriteLine($"Без изменений: {file}");
            }
        }
    }
}
