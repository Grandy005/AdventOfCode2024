using System;

namespace Second
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> leftList = new List<int>();
            List<int> rightList = new List<int>();

            foreach (string line in File.ReadAllLines("input.txt"))
            {
                int leftId = int.Parse(line.Split("   ")[0]);
                int rightId = int.Parse(line.Split("   ")[1]);

                leftList.Add(leftId);
                rightList.Add(rightId);
            }

            int totalSimilarity = 0;
            foreach (int id in leftList)
            {
                if (rightList.Contains(id))
                {
                    totalSimilarity += id * rightList.Count(x => x == id);
                }
            }
            Console.WriteLine(totalSimilarity);
        }
    }
}
