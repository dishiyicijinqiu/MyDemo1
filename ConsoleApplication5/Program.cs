using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ConsoleApplication5
{
    //编写一个程序，开启3个线程，这3个线程的ID分别为A、B、C，每个线程将自己的ID在屏幕上打印10遍，要求输出结果必须按ABC的顺序显示；如：ABCABC….依次递推。
    class Program
    {
        static AutoResetEvent auto1 = new AutoResetEvent(false);
        static AutoResetEvent auto2 = new AutoResetEvent(false);
        static AutoResetEvent auto3 = new AutoResetEvent(false);
        static AutoResetEvent auto = new AutoResetEvent(false);
        static void Main(string[] args)
        {
            Thread thread1 = new Thread(new ThreadStart(Test1));
            thread1.Start();
            Thread thread2 = new Thread(new ThreadStart(Test2));
            thread2.Start();
            Thread thread3 = new Thread(new ThreadStart(Test3));
            thread3.Start();

            Thread threadRun = new Thread(new ThreadStart(Run));
            threadRun.Start();
            string str = Console.ReadLine();
        }
        static void Run()
        {
            while (true)
            {
                for (int i = 0; i < 3; i++)
                {
                    if (i == 0)
                        auto1.Set();
                    else if (i == 1)
                        auto2.Set();
                    else if (i == 2)
                        auto3.Set();
                    auto.WaitOne();
                }
            }
        }
        static void Test1()
        {
            while (true)
            {
                auto1.WaitOne();
                Thread.Sleep(200);
                Console.WriteLine("A");
                auto.Set();
            }
        }
        static void Test2()
        {
            while (true)
            {
                auto2.WaitOne();
                Thread.Sleep(200);
                Console.WriteLine("B");
                auto.Set();
            }
        }
        static void Test3()
        {
            while (true)
            {
                auto3.WaitOne();
                Thread.Sleep(200);
                Console.WriteLine("C");
                auto.Set();
            }
        }
    }
}
