using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace H2Automat
{
    class Consumer
    {
        Random r = new Random(Guid.NewGuid().GetHashCode());
        public void Remove(Drink[] drinks)
        {
            while (true)
            {
                //gets a random number to remove from the array
                int numb = r.Next(0, 7);
                try
                {
                    //Locks
                    Monitor.Enter(drinks);
                    //If the array is empty we will wait and say its empty
                    if (drinks.Length == 0)
                    {
                        Monitor.Wait(drinks);
                        Console.WriteLine("Empty");
                    }
                    //If the drink from the random number is not null we will consume that drink and make it null
                    if (drinks[numb] != null)
                    {
                        Console.WriteLine($"Consumer consumed {drinks[numb].Name}");
                        drinks[numb] = null;
                    }
                    //Inform waiting threads, that something happened
                    Monitor.PulseAll(drinks);
                    //Thread.Sleep(1000);
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
