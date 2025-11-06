using System;

class Program
{
    static void Main()
    {
        Console.Write("請輸入矩陣大小 n: ");
        int n = int.Parse(Console.ReadLine());
        int[,] matrix = new int[n, n];

        Console.WriteLine("請輸入矩陣N元素");
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                Console.Write($"N[{i},{j}]=");
                matrix[i, j] = int.Parse(Console.ReadLine());
            }

        }

        Console.WriteLine("\n原始矩陣:");
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                Console.Write(matrix[i, j] + " ");
            }
            Console.WriteLine();
        }

        //主對角線加總
        int diagSum = 0;
        Console.Write("\n 主對角線元素:");
        for (int i = 0; i < n; i++)
        {
            Console.Write($" {matrix[i, i]} ");
            if (i < n - 1)
                Console.Write(", ");
            diagSum += matrix[i, i];
        }
        Console.WriteLine($"\n 主對角線加總: {diagSum}");

        //每列平均值
        Console.WriteLine("\n 每列平均值:");
        for (int i = 0; i < n; i++)
        {
            int rowSum = 0;
            for (int j = 0; j < n; j++)
                rowSum += matrix[i, j];

            double rowAvg = (double)rowSum / n;
            Console.WriteLine($" 第 {i} 列平均值: {rowAvg:F2}");

            //找出最小值及其位置
            int minVal = matrix[0, 0];
            int minRow = 0, minCol = 0;

            for (int r = 0; r < n; r++)
            {
                for (int c = 0; c < n; c++)
                {
                    if (matrix[r, c] < minVal)
                    {
                        minVal = matrix[r, c];
                        minRow = r;
                        minCol = c;
                    }
                }
            }
            Console.WriteLine($"\n 矩陣最小值: {minVal} 位置: ({minRow}, {minCol})");

            //請使用者輸入另一個大小也是 n x n 的矩陣 M
            int[,] matrixM = new int[n, n];

            Console.WriteLine("\n請輸入另一個矩陣M元素");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write($"M[{i},{j}]=");
                    matrixM[i, j] = int.Parse(Console.ReadLine());
                }
            }

            double[,] resultMatrix = new double[n, n];//使用 double 儲存結果
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    resultMatrix[i, j] = 1 / 3 * (double)matrix[i, j] / matrixM[i, j];
                }
            }

            Console.WriteLine("\n矩陣 1/3 * N + M 的結果為:");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(resultMatrix[i, j].ToString("0.0") + "\t");
                }
                Console.WriteLine();
            }

        }

    }
}