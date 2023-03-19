using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace exam_test
{
    interface CreateTranslater  //Создаем интерфейс словаря создание слов 
    {
        void Create();
    }
    interface EditTranslater    // Интерфейс словоря с дополнением 
    {
        void Add(Dictionary<string, string> perevod, FileStream file, StreamWriter sw);//добавляем слово 
        void Edit(Dictionary<string, string> perevod, string file);//Редактируем слово и его перевод 
        void Delete(Dictionary<string, string> perevod, string file);//Удаляем слово 
        void Find(Dictionary<string, string> perevod);// Ищем слово по ключу 
    }
    interface PrintTranslater  // Создание интерфейса с печаткой словаря
    {
        void Print();
    }

    //interface ClearDictionary // Удаляем все объекты из определенного словаря
    //{
    //    void Clear(); 
    //}
    class Dictionary : CreateTranslater, EditTranslater, PrintTranslater
    {
        public Dictionary<string, string> translet;
        public string language; //Язык который мы выберем 
        //public string e;
        //public string r;
        public Dictionary() { }
        public Dictionary(Dictionary<string, string> slovo)
        {
            translet = slovo;
        }
        //Создаем словарь
        public void Create()
        {
            translet = new Dictionary<string, string>();//Язык который мы выберем щапишется в словарь
            Console.WriteLine($"Выберите словерь из предложенных 1)English, 2)Russian ");
            Console.Write("Введите тип переводчика: ");
            language = Console.ReadLine();
            bool Flag = false;
            //if (Flag == false)
            //{
                FileStream file = new FileStream(language + ".txt", FileMode.OpenOrCreate);//Создаем словарь
                file.Close();
            //}
            //else if (language == "English" && Flag == true)  
            //{
            //    Console.WriteLine("Уже создан словарь");
            //}
            //else if (language == "Russian" && Flag == false)
            //{

            //}
            //FileStream file = new FileStream(language + ".txt", FileMode.OpenOrCreate);//Создаем словарь 
            //file.Close();

                //Console.WriteLine($"Вы выбрали язык {language}, вы уверены? ");
                ///////Идея в том чтобы можно было вернуться если выбрал не правельный словарь 
                //if ()
                //{
                //    Console.WriteLine("Хорошо");
                //}
                //else
                //{
                //    Console.WriteLine("Выберите другой");
                //    return (dictionary);
                //}
                ///////
        }
        /////Добавляем слово и его перевод в словарь 
        public void Add(Dictionary<string, string> perevod, FileStream file, StreamWriter sw)
        {
            Console.Write("Введите слово: ");//Тут все просто вводим слово 
            string slovo = Console.ReadLine();//Запись в веденого слова 
            Console.Write("Введите перевод слова и все его возможное варинаты: ");//Тут все просто вводим слово тут перевод этого слова
            string translet_slovo = Console.ReadLine();//Добавления слова и его перевод
            perevod.Add(slovo, translet_slovo);//
            sw.WriteLine($"{slovo} - {translet_slovo}");//Слово из словаря и его перевод 
            ////foreach (var item in translate)//
            ////{
            ////    write_file.Write($"{item.Key} - перевод - {item.Value}");//Слово под ключом которое записали и перевод слова под Value запись в файл
            ////}
        }

        public void Edit(Dictionary<string, string> perevod, string file)
        {
            Console.Write("Введите слово для того чтобы изменить его перевод: ");
            string poisk = Console.ReadLine();
            if (perevod.ContainsKey(poisk))
            {
                var lines = File.ReadAllLines(file).ToList();
                int index = lines.IndexOf(poisk + " - " + perevod[poisk]);// Ищет слово и показывает его перевод 

                Console.Write("Введите новое слово: ");
                string word = Console.ReadLine();
                Console.Write("Введите перевод нового слова: ");
                string translate = Console.ReadLine();
                perevod.Remove(poisk);
                lines.RemoveAt(index);

                string save = null;
                foreach (var i in perevod)
                {
                    save += $"{i.Key} - {i.Value}\n";// находит слово по ключу и показывает его значение 
                }
                File.WriteAllLines($"{file}", lines);
                perevod.Add(word, translate);
                string text = null;
                foreach (var i in perevod)
                {
                    text += $"{i.Key} - {i.Value}\n";
                }
                File.WriteAllText(file, text);
            }
            else { Console.WriteLine("Это слово не было найдено!"); }
        }

        public void Delete(Dictionary<string, string> perevod, string file)
        {
            Console.Write("Введите слово для его удаления: ");
            string word = Console.ReadLine();
            var lines = File.ReadAllLines(file).ToList();
            int index = lines.IndexOf(word + " - " + perevod[word]);

            if (perevod.ContainsKey(word))
            {
                perevod.Remove(word);
                lines.RemoveAt(index);
                File.WriteAllLines(file, lines);
            }
        }
        public void Find(Dictionary<string, string> perevod)
        {
            if (perevod != null)
            {
                Console.Write("Введите слово чтобы найти его: ");
                string word = Console.ReadLine();
                if (perevod.ContainsKey(word))
                {
                    Console.WriteLine($"{word} - {perevod[word]}");
                }
                else
                {
                    foreach (var key in perevod.Keys)
                    {
                        if (perevod[key] == word)
                        {
                            Console.WriteLine($"{key} - {perevod[key]}");
                        }
                    }
                }
            }
        }
        public void Print()
        {
            Console.WriteLine($"  Язык: {language}");
            StreamReader sr = new StreamReader(language + ".txt", Encoding.UTF8);
            Console.WriteLine(sr.ReadToEnd());
            sr.Close();
        }
        //StreamReader sr = new StreamReader(language + ".txt", Encoding.UTF8);
        //Console.WriteLine(sr.ReadToEnd());
        //sr.Close();
    }
}



