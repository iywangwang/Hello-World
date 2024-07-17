namespace WordBreak
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num = 0;
            string str;
            char[] chars;

            while (true)
            {
                Console.Write("请输入字符串：");
                str = Console.ReadLine();

                if (str == "")
                {
                    break;
                }

                chars = str.ToCharArray();
                num = chars.Length;
                Console.WriteLine("单词的个数为：{0}", num);

                for (int i = 0; i < num; i++)
                {
                    if (char.IsPunctuation(chars[i]))
                    {
                        chars[i] = ' '; //是标点则化为空格
                    }
                }

                string a = new string(chars);
                string[] word = a.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);    //去除空数据
                Array.Reverse(word, 0, word.Length);

                Console.Write("逆序之后的字符串为：");
                foreach (string item in word)
                {
                    Console.Write(item + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
