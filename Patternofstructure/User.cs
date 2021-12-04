using System;
using System.Collections.Generic;
using System.Linq;
using DAL.Entities;
namespace Patternofstructure
{
    class User
    {
        static void Main(string[] args)
        {
            Facade facade = new Facade(new OSN(), new Street());
            facade.Operation();
            facade.Operation2();
            facade.Finish();
        }
    }
}