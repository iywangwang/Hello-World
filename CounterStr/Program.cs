namespace CounterStr
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string? str;
            char[] chars;
            while (true)
            {
                Console.Write("请输入一串字符：");
                str = Console.ReadLine();

                if (str == "")
                {
                    return;
                }

                chars = str.ToCharArray();
                Array.Reverse(chars);
                string s = new string(chars);

                Console.WriteLine($"逆序后的字符串：{s}");
            }
        }
    }
}
