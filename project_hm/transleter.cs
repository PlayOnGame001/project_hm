using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project_hm
{
    interface CreatDictionary  //Создаем интерфейс словаря создание слов 
    {
        void Create();
    }
    interface EditDictionary  // Интерфейс словоря с дополнением 
    {
        void Add(Dictionary<string, string> translate, FileStream fs);

    }
    interface PrintDictionary // Создание интерфейса с печаткой словаря 
    {
        void Print();
    }
    //interface ClearDictionary // Удаляем все объекты из определенного словаря
    //{
    //    void Clear(); 
    //}
    class Dictionary : CreatDictionary, EditDictionary, PrintDictionary
    {
        public Dictionary<string, string> dictionary;
        public string language; //Язык который мы выберем 
        //public string e;
        //public string r;
        public Dictionary() { }
        public Dictionary(Dictionary<string, string> slovo)
        {
            dictionary = slovo;
        }
        public void Create()
        {
            dictionary = new Dictionary<string, string>();//Язык который мы выберем щапишется в словарь 
            Console.WriteLine($"Выберите словерь из предложенных 1)English, 2)Russian ");
            Console.Write("Введите тип переводчика: ");
            language = Console.ReadLine();
            Console.WriteLine($"Вы выбрали язык {language}, вы уверены? ");

            //if (num <1)
            //{
            //    Console.WriteLine("Хорошо");
            //}
            //else
            //{
            //    Console.WriteLine("Выберите другой");
            //}
        }
        public void Add(Dictionary<string, string> translate, FileStream fs)
        {
            Console.Write("Введите слово: ");//Тут все просто в водим слово 
            string slovo = Console.ReadLine(); //Запись в веденого слова 
            Console.Write("Введите перевод слова и все его возможное варинаты: ");//Тут все просто в водим слово тут перевод этого слова
            string translet_slovo = Console.ReadLine();//Чтение переведенного слоав 
            translate.Add(slovo, translet_slovo);//Добавления слова и его перевод 
            StreamWriter write_file = new StreamWriter(fs);//Запись обоих слов в файл
            write_file.WriteLine(translate);//Запись в файл переведенного слова 
            foreach (var item in translate)//
            {
                write_file.Write($"{item.Key} - перевод - {item.Value}");//Слово под ключом которое записали и перевод слова под Value запись в файл
            }
        }
        public void Print()//
        {
            Console.WriteLine($"язык который вы выбрали {language}");//Тип языка  
            foreach (var a in dictionary)//слово записанное в переводчик 
            {
                Console.WriteLine($"{a.Key} превод слова: {a.Value}");//Слово под ключом которое записали и перевод слова под Value запись на консоли
            }
        }
    }
}