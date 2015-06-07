namespace AsynchronousTimer
{
    using System;
    using System.Threading;

    public class AsyncTimer
    {
        public AsyncTimer(Action<string> action, int ticks, int t)
        {
            this.Action = action;
            this.Ticks = ticks;
            this.T = t;
        }

        public Action<string> Action { get; set; }

        public int Ticks { get; set; }

        public int T { get; set; }

        public void DoAction()
        {
            while (this.Ticks > 0)
            {
                Thread.Sleep(this.T);
                this.Action(this.Ticks.ToString());
                this.Ticks--;
            }
        }

        public void Start()
        {
            Thread thread = new Thread(this.DoAction);
            thread.Start();
        }
    }
}