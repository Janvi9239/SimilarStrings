using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;

class Program
{
    //Levenshtein Distance algorithm to compare string similarity
    static int Compute(string source, string target)
    {
        int n = source.Length;
        int m = target.Length;
        int[,] d = new int[n + 1, m + 1];

        // Verify arguments
        if (n == 0)
        {
            return m;
        }

        if (m == 0)
        {
            return n;
        }

        // Initialize arrays
        for (int i = 0; i <= n; d[i, 0] = i++)
        {
        }

        for (int j = 0; j <= m; d[0, j] = j++)
        {
        }

        for (int i = 1; i <= n; i++)
        {
            for (int j = 1; j <= m; j++)
            {
                // Compute distance
                int distance = (target[j - 1] == source[i - 1]) ? 0 : 1;
                d[i, j] = Math.Min(
                Math.Min(d[i - 1, j] + 1, d[i, j - 1] + 1),
                d[i - 1, j - 1] + distance);
            }
        }
        // Return distance
        return d[n, m];
    }

    public static void Main()
    {
        //Reading each line of text file into string array
        string[] data = System.IO.File.ReadAllLines(@"C:\Users\jahna\source\repos\Pathmatics\input.txt");

        string[] lines = data.Distinct().ToArray();

        //Initialized lists
        List<string> items = new List<string>();
        List<string> collection = new List<string>();

        //threshold value to compare distance (lesser distance implies similar strings)
        int threshold = 2;

        //Removing special characters and possible extensions
        foreach (string line in lines)
        {
            var upline = Regex.Replace(line, @"[^0-9a-zA-Z]+", "");
            upline = upline.Replace("LLC", "").Replace("Ltd","").Replace("Inc","").ToLower();
            items.Add(upline);
        }
        string[] result = items.ToArray();

        //Looping over the array
        for (int i = 0; i < result.Length; i++)
        {
            for (int j = 0; j < result.Length; j++)
            {
                //calculating Levenshtein distance
                int distance = Compute(result[i], result[j]);
                
                //Appending to the list if it meets the threshold criteria
                if (i != j && distance <= threshold)
                {
                    if (!collection.Contains(lines[i]))
                    {
                        collection.Add(lines[i]);
                    }
                }
            }
        }
        //Writing collection to text file as each line
        System.IO.File.WriteAllLines(@"C:\Users\jahna\source\repos\Pathmatics\output.txt", collection);
    }
}
