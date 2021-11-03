using System;
using System.Threading;

namespace H2Automat
{
    class Program
    {
        static void Main(string[] args)
        {
            //Creating instance of manager, and creating 2 threads
            Manager manager = new Manager();
            Thread producethread = new Thread(manager.GenerateDrink);
            Thread consumethread = new Thread(manager.RemoveDrink);
            producethread.Start();
            consumethread.Start();
            consumethread.Join();
            producethread.Join();

        }
    }
}
