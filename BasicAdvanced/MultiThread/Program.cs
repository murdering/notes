using System;
using System.Threading;

namespace MultiThread
{
    class Program
    {
        static void Main(string[] args)
        {
            // lock this
            //DeadLockWithThis();

            // lock non-static object
            //DeadLockWithNonStaticObject();

            // lock static object
            //DeadLockWithStaticObject();

            // lock static object with multi instances
            DeadLockWithStaticObjectAndMultiInstances();
        }

        static void DeadLockWithThis()
        {
            C1 c1 = new C1();
            //在t1线程中调用LockMe，并将deadlock设为true（将出现死锁）
            Thread t1 = new Thread(c1.LockMe);
            t1.Start(true);
            Thread.Sleep(100);
            //在主线程中lock c1
            lock (c1)
            {
                //调用没有被lock的方法
                c1.DoNotLockMe();
                //调用被lock的方法，并试图将deadlock解除
                c1.LockMe(false);
            }
        }

        static void DeadLockWithNonStaticObject()
        {
            C2 c1 = new C2();
            //在t1线程中调用LockMe，并将deadlock设为true（将出现死锁）
            Thread t1 = new Thread(c1.LockMe);
            t1.Start(true);
            Thread.Sleep(100);
            //在主线程中lock c1
            lock (c1)
            {
                //调用没有被lock的方法
                c1.DoNotLockMe();
                //调用被lock的方法，并试图将deadlock解除
                c1.LockMe(false);
            }
        }

        static void DeadLockWithStaticObject()
        {
            C3 c3 = new C3(string.Empty);

            //在t1线程中调用LockMe，并将deadlock设为true（将出现死锁）
            Thread t1 = new Thread(c3.LockMe);
            t1.Start(true);
            Thread.Sleep(100);
            //在主线程中lock c3
            lock (c3)
            {
                //调用没有被lock的方法
                c3.DoNotLockMe();
                //调用被lock的方法，并试图将deadlock解除
                c3.LockMe(false);
            }
        }

        static void DeadLockWithStaticObjectAndMultiInstances()
        {
            C3 c3 = new C3("第一个");
            C3 c32nd = new C3("第二个");

            //在t1线程中调用LockMe，并将deadlock设为true（将出现死锁）
            Thread t1 = new Thread(c3.LockMe);
            t1.Start(true);
            Thread.Sleep(100);
            //在主线程中lock c3

            //lock (c3)
            {
                //调用没有被lock的方法
                c3.DoNotLockMe();
                //调用被lock的方法，并试图将deadlock解除
                //c3.LockMe(false);
            }

            c32nd.DoNotLockMe();
            c32nd.LockMe(false);
        }
    }

    class C1
    {
        private bool deadlocked = true;
        //这个方法用到了lock，我们希望lock的代码在同一时刻只能由一个线程访问
        public void LockMe(object o)
        {
            lock (this)
            {
                while (deadlocked)
                {
                    deadlocked = (bool)o;
                    Console.WriteLine("Foo: I am locked :(");
                    Thread.Sleep(500);
                }
            }
        }
        //所有线程都可以同时访问的方法
        public void DoNotLockMe()
        {
            Console.WriteLine("I am not locked :)");
        }
    }

    class C2
    {
        private bool deadlocked = true;
        private object locker = new object();
        //这个方法用到了lock，我们希望lock的代码在同一时刻只能由一个线程访问
        public void LockMe(object o)
        {
            lock (locker)
            {
                while (deadlocked)
                {
                    deadlocked = (bool)o;
                    Console.WriteLine("Foo: I am locked :(");
                    Thread.Sleep(500);
                }
            }
        }
        //所有线程都可以同时访问的方法
        public void DoNotLockMe()
        {
            Console.WriteLine("I am not locked :)");
        }
    }

    class C3
    {
        private bool deadlocked = true;
        private static object locker = new object();
        private readonly string _name;

        public C3(string name)
        {
            _name = name;
        }

        //这个方法用到了lock，我们希望lock的代码在同一时刻只能由一个线程访问
        public void LockMe(object o)
        {
            lock (locker)
            {
                while (deadlocked)
                {
                    deadlocked = (bool)o;
                    Console.WriteLine($"{_name}: I am locked :(");
                    Thread.Sleep(500);
                }
            }
        }
        //所有线程都可以同时访问的方法
        public void DoNotLockMe()
        {
            Console.WriteLine($"{_name}: I am not locked :)");
        }
    }
}
