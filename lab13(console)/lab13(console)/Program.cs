using System;
using System.IO;

namespace lab13_console_
{
    abstract class Goods            //абстрактный класс Товар
    {
        abstract public void PrintInf();               //абстрактный метод для вывода информации
        abstract public bool Kind(string keyword);     //абстрактный метод для проверки данных в массиве
    }
    
    class Toy : Goods               //класс игрушка
    {
        string kind = "Toy";        //тип товара (для поиска)
        string name;                //название
        double price;               //цена
        string producer;              //производитель
        string material;            //материал
        int age;                    //возраст
        public Toy(string name, double price, string producer, string material, int age)
        {
                                                    //this - обеспечивает доступ к текущему экземпляру класса, т.к.
            this.name = name;                       //входящий параметр назван так же, как поле данных данного типа
            this.price = price;
            this.producer = producer;
            this.material = material;
            this.age = age;
        }
        public override void PrintInf()                //переопределение метода PrintInf() с помощью override
        {
            Console.WriteLine("\nТип товара:" + kind + "\nНазвание:" + name + "\nЦена:" + price + "\nПроизводитель:" + producer + "\nМатериал:" + material + "\nВозраст:" + age);
        }
        public override bool Kind(string keyword)
        {
            return keyword.Contains(kind);             //проверка, встречается ли указанный символ внутри этой строки
        }
    }
    
    class Book : Goods              //Класс книга
    {
        string kind = "Book";
        string name;
        string author;              //автор
        double price;
        string producer;             //издательство
        int age;
        public Book(string name, string author, double price, string producer, int age)
        {
            this.name = name;
            this.author = author;
            this.price = price;
            this.producer = producer;
            this.age = age;
        }
        public override void PrintInf()                 //переопределение метода PrintInf() с помощью override
        {
            Console.WriteLine("\nТип товара:" + kind + "\nНазвание:" + name + "\nАвтор:" + author + "\nЦена:" + price + "\nИздательство:" + producer + "\nВозраст:" + age);
        }
        public override bool Kind(string keyword)
        {
            return keyword.Contains(kind);
        }
    }
    
    class Sport : Goods             //Класс спорт-инвертарь
    {
        string kind = "Sport";
        string name;
        double price;
        string producer;
        int age;
        public Sport(string name, double price, string producer, int age)
        {
            this.name = name;
            this.price = price;
            this.producer = producer;
            this.age = age;
        }
        public override void PrintInf()                 //переопределение метода PrintInf() с помощью override
        {
            Console.WriteLine("\nТип товара:" + kind + "\nНазвание:" + name + "\nЦена:" + price + "\nПроизводитель:" + producer + "\nВозраст:" + age);
        }
        public override bool Kind(string keyword)
        {
            return keyword.Contains(kind);
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            int flag = 0;
            string? keyword;                           //? - тип допускает значение null

            string[] str1;                          //Запись из файла
            int linesLen = File.ReadAllLines(@"D:\Учебная практика\Задание 13\lab13(console)\lab13(console)\text.txt").Length;

            Goods[] arrGood = new Goods[linesLen]; //массив товаров
            using (StreamReader sr = new StreamReader(@"D:\Учебная практика\Задание 13\lab13(console)\lab13(console)\text.txt"))
            {
                int i = 0;
                while (sr.Peek() > -1)              //определение, достигнут ли конец файла
                {
                    str1 = sr.ReadLine().Split('|');    //все элементы разделены |

                    if (str1[0] == "Toy")
                    {
                        arrGood[i] = new Toy(str1[1], double.Parse(str1[2]), str1[3], str1[4], int.Parse(str1[5]));
                        //название, цена, производитель, материал, возраст
                    }
                    else if (str1[0] == "Book")
                    {
                        arrGood[i] = new Book(str1[1], str1[2], double.Parse(str1[3]), str1[4], int.Parse(str1[5]));
                        //
                    }
                    else if(str1[0] == "Sport")
                    {
                        arrGood[i] = new Sport(str1[1], double.Parse(str1[2]), str1[3], int.Parse(str1[4]));
                    }
                        i++;
                }
            }

            Console.Write("Данные из файла");              //вывод всей информации из файла
            Console.WriteLine();
            for (int i = 0; i < linesLen; i++)
            {
                arrGood[i].PrintInf();
            }

            Console.WriteLine();

            do
            {
                Console.WriteLine("Введите тип товаров, которые нужно найти \n" +
                    "Toy - игрушки\nBook - книги\nSport - спортивный инвентарь\nend - выйти из программы");
                flag = 0;
                keyword = Console.ReadLine();
                for (int i = 0; i < linesLen; i++)
                    if (arrGood[i].Kind(keyword))
                    {
                        arrGood[i].PrintInf();
                        flag++;
                    }

                if (keyword == "end")
                    break;
                if (flag == 0)
                    Console.WriteLine("Такого типа товаров в базе нет");

            } while (true);


        }
    }
}
