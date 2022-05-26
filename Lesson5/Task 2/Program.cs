using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using Yar.Learning;

namespace Task_2
{
    public static class Message
    {
        private static string[] separators = { " ", ",", ".", ":", ";", "?", "!", "-"};

        /// <summary>
        /// Prints words from message, that lesser than wordLength
        /// </summary>
        /// <param name="text"></param>
        /// <param name="wordLength"></param>
        public static void PrintWordsLesserThan(string text, int wordLength)
        {
            string[] words = text.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < words.Length; i++)
            {
                if(words[i].Length < wordLength)
                    Console.WriteLine(words[i]);
            }
        }
        
        /// <summary>
        /// Removes all words, that ends on restricted symbol in given string
        /// </summary>
        /// <param name="text"></param>
        /// <param name="restrictedSymbol"></param>
        public static void RemoveAllWordsThatEndsOn(ref string text, char restrictedSymbol)
        {
            string[] words = text.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < words.Length; i++)
            {
                if (words[i][words[i].Length-1] == restrictedSymbol)
                    text = text.Replace(words[i], "");
            }
        }
        
        /// <summary>
        /// Returns new string with longest words
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string FindLongestWords(string text)
        {
            string[] words = text.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            StringBuilder sb = new StringBuilder("Слова с наибольшей длиной: ");
            int maxLength = 0;
            for (int i = 0; i < words.Length; i++)
            {
                if (words[i].Length > maxLength)
                    maxLength = words[i].Length;
            }

            foreach (var word in words)
            {
                if (word.Length == maxLength)
                    sb.Append($"{word}, ");
            }

            sb.Remove(sb.Length - 2, 2);
            sb.Append('.');
            return sb.ToString();
        }
        
        /// <summary>
        /// Prints number of occurrences for every word in wordsToSearch array
        /// </summary>
        /// <param name="text"></param>
        /// <param name="wordsToSearch"></param>
        public static void CountNumberOfWordsOccurrences(string text, string[] wordsToSearch)
        {
            string[] words = text.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            Dictionary<string, int> dict = new Dictionary<string, int>();
            foreach (var word in wordsToSearch)
            {
                dict.Add(word,0);
            }
            foreach (var wordToSearch in wordsToSearch)
            {
                int wordCounter = 0;
                foreach (var word in words)
                {
                    if (word.ToLower() == wordToSearch.ToLower())
                        wordCounter++;
                }
                dict[wordToSearch] = wordCounter;
            }

            foreach (var word in dict)
            {
                Console.WriteLine($"Слово {word.Key} встречается {word.Value} раз");
            }
        }

        /// <summary>
        /// Check if string1 equals to reversed string2
        /// </summary>
        /// <param name="string1"></param>
        /// <param name="string2"></param>
        /// <returns></returns>
        public static bool CheckIfReversed(string string1, string string2)
        {
            if (string1.Length != string2.Length)
                return false;
            int reversedCounter = string2.Length-1;
            for (int i = 0; i < string1.Length; i++)
            {
                if (string1[i] != string2[reversedCounter])
                {
                    return false;
                }
                reversedCounter--;
            }
            return true;
        }

        /// <summary>
        /// Checks if string1 is rearranged string2
        /// </summary>
        /// <param name="string1"></param>
        /// <param name="string2"></param>
        /// <returns></returns>
        public static bool CheckIfRearranged(string string1, string string2)
        {
            char[] charArray1 = string1.ToCharArray();
            Array.Sort(charArray1);

            char[] charArray2 = string2.ToCharArray();
            Array.Sort(charArray2);

            string1 = new string(charArray1);
            string2 = new string(charArray2);
            //if (charArray1.ToString() == charArray2.ToString())
            if (string1 == string2)
                return true;
            else
                return false;
        }
    }
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(@"Разработать статический класс Message");
            Console.WriteLine("В качестве текста возьмем:");
            string text = "Так, я уже высадил минут 15 на придумывание того, какой бы остроумный текст засунуть сюда, для демонстрации работы класса. Вот, будет этот. А сюда еще одинаковых слов слов текст для поиска поиска.";
            Console.WriteLine(text);
            Console.ReadKey();
            Console.Clear();
            
            Console.WriteLine("а) Вывести только те слова сообщения, которые содержат не более n букв. Берем 5 букв максимум");
            Message.PrintWordsLesserThan(text,5);
            Console.ReadKey();
            Console.Clear();
            
            Console.WriteLine("б) Удалить из сообщения все слова, которые заканчиваются на заданный символ. Тестим на 'й' ");
            Message.RemoveAllWordsThatEndsOn(ref text, 'й');
            Console.WriteLine(text);
            Console.ReadKey();
            Console.Clear();
            
            Console.WriteLine("в) Найти самое длинное слово сообщения.");
            Console.WriteLine("г) Сформировать строку с помощью StringBuilder из самых длинных слов сообщения.");
            Console.WriteLine(Message.FindLongestWords(text));
            Console.ReadKey();
            Console.Clear();

            Console.WriteLine("д) ***Создать метод, который производит частотный анализ текста. В качестве параметра в него передается массив слов и текст, в качестве результата метод возвращает сколько раз каждое из слов массива входит в этот текст.");
            string[] wordsToSearch = new[] { "текст", "поиска", "одинаковых", "слов", "высадил" };
            Message.CountNumberOfWordsOccurrences(text, wordsToSearch);
            Console.ReadKey();
            Console.Clear();
            
            Console.WriteLine("Для двух строк написать метод, определяющий, является ли одна строка перестановкой другой.");
            string string1 = "тест";
            string string2 = "тсет";
            string string3 = "тесет";
            Console.WriteLine($"Проверяем строки: {string1}, {string2}, {string3}");
            Console.WriteLine($"тест, тсет: {Message.CheckIfRearranged(string1, string2)}, тсет, тесет: {Message.CheckIfRearranged(string2, string3)}");
            Console.ReadKey();




        }
    }
}