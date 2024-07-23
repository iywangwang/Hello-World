namespace ChongXie
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person();
            person.Action();

            Person teacher = new Teacher();
            teacher.Action();
        }
    }

    class Person
    {
        public virtual void Action() {
            Console.WriteLine("This is Person");
        }
    }

    class Teacher : Person
    {
        public override void Action()
        {
            Console.WriteLine("This is Teacher");
        }
    }
}
