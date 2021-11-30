using System;
using System.Collections.Generic;
using System.Linq;
using DAL.Entities;

namespace Patterns
{
    class Program
    {
        static void Main(string[] args)
        {
            OSN.GetInstance().OSBBID = 1;
            OSN.GetInstance().Name = "Vadym";
            OSN.GetInstance().Address = "Shevcneka";
            OSN.GetInstance().Director = "Admin";
            OSN.GetInstance().Streets = new List<Street>();
            OSN.GetInstance().Streets.Add(new Street());
            
            Console.WriteLine("SingleTon");
            Console.WriteLine($"OSNID:{OSN.GetInstance().OSBBID} Name:{OSN.GetInstance().Name} Address:{OSN.GetInstance().Address} Director:{OSN.GetInstance().Director}");
            

            var street = OSN.GetInstance().Streets.First();
            street.Description = "Desc";
            street.Name = "Shevchenka";
            street.StreetID = 1;
            street.OSNID = 1;
            Console.WriteLine("Prototype");
           Console.WriteLine($"OSNID:{OSN.GetInstance().OSBBID} Name:{OSN.GetInstance().Name} Address:{OSN.GetInstance().Address} Director:{OSN.GetInstance().Director} Street:{street.Name}");
            var cloneStreet = street.Clone();
            cloneStreet.Description = "Desc2";
            Console.WriteLine(street.Description == cloneStreet.Description);
            Console.WriteLine(cloneStreet.Description);
        }
    }
}