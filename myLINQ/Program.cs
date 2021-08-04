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
            List<BadGuy> badGuys = new List<BadGuy>();
            
            badGuys.Add(new BadGuy("баба-Яга", Prison.Free, "медицинское шарлатанство", 160, 40, Race.Human));
            badGuys.Add((new BadGuy("водяной", Prison.Free, "тунеядство", 170, 100, Race.Halfblood)));
            badGuys.Add(new BadGuy("змей горыныч", Prison.Free, "пиромания", 400, 600, Race.Amimal));
            badGuys.Add(new BadGuy("золотой петушок", Prison.Prisoner, "цареубийство", 30, 7, Race.Amimal));
            badGuys.Add(new BadGuy("Иван дурак", Prison.Free, "нетрудовые доходы", 180, 80, Race.Human));
            badGuys.Add((new BadGuy("кикимора", Prison.Free, "тунеядство", 150, 45, Race.Halfblood)));
            badGuys.Add(new BadGuy("колобок", Prison.Prisoner, "бродяжничество", 25, 2, Race.Halfblood));
            badGuys.Add((new BadGuy("конёк-горбунок", Prison.Free, "оранжевые революции", 100, 60, Race.Amimal)));
            badGuys.Add((new BadGuy("кощей бесмертный", Prison.Prisoner, "превышение пенсионного возраста", 180, 40, Race.Human)));
            badGuys.Add(new BadGuy("серый волк", Prison.Free, "порча свинского жилья", 60, 70, Race.Amimal));
            badGuys.Add(new BadGuy("кот баюн", Prison.Free, "тунеядство", 20, 5, Race.Amimal));
            badGuys.Add(new BadGuy("леший", Prison.Free, "тунеядство", 150, 50, Race.Halfblood));
            badGuys.Add(new BadGuy("соловей разбойник", Prison.Prisoner, "громкий художественный свист", 170, 55, Race.Human));
            badGuys.Add(new BadGuy("царевна лягушка", Prison.Free, "оборотничество", 15, 1, Race.Amimal));
            badGuys.Add(new BadGuy("шапокляк", Prison.Free, "мелкое хулиганство", 155, 45, Race.Human));
            badGuys.Add(new BadGuy("Карабас Барабас", Prison.Free, "рабский детский труд", 175, 120, Race.Human));
            badGuys.Add(new BadGuy("Маша", Prison.Prisoner, "медвежачничество", 120, 40, Race.Human));

            var nonPrisoner = from guy in badGuys
                where guy.Prison == Prison.Free
                select guy;

            List<BadGuy> filteredGuys = new List<BadGuy>();

            filteredGuys = nonPrisoner.ToList();

            foreach (var guy in nonPrisoner)
            {
                Console.WriteLine($"{guy.Moniker}");
            }

            Console.WriteLine($"-------------------------");
            for (int i = 0; i < filteredGuys.Count; i++)
            {
                Console.WriteLine($"{filteredGuys[i].Moniker} - {filteredGuys[i].Article}");
            }
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