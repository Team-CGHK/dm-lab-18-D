using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DiscreteMathLab8_C
{
    class Program
    {
        static StreamReader sr = new StreamReader("lottery.in");
        static StreamWriter sw = new StreamWriter("lottery.out") { AutoFlush = true };

        static void Main(string[] args)
        {
            string[] words = sr.ReadLine().Split(' ');
            int n = int.Parse(words[0]),
                m = int.Parse(words[1]);
            int[] fields = new int[m],
                  award = new int[m+1];
            for (int i = 0; i < m; i++)
            {
                words = sr.ReadLine().Split(' ');
                fields[i] = int.Parse(words[0]);
                award[i + 1] = int.Parse(words[1]);
            }
            double prob = 1;
            double[] value = new double[m + 1];
            for (int i = 0; i < m; i++)
            {
                value[i] = prob * ((double)fields[i]-1)/fields[i] * award[i];
                prob /= fields[i];
            }
            value[m] = prob * award[m];
            double sum = 0;
            for (int i = 0; i < m + 1; i++)
                sum += value[i];
            sw.WriteLine((n - sum).ToString().Replace(',','.'));
        }
    }
}
