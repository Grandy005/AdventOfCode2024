using System;

namespace First
{
    internal class Program
    {
        static int CompareNumbers(int num1, int num2)
        {
            int largerNumber = Math.Max(num1, num2);
            int smallerNumber = Math.Min(num1, num2);
            return largerNumber - smallerNumber;
        }

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

            leftList.Sort();
            rightList.Sort();

            int totalDistance = 0;
            for (int i = 0; i < leftList.Count; i++)
            {
                totalDistance += CompareNumbers(leftList[i], rightList[i]);
            }
            
            Console.WriteLine(totalDistance);
        }
    }
}
