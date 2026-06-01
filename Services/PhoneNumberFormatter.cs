using System.Text.RegularExpressions; // Для работы с регулярными выражениями

namespace Task5TextFixer.Services; // Пространство имен для сервисов

public class PhoneNumberFormatter // Класс для форматирования номеров телефонов
{
    public string FormatPhoneNumbers(string text) // Метод преобразования номеров в текст
    {
        string pattern = @"\((0\d{2})\)\s(\d{3})-(\d{2})-(\d{2})"; // Шаблон: (0XX) XXX-XX-XX

        return Regex.Replace(text, pattern, match => // Замена каждого найденного номера
        {
            string operatorCode = match.Groups[1].Value.Substring(1); // Код оператора (без первого нуля)
            string firstPart = match.Groups[2].Value; // Первая тройка цифр
            string secondPart = match.Groups[3].Value; // Вторая пара цифр
            string thirdPart = match.Groups[4].Value; // Третья пара цифр

            return $"+380 {operatorCode} {firstPart} {secondPart} {thirdPart}"; // Новый формат: +380 XX XXX XX XX
        });
    }
}
