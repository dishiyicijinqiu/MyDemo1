using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

namespace ConsoleApplication2
{
    /// <summary>  
    /// 一个类似于自旋锁的类，也类似于对共享资源的访问机制  
    /// 如果资源已被占有，则等待一段时间再尝试访问，如此循环，直到能够获得资源的使用权为止  
    /// </summary>  
    public class SpinLock
    {
        //资源状态锁，0--未被占有， 1--已被占有  
        private int theLock = 0;
        //等待时间  
        private int spinWait;

        public SpinLock(int spinWait)
        {
            this.spinWait = spinWait;
        }

        /// <summary>  
        /// 访问  
        /// </summary>  
        public void Enter()
        {
            //如果已被占有，则继续等待  
            while (Interlocked.CompareExchange(ref theLock, 1, 0) == 1)
            {
                Thread.Sleep(spinWait);
            }
        }

        /// <summary>  
        /// 退出  
        /// </summary>  
        public void Exit()
        {
            //重置资源锁  
            Interlocked.Exchange(ref theLock, 0);
        }
    }

    /// <summary>  
    /// 自旋锁的管理类
    /// </summary>  
    public class SpinLockManager : IDisposable  //Disposable接口,实现一种非委托资源回收机制，可看作显示回收资源。任务执行完毕后，会自动调用Dispose()里面的方法。  
    {
        private SpinLock spinLock;

        public SpinLockManager(SpinLock spinLock)
        {
            this.spinLock = spinLock;
            spinLock.Enter();
        }

        //任务结束后，执行Dispose()里面的方法  
        public void Dispose()
        {
            spinLock.Exit();
        }
    }

    /// <summary>  
    /// 主类  
    /// </summary>  
    class Program
    {
        private static Random rnd = new Random();
        //创建资源锁，管理资源的访问  
        private static SpinLock logLock = new SpinLock(10);
        //以写的方式打开文件，选择追加模式  
        private static StreamWriter fsLog = new StreamWriter(File.Open("Log.txt", FileMode.Append, FileAccess.Write, FileShare.None));
        /// <summary>  
        /// 写入文件  
        /// </summary>  
        private static void RndThreadFunc()
        {
            //创建SpinLockManager，并调用Dispose()方法。这里采用using字段,是调用Dispose()方法的形式。  
            using (new SpinLockManager(logLock))
            {
                //写入文件  
                fsLog.WriteLine("Thread Starting");
                fsLog.Flush();
            }

            int time = rnd.Next(10, 200);
            Thread.Sleep(time);

            using (new SpinLockManager(logLock))
            {
                fsLog.WriteLine("Thread Exiting");
                fsLog.Flush();
            }
        }

        static void Main()
        {
            Thread[] rndThreads = new Thread[5];

            //创建5个RndThreadFunc的线程  
            for (int i = 0; i < 5; i++)
            {
                rndThreads[i] = new Thread(new ThreadStart(RndThreadFunc));
                rndThreads[i].Start();
            }
        }
    }
}
