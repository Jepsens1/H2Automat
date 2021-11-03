using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace H2Automat
{
    class Producer
    {
        Random random = new Random(Guid.NewGuid().GetHashCode());
        public void AddToBuffer(Drink[] drinks)
        {
            while (true)
            {
                try
                {
                    //Locks and checks if drink array is full, if true we will wait until consumer consumes a drink"
                    Monitor.Enter(drinks);
                    if (drinks.Length == 8)
                    {
                        Console.WriteLine("Production is full");
                        Monitor.Wait(drinks);
                    }
                    //Creating drinks and checks to see if the drink on index i is null, if true we will create a new drink
                    for (int i = 0; i < drinks.Length; i++)
                    {
                        if (drinks[i] == null)
                        {
                            drinks[i] = new Drink((Type)random.Next(0, 2), random.Next(1, 1000));
                            Console.WriteLine($"Production added {drinks[i].Name} to the automat");
                        }
                    }
                    //Inform all waiting threads that something happened
                    Monitor.PulseAll(drinks);
                    Thread.Sleep(5000);
                }
                finally
                {
                    //Unlocks
                    Monitor.Exit(drinks);
                }

            }
        }
    }
}
