using System.Text;

namespace First
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StringBuilder sb = new StringBuilder();

            int result = 0;
            foreach (var line in File.ReadAllLines("input.txt"))
            {
                for (int i = 0; i < line.Length - 3; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        sb.Append(line[i + j]);
                    }

                    if (sb.ToString() == "mul(")
                    {
                        for (int j = i + 4; j < line.Length; j++)
                        {
                            if (line[j] == ')' && j - (i + 4) < 8)
                            {
                                sb.Remove(0, sb.Length);
                                line.ToList().Slice(i + 4, j - (i + 4)).ForEach(x => sb.Append(x));
                                if (sb.ToString().Contains(','))
                                {
                                    result += int.Parse(sb.ToString().Split(",")[0]) * int.Parse(sb.ToString().Split(",")[1]);
                                }
                                j = line.Length;
                            }
                        }
                    }
                    sb.Remove(0, sb.Length);
                }
            }
            Console.WriteLine(result);
        }
    }
}
