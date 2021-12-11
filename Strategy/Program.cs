using System;
using DAL.Entities;
using DAL.Repositories.Impl;

namespace Strategy
{
    
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Шаблон - стратегiя");
            OSN osn = new OSN(1, "Нововолинський орган самоорганізації населення",
                "Проспект перемоги", "Золотько Вадим", new HouseAdd());
            osn.Add();
            osn.Adder = new StreetAdd();
            osn.Add();
        }
    }
}

interface IAdder
{
    void Add();
}

class HouseAdd : IAdder
{
    public void Add()
    {
        Console.WriteLine("Додавання будинку");
    }
}
class StreetAdd : IAdder
{
    public void Add()
    {
        Console.WriteLine("Додавання вулицi");
    }
}
class OSN
{
    public int OSNID;
    public string Name;
    public string Address;
    public string Director;

    public OSN(int osnid, string name, string address, string director, IAdder add)
    {
        this.OSNID = osnid;
        this.Name = name;
        this.Address = address;
        this.Director = director;
        Adder = add;
    }
    public IAdder Adder { private get; set; }

    public void Add()
    {
        Adder.Add();
    }
}