namespace AsynchronousTimer
{
    using System;

    public class AsynchronousTimerTest
    {
        public static void Main()
        {
            AsyncTimer timer = new AsyncTimer(Action, 10, 1000);
            timer.Start();
        }

        public static void Action(string str)
        {
            Console.WriteLine(str);
        }
    }
}