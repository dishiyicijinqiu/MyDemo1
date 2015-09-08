using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main()
        {
        Flag:
            // Create the worker thread object. This does not start the thread.
            Worker workerObject = new Worker();
            Thread[] threads = new Thread[10];
            for (int i = 0; i < threads.Length; i++)
            {
                threads[i] = new Thread(workerObject.DoWork);
                threads[i].Start();
            }

            Console.WriteLine("Main thread: starting worker thread...");
            bool isallalive = false;
            while (!isallalive)
            {
                bool isalive = true;
                for (int i = 0; i < threads.Length; i++)
                {
                    if (!threads[i].IsAlive)
                    {
                        isalive = false;
                        break;
                    }
                }
                isallalive = isalive;
            }

            // Put the main thread to sleep for 1 millisecond to
            // allow the worker thread to do some work.
            Thread.Sleep(2);

            // Request that the worker thread stop itself.
            //workerObject.RequestStop();

            // Use the Thread.Join method to block the current thread 
            // until the object's thread terminates.
            for (int i = 0; i < threads.Length; i++)
            {
                threads[i].Join();
            }
            Console.WriteLine("Main thread: worker thread has terminated.");
            string read = Console.ReadLine();
            if (read == "c")
                goto Flag;
        }
    }
    public class Worker
    {
        // This method is called when the thread is started.
        public void DoWork()
        {
            while (execcount == execcounttest)
            {
                Console.WriteLine("Worker thread: working...");
                execcount++;
                execcounttest++;
            }
            //if (execcount != execcounttest)
            Console.WriteLine("fffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffff");
            //Console.WriteLine("execcount is {0},execcounttest is {1}.", execcount, execcounttest);
        }
        public void RequestStop()
        {
            _shouldStop = true;
        }
        // Keyword volatile is used as a hint to the compiler that this data
        // member is accessed by multiple threads.
        private volatile bool _shouldStop;
        private volatile int execcount;
        private int execcounttest;
    }
}
