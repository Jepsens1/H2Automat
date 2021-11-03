using System;
using System.Collections.Generic;
using System.Text;

namespace H2Automat
{
    public enum Type
    {
        Øl,
        Sodavand
    }
    class Drink
    { 
        public Type Name { get; set; }
        public int number { get; set; }

        public Drink(Type type, int _number)
        {
            Name = type;
            number = _number;
        }
    }
}
