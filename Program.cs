using System.Threading;

namespace programs
{
    class program
    {
        public static Mutex _mutex= new Mutex();
        static void main()
        {
            for (int i=0; i<6; i++)
            {
                new Thread(Write).Start();
            }
            Console.Read();
        }
        
        static void Write()
        {
            Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} waiting...");
            _mutex.WaitOne();
            Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} writing...");
            Thread.Sleep(5000);
            Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} Writing completed..");
            _mutex.ReleaseMutex();
        }

    }

}