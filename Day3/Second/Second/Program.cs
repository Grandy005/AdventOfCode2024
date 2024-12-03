using System.Text;

namespace Second
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StringBuilder sb = new StringBuilder();
            StringBuilder dontString = new StringBuilder();

            int result = 0;
            bool isEnabled = true;
            foreach (var line in File.ReadAllLines("input.txt"))
            {
                for (int i = 0; i < line.Length - 6; i++)
                {
                    sb.Append(line[i]);
                    sb.Append(line[i + 1]);
                    sb.Append(line[i + 2]);
                    sb.Append(line[i + 3]);

                    dontString.Append(line[i]);
                    dontString.Append(line[i + 1]);
                    dontString.Append(line[i + 2]);
                    dontString.Append(line[i + 3]);
                    dontString.Append(line[i + 4]);
                    dontString.Append(line[i + 5]);
                    dontString.Append(line[i + 6]);

                    if (sb.ToString() == "do()")
                    {
                        isEnabled = true;
                    }
                    else if (dontString.ToString() == "don't()")
                    {
                        isEnabled = false;
                    }

                    if (isEnabled)
                    {
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
                    }

                    sb.Remove(0, sb.Length);
                    dontString.Remove(0, dontString.Length);
                }
            }
            Console.WriteLine(result);
        }
    }
}
