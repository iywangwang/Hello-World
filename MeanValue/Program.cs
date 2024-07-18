namespace MeanValue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[10];
            int sum = 0;
            string? s ;
            double mean = 0;

            for (int i = 0; i < array.Length; i++)
            {
                Console.Write($"请输入第{i + 1}个值：");
                s = Console.ReadLine();

                if (String.IsNullOrEmpty(s))
                {
                    Console.WriteLine("不可输入空值！");
                    i--;
                    continue;
                }
                else
                {
                    try
                    {
                        array[i] = int.Parse(s);
                    }
                    catch
                    {
                        Console.WriteLine("输入不合法（ 请输入一个整数！）");
                        i--;
                        continue;
                    }
                    sum += array[i];
                }
            }
            mean = sum / 10.0;
            Console.Write("该十个数的平均值为：");
            Console.WriteLine(mean.ToString("0.0000"));
            Console.ReadKey();
        }
    }
}
