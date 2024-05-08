using System;
using System.IO;

namespace ConsoleApp5
{
    class Program
    {
        static void Main(string[] args)
        {
            // читаем весь файл с рабочего стола в строку текста
            string text = File.ReadAllText("C:\\Text.txt");

            // Сохраняем символы-разделители в массив
            char[] delimiters = new char[] { ' ', '\r', '\n' };

            // разбиваем нашу строку текста, используя ранее перечисленные символы-разделители
            var words = text.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
            // выводим количество
            Console.WriteLine(words.Length);
        }

    }
}
//  создаём пустой список с типом данных Contact
var phoneBook = new List<Contact>();

// добавляем контакты
phoneBook.Add(new Contact("Игорь", 79990000000, "igor@example.com"));
phoneBook.Add(new Contact("Андрей", 79990000001, "andrew@example.com"));

// проверяем, что добавилось в список
foreach (var contact in phoneBook)
    Console.WriteLine(contact.Name + ": " + contact.PhoneNumber);

Задание 13.3.4
Напишите метод для нашей телефонной книги, который получает на вход список и новый контакт, и добавляет его, только если он уникален.
Сигнатура метода:
AddUnique(Contact contact, List < Contact > phoneBook)
Модель класса:
public class Contact // модель класса
{
    public Contact(string name, long phoneNumber, String email) // метод-конструктор
    {
        Name = name;
        PhoneNumber = phoneNumber;
        Email = email;
    }

    public String Name { get; }
    public long PhoneNumber { get; }
    public String Email { get; }
}
После добавления нового контакта метод должен выводить список контактов, отсортированный по имени.
Посмотреть ответ для самопроверки
private static void AddUnique(Contact newContact, List<Contact> phoneBook)
{
    bool alreadyExists = false;

    // пробегаемся по списку и смотрим, есть ли уже с таким именем
    foreach (var contact in phoneBook)
    {
        if (contact.Name == newContact.Name)
        {
            //  если вдруг находим  -  выставляем флаг и прерываем цикл
            alreadyExists = true;
            break;
        }
    }

    if (!alreadyExists)
        phoneBook.Add(newContact);

    //  сортируем список по имени
    phoneBook.Sort((x, y) => String.Compare(x.Name, y.Name, StringComparison.Ordinal));

    foreach (var contact in phoneBook)
        Console.WriteLine(contact.Name + ": " + contact.PhoneNumber);
}

namespace DictionaryTest
{
    class Program
    {
        static void Main(string[] args)
        {
            // Создадим словарь. Ключом будет строка, а значением - массив строк
            var cities = new Dictionary<string, string[]>(3 /* Размер (указывать необязательно))*/ );

            // Добавим новые значения
            cities.Add("Россия", new[] { "Москва", "Санкт-Петербург", "Волгоград" });
            cities.Add("Украина", new[] { "Киев", "Львов", "Николаев", "Одесса" });
            cities.Add("Беларусь", new[] { "Минск", "Витебск", "Гродно" });
            //  Посмотрим всё что есть в словаре
            foreach (var citiesByCountry in cities)
            {
                Console.Write(citiesByCountry.Key + ": ");
                foreach (var city in citiesByCountry.Value)
                    Console.Write(city + " ");

                Console.WriteLine();
            }

            Console.WriteLine();

            // Теперь попробуем вывести значения по ключу
            var russianCities = cities["Россия"];
            Console.WriteLine("Города России:");
            foreach (var city in russianCities)
                Console.WriteLine(city);
        }
    }
}


if (cities.ContainsKey("Франция"))
{
    string[] value = cities["Франция"];
    //  Дальнейшие действия с value
}
else
{
    Console.WriteLine("Ключ не найден");
}



using System;
using System.Collections.Generic;
using System.Diagnostics;
 
namespace PhoneBook
{
    class Program
    {
        //  Объявим  простой  словарь
        private static Dictionary<string, Contact> PhoneBook = new Dictionary<String, Contact>()
        {
            ["Игорь"] = new Contact(79990000000, "igor@example.com"),
            ["Андрей"] = new Contact(79990000001, "andrew@example.com"),
        };

        static void Main(string[] args)
        {
            // Запустим таймер
            var watchTwo = Stopwatch.StartNew();

            // Выполним вставку
            PhoneBook.TryAdd("Диана", new Contact(79160000002, "diana@example.com"));

            // Выведем результат
            Console.WriteLine($"Вставка в  словарь: {watchTwo.Elapsed.TotalMilliseconds}  мс");
        }
    }
}
