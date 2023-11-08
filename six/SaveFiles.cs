using Newtonsoft.Json;
using pr6;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace six
{
    internal class SaveFiles
    {
        public static List<FullName> Names = new List<FullName>();

        public void Serialize(string path)
        {

            if (path.EndsWith(".txt"))
            {
                string[] massiv = File.ReadAllLines(path);
                   
                for (int i = 0; i < massiv.Length; i += 3)
                {
                    FullName s = new FullName
                        (massiv[i], 
                        massiv[i + 1], 
                        massiv[i + 2]);
                    Names.Add(s);
                }

            }

            else if (path.EndsWith(".xml"))
            {
                XmlSerializer s = new XmlSerializer(typeof(List<FullName>));
                using (FileStream fs = new FileStream(path, FileMode.Open))
                {
                    Names = (List<FullName>)s.Deserialize(fs);
                }
            }

            else if (path.EndsWith(".json"))
            {
                string json = File.ReadAllText(path);
                Names = JsonConvert.DeserializeObject<List<FullName>>(json);
            }

            else
            {
                Console.WriteLine("Вы ввели неверный формат");
                return;
            }

            Console.WriteLine("Сохранить файл в одном из форматов (txt/json/xml) - F1. Выход из программы - Escape");
            Console.WriteLine("Файл: ");
            string[] massiv1 = File.ReadAllLines(path);
            foreach (var i in massiv1)
            {
                Console.WriteLine(i);
            }

            Deserilize(Names);
        }
        private void Deserilize(List<FullName> Names)
        {
            ConsoleKeyInfo keyyy = Console.ReadKey();
            if (keyyy.Key == ConsoleKey.F1)
            {
                Console.Clear();
                Console.WriteLine("Введите путь для сохранения файла: ");
                string ptwo = Console.ReadLine();
                if (ptwo.EndsWith(".txt"))
                {
                    string str = "";
                    foreach (var name in Names)
                    {
                        str += name.Surname + "\n";
                        str += name.Name + "\n";
                        str += name.MiddleName + "\n";
                    }
                    File.WriteAllText(ptwo, str);
                }

                else if (ptwo.EndsWith(".xml"))
                {
                    XmlSerializer s = new XmlSerializer(typeof(List<FullName>));
                    using (FileStream fs = new FileStream(ptwo, FileMode.OpenOrCreate))
                    {
                        s.Serialize(fs, Names);
                    }
                }

                else if (ptwo.EndsWith(".json"))
                {
                    string json = JsonConvert.SerializeObject(Names);
                    File.WriteAllText(ptwo, json);
                }

                else
                {
                    Console.WriteLine("Вы ввели неверный формат");
                    return;
                }
                Console.WriteLine("Файл был сохранён");
            }

            else if (keyyy.Key == ConsoleKey.Escape)
            {
                Environment.Exit(0);
            }

            else 
            {
                Console.WriteLine("Такой функции нет");
                Environment.Exit(0);
            }


        }
    }
}
