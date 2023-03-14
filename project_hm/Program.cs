using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project_hm
{
    internal class Program
    {
        static void Main(string[] args)
        {
        //    Dictionary<int, string> BestLanguage = new Dictionary<int, string>()//Создаем колекцию
        //{    //Здесь словарь BestLanguage в качестве ключей принимает значения типа int, а в качестве значений - строки.
        //    {1, "English"},//ключ 1 
        //    {2, "Russian"},//ключ 2
        //};
        //    BestLanguage.Add(3, "German");//Мы можем добавить в колекцию еще один язык //добавляем ключ 3
            Dictionary translet = new Dictionary();
            translet.Create();//Создаем перевод 
            FileStream file = new FileStream(translet.language + ".txt", FileMode.OpenOrCreate);//Здесь передаеться путь к файлу и перечисление(указывает на режим доступа к файлу)
                                                                                                //(OpenOrCreate: если файл существует, он открывается, если нет - создается новый)
            translet.Add(translet.dictionary, file);//Добовляем в фаул перевод 
            translet.Print();
            file.Close();
        }
    }
}
