using System;
using System.Linq;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        // 讀取矩陣大小
        int n = ReadInt("請輸入矩陣的 rows 數: ");
        int m = ReadInt("請輸入矩陣的 columns 數: ");

        // 輸入矩陣 M
        int[,] M = ReadMatrix(n, m, "請輸入矩陣 M 的元素：");

        // (a)
        Console.WriteLine("\n(a) 將所有元素加上 10：");
        int[,] add10 = Map(M, x => x + 10);
        PrintMatrix(add10);
        WaitNext();

        // (b)
        Console.WriteLine("\n(b) 將奇數元素乘以 2，偶數元素除以 2：");
        int[,] odd2EvenHalf = Map(M, x => (x % 2 != 0) ? x * 2 : x / 2);
        PrintMatrix(odd2EvenHalf);
        WaitNext();

        // (c)
        Console.WriteLine("\n(c) 每一欄(column)的最大值與最小值：");
        var (colMax, colMin) = ColumnMaxMin(M);
        for (int j = 0; j < m; j++)
        {
            Console.WriteLine($"第 {j + 1} 欄 => 最大值: {colMax[j]}, 最小值: {colMin[j]}");
        }
        WaitNext();

        // (d)
        int[,] N = ReadMatrix(n, m, "請再輸入一個與矩陣 M 一樣大小的矩陣 N 的元素：");
        Console.WriteLine("\n矩陣 M + N 的結果為：");
        int[,] sum = Add(M, N);
        PrintMatrix(sum);

        Console.WriteLine("\n所有題目完成，按任意鍵結束。");
        Console.ReadKey();
    }

    // ===== 工具函式 =====
    static void WaitNext()
    {
        Console.WriteLine("\n（按 Enter 進行下一題...）");
        Console.ReadLine();
    }

    static int ReadInt(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            if (int.TryParse(Console.ReadLine(), out int v)) return v;
            Console.WriteLine("輸入格式錯誤，請輸入整數。");
        }
    }

    static int[,] ReadMatrix(int n, int m, string title)
    {
        Console.WriteLine(title);
        var A = new int[n, m];
        for (int i = 0; i < n; i++)
        {
            while (true)
            {
                Console.Write($"第 {i + 1} row（{m} 個數字，以空白分隔）: ");
                var parts = (Console.ReadLine() ?? "").Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (parts.Length != m) { Console.WriteLine("數量不符，請重輸。"); continue; }

                bool ok = true;
                for (int j = 0; j < m; j++)
                {
                    if (!int.TryParse(parts[j], out A[i, j])) { ok = false; break; }
                }
                if (ok) break;
                Console.WriteLine("含有非整數，請重輸。");
            }
        }
        return A;
    }

    static void PrintMatrix(int[,] A)
    {
        int n = A.GetLength(0), m = A.GetLength(1);
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                Console.Write(A[i, j].ToString().PadLeft(5));
            }
            Console.WriteLine();
        }
    }

    static int[,] Map(int[,] A, Func<int, int> f)
    {
        int n = A.GetLength(0), m = A.GetLength(1);
        var B = new int[n, m];
        for (int i = 0; i < n; i++)
            for (int j = 0; j < m; j++)
                B[i, j] = f(A[i, j]);
        return B;
    }

    static (int[] max, int[] min) ColumnMaxMin(int[,] A)
    {
        int n = A.GetLength(0), m = A.GetLength(1);
        int[] max = new int[m];
        int[] min = new int[m];
        for (int j = 0; j < m; j++)
        {
            max[j] = int.MinValue;
            min[j] = int.MaxValue;
            for (int i = 0; i < n; i++)
            {
                if (A[i, j] > max[j]) max[j] = A[i, j];
                if (A[i, j] < min[j]) min[j] = A[i, j];
            }
        }
        return (max, min);
    }

    static int[,] Add(int[,] A, int[,] B)
    {
        int n = A.GetLength(0), m = A.GetLength(1);
        if (n != B.GetLength(0) || m != B.GetLength(1))
            throw new ArgumentException("矩陣尺寸不相同。");

        var C = new int[n, m];
        for (int i = 0; i < n; i++)
            for (int j = 0; j < m; j++)
                C[i, j] = A[i, j] + B[i, j];
        return C;
    }
}
