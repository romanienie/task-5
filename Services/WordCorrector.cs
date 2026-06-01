using System.Text.RegularExpressions; // Для работы с регулярными выражениями
using Task5TextFixer.Data; // Импорт словаря с ошибками

namespace Task5TextFixer.Services; // Пространство имен для сервисов

public class WordCorrector // Класс для исправления слов в тексте
{
    public string CorrectWords(string text) // Метод замены ошибочных слов на правильные
    {
        foreach (var pair in ErrorWordsDictionary.Words) // Перебор всех пар из словаря ошибок
        {
            string wrongWord = pair.Key; // Неправильное слово
            string correctWord = pair.Value; // Правильный вариант

            text = Regex.Replace( // Замена всех вхождений слова в тексте
                text,
                $@"\b{Regex.Escape(wrongWord)}\b", // Границы слова + экранирование спецсимволов
                correctWord, // Слово для замены
                RegexOptions.IgnoreCase // Игнорирование регистра букв
            );
        }

        return text; // Возврат исправленного текста
    }
}
