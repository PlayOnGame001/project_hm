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

        public Dictionary() { }
        public Dictionary(Dictionary<string, string> slovo)
        {
            dictionary = slovo;
        }
        public void Create()
        {
            dictionary = new Dictionary<string, string>();//Язык который мы выберем щапишется в словарь 
            Console.Write("Введите тип переводчика: ");
            language = Console.ReadLine();
        }
        public void Add(Dictionary<string, string> translate, FileStream fs)
        {
            Console.Write("Введите слово: ");//Тут все просто в водим слово 
            string slovo = Console.ReadLine(); //Запись в веденого слова 
            Console.Write("Введите перевод слова и все его возможное варинаты: ");//Тут все просто в водим слово тут перевод этого слова
            string t_slovo = Console.ReadLine();//Чтение переведенного слоав 
            translate.Add(slovo, t_slovo);//
            StreamWriter write_file = new StreamWriter(fs);//Запись обоих слов в файл
            write_file.WriteLine(translate);//
            foreach (var item in translate)//
            {
                write_file.Write($"{item.Key} - {item.Value}");//
            }
        }
        public void Print()//
        {
            Console.WriteLine($"Type: {language}");//Тип языка и его слово 
            foreach (var a in dictionary)//
            {
                Console.WriteLine($"{a.Key} - {a.Value}");//
            }
        }
    }
}