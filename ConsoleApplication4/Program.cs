using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ConsoleApplication4
{

    class Program
    {
        static AutoResetEvent _mre = new AutoResetEvent(true);
        static void Main(string[] args)
        {
            Thread[] _threads = new Thread[3];
            for (int i = 0; i < _threads.Count(); i++)
            {
                _threads[i] = new Thread(ThreadRun);
                _threads[i].Start();
            }

        }

        static void ThreadRun()
        {
            int _threadID = 0;
            while (true)
            {
                _mre.WaitOne();
                _threadID = Thread.CurrentThread.ManagedThreadId;
                Console.WriteLine("current Tread is " + _threadID);
                Thread.Sleep(TimeSpan.FromSeconds(2));

            }
        }
    }
    //class Program
    //{
    //    static AutoResetEvent autoEvent;
    //    static void DoWork()
    //    {
    //        Console.WriteLine(" worker thread started, now waiting on event");
    //        autoEvent.WaitOne();
    //        Console.WriteLine(" worker thread reactivated, now exiting");
    //    }

    //    [STAThread]
    //    static void Main(string[] args)
    //    {
    //        autoEvent = new AutoResetEvent(false);
    //        Console.WriteLine("main thread starting worker thread");
    //        Thread t = new Thread(new ThreadStart(DoWork));
    //        t.Start();

    //        Console.WriteLine("main thrad sleeping for 1 second");
    //        Thread.Sleep(1000);

    //        Console.WriteLine("main thread signaling worker thread");
    //        autoEvent.Set();

    //        Console.ReadLine();
    //    }
    //}
}
