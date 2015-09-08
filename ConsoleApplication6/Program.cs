using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ConsoleApplication6
{
    class Program
    {
        //static Semaphore semaphore1 = new Semaphore(1, 1);
        //static Semaphore semaphore2 = new Semaphore(0, 0);
        //static Semaphore semaphore3 = new Semaphore(0, 0);
        static Semaphore semaphore1;
        static Semaphore semaphore2;
        static Semaphore semaphore3;
        static void Main(string[] args)
        {
            semaphore1 = new Semaphore(1, 1);
            semaphore2 = new Semaphore(0, 1);
            semaphore3 = new Semaphore(0, 1);
            Thread thread1 = new Thread(new ThreadStart(Test1));
            thread1.Start();
            Thread thread2 = new Thread(new ThreadStart(Test2));
            thread2.Start();
            Thread thread3 = new Thread(new ThreadStart(Test3));
            thread3.Start();
            Console.ReadLine();
        }
        static void Test1()
        {
            while (true)
            {
                semaphore1.WaitOne();
                Console.WriteLine("A");
                Thread.Sleep(1000);
                semaphore2.Release();
            }
        }
        static void Test2()
        {
            while (true)
            {
                semaphore2.WaitOne();
                Console.WriteLine("B");
                Thread.Sleep(1000);
                semaphore3.Release();
            }
        }
        static void Test3()
        {
            while (true)
            {
                semaphore3.WaitOne();
                Console.WriteLine("C");
                Thread.Sleep(1000);
                semaphore1.Release();
            }
        }
    }
}
