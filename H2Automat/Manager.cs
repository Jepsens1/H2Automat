using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace H2Automat
{
    class Manager
    {
        Producer producer = new Producer();
        Consumer consumer = new Consumer();
        Drink[] drinks = new Drink[8];

        public void GenerateDrink()
        {
            producer.AddToBuffer(drinks);
        }
        public void RemoveDrink()
        {
            consumer.Remove(drinks);
        }
    }
}
