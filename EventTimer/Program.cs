using System.Timers;
namespace EventTimer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Boy boy = new Boy();
            System.Timers.Timer timer = new ();
            timer.Interval = 1000;
            timer.Elapsed += boy.Action;

            timer.Start ();
            Console.ReadKey();
        }
    }

    class Boy
    {
        internal void Action(object? sender, ElapsedEventArgs e)
        {
            Console.WriteLine("Boy Down!");
        }
    }
}
