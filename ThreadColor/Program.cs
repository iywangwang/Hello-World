using System.Threading;

namespace ThreadColor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Student student1 = new Student() { ID = 1, PenColor = ConsoleColor.Gray };
            Student student2 = new Student() { ID = 2, PenColor = ConsoleColor.Green };
            Student student3 = new Student() { ID = 3, PenColor = ConsoleColor.Red };

            Action action = new Action(student1.DoHomework);
            action += new Action(student2.DoHomework);
            action += new Action(student3.DoHomework);

            action.Invoke();
        }
    }

    class Student
    {
        public int ID { get; set; }
        public ConsoleColor PenColor { get; set; }

        public void DoHomework() 
        {
            for (int i = 0; i < 5; i++)
            {
                Console.ForegroundColor = this.PenColor;
                Console.WriteLine("Student {0} doing homework {1} hour(s)", this.ID, i);
                Thread.Sleep(1000);
            }  
        }
    }
}
