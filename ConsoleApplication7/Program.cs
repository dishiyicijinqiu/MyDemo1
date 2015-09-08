using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ConsoleApplication7
{
    class Program
    {
        static void Main(string[] args)
        {
            object lockobj = new object();
            SuperMarket market = new SuperMarket();
            Producer p1 = new Producer("太阳");
            Producer p2 = new Producer("湖人");
            Consume c1 = new Consume("c姚明");
            Consume c2 = new Consume("c科比");
            Consume c3 = new Consume("c乔丹");
            Thread threadProducer1 = new Thread(new ParameterizedThreadStart(p1.CreateGood));
            threadProducer1.Start(new object[] { market, lockobj });
            Thread threadProducer2 = new Thread(new ParameterizedThreadStart(p2.CreateGood));
            threadProducer2.Start(new object[] { market, lockobj });

            Thread threadConsume1 = new Thread(new ParameterizedThreadStart(c1.GetGood));
            threadConsume1.Start(new object[] { market, lockobj });
            Thread threadConsume2 = new Thread(new ParameterizedThreadStart(c2.GetGood));
            threadConsume2.Start(new object[] { market, lockobj });
            Thread threadConsume3 = new Thread(new ParameterizedThreadStart(c3.GetGood));
            threadConsume3.Start(new object[] { market, lockobj });
            threadProducer1.Join();
            threadProducer2.Join();
            threadConsume1.Join();
            threadConsume2.Join();
            threadConsume3.Join();
        }
    }

    public class SuperMarket
    {
        public Queue<Good> Goods = new Queue<Good>();
    }

    public class Good
    {
        public string SN { get; set; }
        public override string ToString()
        {
            return SN;
        }
    }

    public class Producer
    {
        string ProducerName;
        public Producer(string name)
        {
            ProducerName = name;
        }
        public void CreateGood(object para)
        {
            var paras = para as object[];
            SuperMarket market = paras[0] as SuperMarket;
            object lockobj = paras[1];
            while (true)
            {
                Monitor.Enter(lockobj);
                try
                {
                    Good good = new Good();
                    good.SN = Guid.NewGuid().ToString();
                    market.Goods.Enqueue(good);
                    Console.WriteLine("{0} have Create Good:{1}", ProducerName, good);
                }
                catch (Exception ex)
                {
                    ex.ToString();
                }
                finally
                {
                    Monitor.Exit(lockobj);
                }
                Thread.Sleep(1000);
            }
        }
    }

    public class Consume
    {
        private string ConsumeName;
        public Consume(string name)
        {
            this.ConsumeName = name;
        }
        public void GetGood(object para)
        {
            var paras = para as object[];
            SuperMarket market = paras[0] as SuperMarket;
            object lockobj = paras[1];
            while (true)
            {
                Monitor.Enter(lockobj);
                lock (lockobj)
                {
                    try
                    {
                        if (market.Goods.Count <= 0)
                            continue;
                        Good good = market.Goods.Dequeue();
                        Console.WriteLine("{0} have Get Good:{1}", ConsumeName, good);
                    }
                    catch (Exception ex)
                    {
                        ex.ToString();
                    }
                    finally
                    {
                        Monitor.Exit(lockobj);
                    }
                }
                Thread.Sleep(500);
            }
        }
    }
}
