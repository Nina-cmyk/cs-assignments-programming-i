using System;

class Program
{
    static void Main(string[] args)
    {
        double[] a = new double[] { 3, 7, 14, 6 };

        Console.WriteLine("平均值為{0}", Statistics.Average(a));
        Console.WriteLine("最大值為{0}", Statistics.Max(a));
        Console.WriteLine("最小值為{0}", Statistics.Min(a));
        Console.WriteLine("標準差為{0}", Statistics.Standard_Deviation(a));

        Console.ReadLine();
    }
}

public class Statistics
{
    // 平均值 mean
    public static double Average(double[] data)
    {
        double sum = 0;
        for (int i = 0; i < data.Length; i++)
        {
            sum += data[i];
        }
        return sum / data.Length;
    }

    // 最大值 max
    public static double Max(double[] data)
    {
        double max = data[0];
        for (int i = 1; i < data.Length; i++)
        {
            if (data[i] > max)
                max = data[i];
        }
        return max;
    }

    // 最小值 min
    public static double Min(double[] data)
    {
        double min = data[0];
        for (int i = 1; i < data.Length; i++)
        {
            if (data[i] < min)
                min = data[i];
        }
        return min;
    }

    // 標準差 standard deviation（依照題目：分母 n-1）
    public static double Standard_Deviation(double[] data)
    {
        double mean = Average(data);

        double sumSquareDiff = 0;
        for (int i = 0; i < data.Length; i++)
        {
            double diff = data[i] - mean;
            sumSquareDiff += diff * diff;
        }

        double variance = sumSquareDiff / (data.Length - 1);
        return Math.Sqrt(variance);
    }
}
