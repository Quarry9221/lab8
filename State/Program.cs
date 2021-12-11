using System;

namespace State
{
    enum AdvState
    {
        NEW,
        NONPUBLISHED,
        PUBLISHED,
        DELETED,
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            Advertisment advertisment = new Advertisment(AdvState.NEW);
            advertisment.Creator();
            advertisment.Publisher();
        }
    }

    class Advertisment
    {
        private int check;
        public AdvState State { get; set; }

        public Advertisment(AdvState as_)
        {
            State = as_;
        }

        public void Creator()
        {
            if (State == AdvState.NEW)
            {
                Console.WriteLine("Створення нового оголошення");
                State = AdvState.NONPUBLISHED;
            }
            else if (State == AdvState.NONPUBLISHED)
            {
                Console.WriteLine("Перехід оголошення в стан невідправленого");
                Console.WriteLine("Чи хочете ви відправити оголошення?");
                check = Convert.ToInt32(Console.ReadLine());
                if (check == 1)
                {
                    State = AdvState.PUBLISHED;
                }
                else
                {
                    State = AdvState.NONPUBLISHED;
                }
            }
            else if (State == AdvState.PUBLISHED)
            {
                Console.WriteLine("Оголошення опубліковане");
            }
        }

        public void Publisher()
        {
            if (State == AdvState.NONPUBLISHED)
            {
                Console.WriteLine("Перехід оголошення в стан невідправленого");
                Console.WriteLine("Чи хочете ви відправити оголошення?");
                Console.WriteLine("1 - Опублікувати, 2 - Видалити");
                check = Convert.ToInt32(Console.ReadLine());
                if (check == 1)
                {
                    Console.WriteLine("Оголошення опубліковане");
                    State = AdvState.PUBLISHED;
                }
                else if (check == 2)
                {
                    Console.WriteLine("Оголошення Видалене");
                    State = AdvState.DELETED;
                }
            }
        }


    }
}