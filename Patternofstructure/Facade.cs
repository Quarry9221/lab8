using System;
using System.Collections.Generic;
using System.Linq;
using DAL.Entities;
namespace Patternofstructure
{
    public class Facade
    {
        private OSN osn;
        private Street street;

        public Facade(OSN os, Street str)
        {
            osn = os;
            street = str;
        }

        public void Operation()
        {
            osn.OSBBID = 1;
            osn.Name = "Вадим";
            osn.Director = "Адмiнiстратор";
            osn.Address = "проспект перемоги";
            Console.WriteLine("Перевiрка першого методу");
            foreach (var prop in typeof(OSN).GetProperties())
            {
                Console.WriteLine(prop.Name + " - " +prop.GetValue(osn));
            }
        }

        public void Operation2()
        {
            osn.Name = "Роман";
            osn.Address = "шахтарська вулиця";
            foreach (var prop in typeof(OSN).GetProperties())
            {
                Console.WriteLine(prop.Name + " - " +prop.GetValue(osn));
            }
        }

        public void Finish()
        {
            Console.WriteLine("Завершення роботи");
        }
    }
}