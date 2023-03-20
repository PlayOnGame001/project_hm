using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exam_test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary translet = new Dictionary();

            Console.WriteLine("Приветствую вас вы используете словарь. Ниже будет доступен ряд функций которые вы можете выбрать");
            bool exit = false;
            while (exit != true)
            {
                Console.Write("Выбор функцию: 1.Выбераем язык 2.Создаем слово 3. Удаляем слово 4.Редактируем перевод слова 5.Показывает все слова 6. Поиск определенного слова 7.Выйти \nВаш ответ: ");
                try
                {
                    string cht = Console.ReadLine();
                    int choose = Convert.ToInt32(cht);
                    switch (choose)
                    {
                        case 1:
                            translet.Create();
                            Console.WriteLine();
                            break;
                        case 2:
                            FileStream fs = new FileStream(translet.language + ".txt", FileMode.Append);//Здесь передаеться путь к файлу и перечисление(указывает на режим доступа к файлу)
                                                                                                        //(OpenOrCreate: если файл существует, он открывается, если нет - создается новый)
                            StreamWriter sw = new StreamWriter(fs);
                            translet.Add(translet.translet, fs, sw);//Добовляем перевод к слову
                            sw.Close();
                            break;
                        case 4:
                            translet.Edit(translet.translet, translet.language + ".txt");
                            Console.WriteLine();
                            break;
                        //case 8:
                        //    translet.Edit(translet.translet, translet.language + ".txt");
                        //    Console.WriteLine();
                        //    break;
                        case 3:
                            translet.Delete(translet.translet, translet.language + ".txt");
                            Console.WriteLine();
                            break;
                        case 5:
                            translet.Print();
                            Console.WriteLine();
                            break;
                        case 6:
                            translet.Find(translet.translet);
                            Console.WriteLine();
                            break;
                        case 7:
                            exit = true;
                            break;
                    }
                }
                catch (Exception ex) { Console.WriteLine($"\nОшибка!\n{ex.Message}\n"); }
            }
        }
    }
}
