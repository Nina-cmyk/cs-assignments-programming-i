using System;
using System.IO;
using System.Collections.Generic;

namespace _414771476_林采霓_1121_02
{
    public class Statistics
    {
        // 平均
        public static double Average(double[] data)
        {
            double sum = 0;
            foreach (var v in data) sum += v;
            return sum / data.Length;
        }

        // 最大值
        public static double Max(double[] data)
        {
            double max = data[0];
            foreach (var v in data)
                if (v > max) max = v;
            return max;
        }

        // 最小值
        public static double Min(double[] data)
        {
            double min = data[0];
            foreach (var v in data)
                if (v < min) min = v;
            return min;
        }

        // 標準差 (n - 1)
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
            // 讀取 items.txt
            string[] lines = File.ReadAllLines("414771476_林采霓_1121_02/items.txt");

            List<double> priceList = new List<double>();

            // 第 0 行是標題列，從第 1 行開始讀
            for (int i = 1; i < lines.Length; i++)
            {
                if (string.IsNullOrWhiteSpace(lines[i])) continue;

                // 以 tab 切欄位
                string[] parts = lines[i].Split('\t');

                // parts[4] 是價格欄
                double price = double.Parse(parts[4]);
                priceList.Add(price);
            }

            double[] prices = priceList.ToArray();

            Console.WriteLine("便利商店商品價格統計：");
            Console.WriteLine("平均價格：{0:0.00} 元", Statistics.Average(prices));
            Console.WriteLine("最高價格：{0} 元", Statistics.Max(prices));
            Console.WriteLine("最低價格：{0} 元", Statistics.Min(prices));
            Console.WriteLine("價格標準差：{0:0.00}", Statistics.Standard_Deviation(prices));

            Console.ReadLine();
        }
    }
}
