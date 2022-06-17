using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ConsoleApp
{
    class Program
    {
        public static List<int> GetRank(List<int> ranked, List<int> player)
        {
            var result = new List<int>();
            ranked = ranked.Distinct().ToList();
            var pLength = player.Count;
            var rLength = ranked.Count - 1;

            int j = rLength;
            for (int i = 0; i < pLength; i++)
            {
                for (; j >= 0; j--)
                {
                    if (player[i] == ranked[j])
                    {
                        result.Add(j + 1);
                        break;
                    }
                    else if (player[i] < ranked[j])
                    {
                        result.Add(j + 2);
                        break;
                    }
                    else if (player[i] > ranked[j] && j == 0)
                    {
                        result.Add(1);
                        break;
                    }
                }
            }
            return result;
        }
        static void Main(string[] args)
        {
            //TODO: Change this input file path before start
            var filePath = "D:\\Projects\\Interview\\SourceCode\\Console\\ConsoleApp\\Input.txt";

            var lines = System.IO.File.ReadLines(filePath).ToList();

            int rankedCount = Convert.ToInt32(lines[0].Trim());

            List<int> ranked = lines[1].TrimEnd().Split(' ').ToList().Select(rankedTemp => Convert.ToInt32(rankedTemp)).ToList();

            int playerCount = Convert.ToInt32(lines[2].Trim());

            List<int> player = lines[3].TrimEnd().Split(' ').ToList().Select(playerTemp => Convert.ToInt32(playerTemp)).ToList();

            List<int> result = GetRank(ranked, player);

            Console.WriteLine(String.Join("\n", result));

        }
    }
}
