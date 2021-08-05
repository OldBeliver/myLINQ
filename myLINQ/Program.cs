using System;
using System.Collections.Generic;
using System.ComponentModel;
using  System.Linq;
using System.Runtime.InteropServices;

namespace myLINQ
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Archive archive = new Archive();
            archive.Search();
        }
    }

    class Archive
    {
        private List<BadGuy> _badGuys;
        
        public Archive()
        {
            _badGuys = new List<BadGuy>();
            
            LoadBadGuys();
        }

        public void LoadBadGuys()
        {
            _badGuys.Add(new BadGuy("баба Яга", Prison.Free, "медицинское шарлатанство", 160, 40, Race.Human));
            _badGuys.Add((new BadGuy("водяной", Prison.Free, "затопление соседей", 170, 100, Race.Halfblood)));
            _badGuys.Add(new BadGuy("змей горыныч", Prison.Free, "пиромания", 400, 600, Race.Amimal));
            _badGuys.Add(new BadGuy("золотой петушок", Prison.Prisoner, "цареубийство", 30, 7, Race.Amimal));
            _badGuys.Add(new BadGuy("Иван дурак", Prison.Free, "нетрудовые доходы", 180, 80, Race.Human));
            _badGuys.Add((new BadGuy("кикимора", Prison.Free, "тунеядство", 150, 45, Race.Halfblood)));
            _badGuys.Add(new BadGuy("Колобок", Prison.Prisoner, "бродяжничество", 25, 2, Race.Halfblood));
            _badGuys.Add((new BadGuy("конёк-горбунок", Prison.Free, "оранжевые революции", 100, 60, Race.Amimal)));
            _badGuys.Add((new BadGuy("Кощей бесмертный", Prison.Prisoner, "превышение пенсионного возраста", 180, 40, Race.Human)));
            _badGuys.Add(new BadGuy("серый волк", Prison.Free, "порча свинского жилья", 60, 70, Race.Amimal));
            _badGuys.Add(new BadGuy("кот Баюн", Prison.Free, "бытовой сепаратизм", 20, 5, Race.Amimal));
            _badGuys.Add(new BadGuy("леший", Prison.Free, "мелкое хулиганство", 150, 50, Race.Halfblood));
            _badGuys.Add(new BadGuy("соловей разбойник", Prison.Prisoner, "громкий художественный свист", 170, 55, Race.Human));
            _badGuys.Add(new BadGuy("царевна лягушка", Prison.Free, "оборотничество", 15, 1, Race.Amimal));
            _badGuys.Add(new BadGuy("Шапокляк", Prison.Free, "крысятничество", 155, 45, Race.Human));
            _badGuys.Add(new BadGuy("Карабас Барабас", Prison.Free, "рабский детский труд", 175, 120, Race.Human));
            _badGuys.Add(new BadGuy("Маша", Prison.Prisoner, "медвежатничество", 120, 40, Race.Human));
        }

        public void Search()
        {
            bool isOpen = true;
            
            while (isOpen)
            {   
                int height = 0;
                int weight = 0;
                int number = 0;
                Race race;
                int heightDeviation = 20;
                int weightDeviation = 20;
            
                Console.WriteLine($"Сервис поиска преступника по приметам");
                Console.WriteLine($"-------------------------------------");
                
                Console.Write($"Введите примерный рост, в см: ");
                if (GetNumber(out number))
                {
                    if (number > 0)
                    {
                        height = number;
                    }
                }
                
                Console.Write($"Введите примерный вес, в кг: ");
                if (GetNumber(out number))
                {
                    if (number > 0)
                    {
                        weight = number;
                    }
                }
                
                Console.WriteLine($"Укажите расу:");
                Console.WriteLine($"1 - человек, 2 - полукровка, 3 - животное");
                switch (Console.ReadLine())
                {
                    case "1":
                        race = Race.Human;
                       break;
                    case "2":
                        race = Race.Halfblood;
                        break;
                    case "3":
                        race = Race.Amimal;
                        break;
                    default:
                        race = Race.Human;
                        break;
                }

                Console.WriteLine($"поиск осуществлен с учетом разброса +- {heightDeviation} кг, +- {weightDeviation} см");
                Console.WriteLine($"----------------------------------");
                var extracted = from BadGuy badGuy in _badGuys
                    where (badGuy.Height > height-heightDeviation && badGuy.Height < height+heightDeviation)
                    where (badGuy.Weight > weight-weightDeviation && badGuy.Weight < weight+weightDeviation)
                    where badGuy.Race == race
                    where badGuy.Prison == Prison.Free
                    select badGuy;

                foreach (var guy in extracted)
                {
                    Console.WriteLine($"{guy.Moniker} - {guy.Article}");
                }

                Console.WriteLine($"----------------------------------");
                Console.WriteLine($"enter - новый поиск\nexit - выход");

                if (Console.ReadLine() == "exit")
                {
                    isOpen = false;
                }
                Console.Clear();
            }
        }
        
        private bool GetNumber(out int number)
        {
            bool result = int.TryParse(Console.ReadLine(), out number);

            return result;
        }
    }
    class BadGuy
    {   
        public string Moniker { get; private set; }
        public Prison Prison { get; private set; }
        public string Article { get; private set; } 
        public int Height { get; private set; }
        public int Weight { get; private set; }
        public Race Race { get; private set; }

        public BadGuy(string moniker, Prison prison, string article, int height, int weight, Race race)
        {
            Moniker = moniker;
            Prison = prison;
            Article = article;
            Height = height;
            Weight = weight;
            Race = race;
        }
    }

    enum Prison
    {
        Prisoner,
        Free
    }
    
    enum Race
    {
        Human,
        Halfblood,
        Amimal
    }
}