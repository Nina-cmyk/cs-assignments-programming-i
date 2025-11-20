using System;
using System.IO;
using System.Collections.Generic;

namespace _414771476_林采霓_1121_03
{
    public class Statistics
    {
        public static double Average(double[] data)
        {
            double sum = 0;
            foreach (var v in data) sum += v;
            return sum / data.Length;
        }

        public static double Max(double[] data)
        {
            double max = data[0];
            foreach (var v in data)
                if (v > max) max = v;
            return max;
        }

        public static double Min(double[] data)
        {
            double min = data[0];
            foreach (var v in data)
                if (v < min) min = v;
            return min;
        }

        public static double Standard_Deviation(double[] data)
        {
            double mean = Average(data);
            double sum = 0;
            foreach (var v in data)
            {
                double diff = v - mean;
                sum += diff * diff;
            }
            return Math.Sqrt(sum / (data.Length - 1));
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            RunStudentsStatistics();
            Console.ReadLine();
        }

        static void RunStudentsStatistics()
        {
            // ⭐ 你要求的寫法：資料夾/檔名.txt
            string path = "414771476_林采霓_1121_03/students_tab.txt";

            string[] lines = File.ReadAllLines(path);

            List<double> chinese = new List<double>();
            List<double> english = new List<double>();
            List<double> math = new List<double>();
            List<double> science = new List<double>();
            List<double> social = new List<double>();

            for (int i = 1; i < lines.Length; i++)
            {
                if (string.IsNullOrWhiteSpace(lines[i])) continue;

                string[] parts = lines[i].Split('\t');

                chinese.Add(double.Parse(parts[4]));
                english.Add(double.Parse(parts[5]));
                math.Add(double.Parse(parts[6]));
                science.Add(double.Parse(parts[7]));
                social.Add(double.Parse(parts[8]));
            }

            Console.WriteLine("全校各科統計結果：");
            PrintSubject("國文", chinese.ToArray());
            PrintSubject("英文", english.ToArray());
            PrintSubject("數學", math.ToArray());
            PrintSubject("自然", science.ToArray());
            PrintSubject("社會", social.ToArray());
        }

        static void PrintSubject(string name, double[] data)
        {
            Console.WriteLine(
                "{0} → 平均:{1:0.00}, 最高:{2}, 最低:{3}, 標準差:{4:0.00}",
                name,
                Statistics.Average(data),
                Statistics.Max(data),
                Statistics.Min(data),
                Statistics.Standard_Deviation(data)
            );
        }
    }
}
