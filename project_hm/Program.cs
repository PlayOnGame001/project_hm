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
        //////////Идея в том чтобы создать колекцию где выбераешь язык из предложенных 
        //    Dictionary<int, string> BestLanguage = new Dictionary<int, string>()//Создаем колекцию
        //{    //Здесь словарь BestLanguage в качестве ключей принимает значения типа int, а в качестве значений - строки.
        //    {1, "English"},//ключ 1 
        //    {2, "Russian"},//ключ 2
        //};
        //    BestLanguage.Add(3, "German");//Мы можем добавить в колекцию еще один язык //добавляем ключ 3
        ////////////
            Dictionary translet = new Dictionary();
            Console.WriteLine("Приветствую вас вы используете словарь. Ниже будет доступен ряд функций которые вы можете выбрать");
            translet.Create();//Создаем перевод 
            FileStream file = new FileStream(translet.language + ".txt", FileMode.OpenOrCreate);//Здесь передаеться путь к файлу и перечисление(указывает на режим доступа к файлу)
                                                                                                //(OpenOrCreate: если файл существует, он открывается, если нет - создается новый)
            translet.Add(translet.dictionary, file);//Добовляем в фаул перевод 
            translet.Print();
            file.Close();
            bool exit = false;
            while (exit != true)
            {
                Console.Write("Выбор действия:   1.Создать еще слово 2.Перевод 3.Выйти \nВаш ответ: ");
                try
                {
                    string c = Console.ReadLine();
                    int choose = Convert.ToInt32(c);
                    switch (choose)
                    {
                        case 1:
                            translet.Create();
                            Console.WriteLine();
                            break;
                        case 2:
                            translet.Print();
                            Console.WriteLine();
                            break;

                        case 3:
                            exit = true;
                            break;
                        ////Добавлял новые слова 
                        //case 4:
                        //    //FileStream fs = new FileStream(translet.language + ".txt", FileMode.Append);
                        //    //StreamWriter sw = new StreamWriter(fs);
                        //    //translet.Add(translet.dictionary, fs, sw);
                        //    //sw.Close();

                        //    break;

                        //case 5:   //////Редактировал
                        ////translet.Edit(translet.dictionary, translet.language + ".txt");
                        ////Console.WriteLine();
                        ////break;

                        //case 6:   //////Удалял бы слова 
                        //    //translet.Delete(translet.dictionary, translet.language + ".txt");
                        //    //Console.WriteLine();
                        //    //break;
                    }
                }
                //////Если выбрали из дипозона, а такого нету то ошибка
                catch (Exception ex) { Console.WriteLine($"\nОшибка!\n{ex.Message}\n"); }
            }
        }
    }
}
