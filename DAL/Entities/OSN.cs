﻿using System.Collections.Generic;

namespace DAL.Entities
{
    public class OSN
    {
        public int OSBBID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Director { get; set; }
        public List<Street> Streets { get; set; }
        private static OSN instance;
        
        public OSN()
        {}
        public static OSN GetInstance()
        {
            if (instance == null)
            {
                instance = new OSN();
            }
            return instance;
        }

        public void osn1()
        {
            
        }
    }
}