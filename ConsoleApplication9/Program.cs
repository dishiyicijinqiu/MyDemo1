using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ConsoleApplication9
{
    class Program
    {

        const int END_PRODUCE_NUMBER = 8;  //生产产品个数  
        const int BUFFER_SIZE = 4;          //缓冲区个数  
        static int[] g_Buffer = new int[BUFFER_SIZE];          //缓冲池  
        static int g_i, g_j;
        //信号量与关键段  
        //CRITICAL_SECTION g_cs; 
        // C#中没有关键段，我用Mutex来实现
        static Mutex mutex;
        //HANDLE g_hSemaphoreBufferEmpty, g_hSemaphoreBufferFull;  
        static Semaphore g_hSemaphoreBufferEmpty, g_hSemaphoreBufferFull;

        static void ProducerThreadFun()
        {
            for (int i = 1; i <= END_PRODUCE_NUMBER; i++)
            {
                //等待有空的缓冲区出现  
                g_hSemaphoreBufferEmpty.WaitOne();
                //互斥的访问缓冲区  
                mutex.WaitOne();
                g_Buffer[g_i] = i;
                Console.WriteLine("生产者在缓冲池第{0}个缓冲区中投放数据{1}", g_i, g_Buffer[g_i]);
                g_i = (g_i + 1) % BUFFER_SIZE;
                mutex.ReleaseMutex();
                //通知消费者有新数据了  
                g_hSemaphoreBufferFull.Release();
            }
            Console.WriteLine("生产者完成任务，线程结束运行");
        }
        static void ConsumerThreadFun()
        {
            while (true)
            {
                //等待非空的缓冲区出现  
                g_hSemaphoreBufferFull.WaitOne();
                //互斥的访问缓冲区  
                mutex.WaitOne();
                Console.ForegroundColor = ConsoleColor.Green; //设置前景色，即字体颜色

                Console.WriteLine("  编号为{0}的消费者从缓冲池中第{1}个缓冲区取出数据{2}", Thread.CurrentThread.ManagedThreadId, g_j, g_Buffer[g_j]);
                Console.ForegroundColor = ConsoleColor.Red | ConsoleColor.Green | ConsoleColor.Blue;
                if (g_Buffer[g_j] == END_PRODUCE_NUMBER)//结束标志  
                {
                    mutex.ReleaseMutex();
                    //通知其它消费者有新数据了(结束标志)  
                    g_hSemaphoreBufferEmpty.Release();
                    break;
                }
                g_j = (g_j + 1) % BUFFER_SIZE;
                mutex.ReleaseMutex();

                Thread.Sleep(50); //some other work to do  
                g_hSemaphoreBufferEmpty.Release();
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("  编号为{0}的消费者收到通知，线程结束运行", Thread.CurrentThread.ManagedThreadId);
            Console.ForegroundColor = ConsoleColor.Red | ConsoleColor.Green | ConsoleColor.Blue;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("  生产者消费者问题   1生产者 2消费者 4缓冲区");
            Console.WriteLine(" -- by MoreWindows( http://blog.csdn.net/MoreWindows ) --");
            mutex = new Mutex();
            //初始化信号量,一个记录有产品的缓冲区个数,另一个记录空缓冲区个数.  
            g_hSemaphoreBufferEmpty = new Semaphore(4, 4);
            g_hSemaphoreBufferFull = new Semaphore(0, 4);
            g_i = 0;
            g_j = 0;
            Thread[] threads = new Thread[3];
            threads[0] = new Thread(new ThreadStart(ProducerThreadFun));
            threads[1] = new Thread(new ThreadStart(ConsumerThreadFun));
            threads[2] = new Thread(new ThreadStart(ConsumerThreadFun));
            for (int i = 0; i < threads.Length; i++)
            {
                threads[i].Start();
            }
            Thread.Sleep(100);
            for (int i = 0; i < threads.Length; i++)
            {
                threads[i].Join();
            }
            Console.ReadLine();
        }
    }
}
