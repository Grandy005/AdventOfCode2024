using System.Linq;

namespace Second
{
    internal class Program
    {
        static bool CheckRecord(List<int> record)
        {
            bool isDescending = false, isAscending = false;

            if (record[0] < record[1])
            {
                if (record[1] - record[0] > 3)
                {
                    return false;
                }
                isAscending = true;
            }

            else if (record[0] > record[1])
            {
                if (record[0] - record[1] > 3)
                {
                    return false;
                }
                isDescending = true;
            }

            else
            {
                return false;
            }

            for (int i = 1; i < record.Count - 1; i++)
            {
                if (record[i] == record[i + 1])
                {
                    return false;
                }
                else
                {
                    if (isAscending)
                    {
                        if (record[i] > record[i + 1] || record[i + 1] - record[i] > 3)
                        {
                            return false;
                        }
                    }
                    else if (isDescending)
                    {
                        if (record[i] < record[i + 1] || record[i] - record[i + 1] > 3)
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        }

        static void Main(string[] args)
        {
            int safeRecords = 0;
            foreach (var line in File.ReadAllLines("input.txt"))
            {
                List<int> record = line.Split(" ").ToList().ConvertAll(x => Convert.ToInt32(x));

                int level = 0;
                if (CheckRecord(record))
                {
                    safeRecords++;
                }
                else
                {
                    int counter = 0;
                    List<int> tempRecord = record.GetRange(0, record.Count);
                    for (int i = 0; i < record.Count; i++)
                    {
                        level = tempRecord[i];
                        tempRecord.RemoveAt(i);
                        if (CheckRecord(tempRecord))
                        {
                            counter++;
                        }
                        tempRecord = record.GetRange(0, record.Count);
                    }
                    if (counter > 0)
                    {
                        safeRecords++;
                    }
                }
            }
            Console.WriteLine(safeRecords);
        }
    }
}
