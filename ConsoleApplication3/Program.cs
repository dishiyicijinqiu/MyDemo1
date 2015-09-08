using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ConsoleApplication3
{
    class Program
    {
        private static ReaderWriterLock m_readerWriterLock = new ReaderWriterLock();
        private static int m_int = 0;
        [STAThread]
        static void Main(string[] args)
        {
            Thread readThread = new Thread(new ThreadStart(Read));
            readThread.Name = "ReadThread1";
            Thread readThread2 = new Thread(new ThreadStart(Read));
            readThread2.Name = "ReadThread2";
            Thread writeThread = new Thread(new ThreadStart(Writer));
            writeThread.Name = "WriterThread";
            readThread.Start();
            readThread2.Start();
            writeThread.Start();
            readThread.Join();
            readThread2.Join();
            writeThread.Join();

            Console.ReadLine();
        }
        private static void Read()
        {
            while (true)
            {
                Console.WriteLine("ThreadName " + Thread.CurrentThread.Name + " AcquireReaderLock");
                m_readerWriterLock.AcquireReaderLock(10000);
                Console.WriteLine(String.Format("ThreadName : {0} m_int : {1}", Thread.CurrentThread.Name, m_int));
                m_readerWriterLock.ReleaseReaderLock();
            }
        }

        private static void Writer()
        {
            while (true)
            {
                Console.WriteLine("ThreadName " + Thread.CurrentThread.Name + " AcquireWriterLock");
                m_readerWriterLock.AcquireWriterLock(1000);
                Interlocked.Increment(ref m_int);
                Thread.Sleep(5000);
                m_readerWriterLock.ReleaseWriterLock();
                Console.WriteLine("ThreadName " + Thread.CurrentThread.Name + " ReleaseWriterLock");
            }
        }
    }
}
