using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace OOP_Labs
{
    class Program
    {
        static void Main(string[] args)
        {
            IniParser ip = new IniParser("1.ini");

            Console.WriteLine(ip.GetStringValue("Sect", "first"));
            Console.WriteLine(ip.GetIntValue("Sect", "kilo"));
            Console.WriteLine(ip.GetDoubleValue("Sect", "555"));

            Console.WriteLine(ip.GetStringValue("Sect2", "first"));
            
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            
            foreach (string Section in ip.GetSections())
            {
                Console.WriteLine(Section);
            }
            
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            
            foreach (string Names in ip.GetNames("Sect"))
            {
                Console.WriteLine(Names);
            }

            Console.ReadKey();
        }
    }


    class IniParser
    {
        private static Dictionary<string, Dictionary<string, string>> maps = new Dictionary<string, Dictionary<string, string>>();
        public IniParser(string filename)
        {
            if (!File.Exists(filename))
                throw new Exception("no such file in directory: " + filename);
            string Section = "Standart";
            maps.Add(Section, new Dictionary<string, string>());

            foreach (string line in File.ReadAllLines(filename))
            {
                string command = line.Split(';')[0];

                if (command.StartsWith("[") && command.EndsWith("]"))
                {
                    Section = command.Substring(1, command.Length - 2);
                    maps.Add(Section, new Dictionary<string, string>());
                }
                else if (command.Length > 0 && command.Split('=').Length > 1)
                {
                    string first = command.Split('=')[0], second = command.Substring(first.Length + 2, command.Length - first.Length - 2);
                    first = first.Substring(0, first.Length - 1);
                    maps[Section].Add(first, second);
                }
            }

            if (maps["Standart"].Count == 0)
            {
                maps.Remove("Standart");
            }
        }

        public string GetStringValue(string Section, string Name)
        {
            if (!maps.ContainsKey(Section))
                throw new Exception("No such section");
            if (!maps[Section].ContainsKey(Name))
                throw new Exception("No such name in section");
            return maps[Section][Name];
        }

        public int GetIntValue(string Section, string Name)
        {
            string str = GetStringValue(Section, Name);
            int res = 0;
            if (!Int32.TryParse(str, out res))
                throw new Exception(Section + " " + Name + " is not a integer number");
            return res;
        }

        public double GetDoubleValue(string Section, string Name)
        {
            string str = GetStringValue(Section, Name);
            double res = 0;
            if (!Double.TryParse(str, out res))
                throw new Exception(Section + " " + Name + " is not a double number");
            return res;
        }

        public string[] GetSections()
        {
            string[] res = new string[maps.Keys.Count];
            int i = 0;
            foreach (string key in maps.Keys)
            {
                res[i++] = key;
            }

            return res;
        }

        public string[] GetNames(string Section)
        {
            if (!maps.ContainsKey(Section))
                throw new Exception("No such section");

            string[] res = new string[maps[Section].Keys.Count];
            int i = 0;
            foreach (string key in maps[Section].Keys)
            {
                res[i++] = key;
            }

            return res;
        }
    }
}