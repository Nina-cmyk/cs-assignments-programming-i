using System;

class Program
{
    static void Main()
    {
        // ===== 題目 1：矩陣相乘 =====
        // A: 2x3, B: 3x2  -> C: 2x2
        int[,] A =
        {
            { 1, 2, 3 },
            { 4, 5, 6 }
        };
        int[,] B =
        {
            { 7,  8 },
            { 9, 10 },
            { 11, 12 }
        };

        Console.WriteLine("題目1：矩陣 A × 矩陣 B 的結果為：");
        var C = Multiply(A, B);
        PrintMatrix(C);
        Pause();

        // ===== 題目 2：3x3 右旋 90 度 =====
        int[,] M =
        {
            { 1, 2, 3 },
            { 4, 5, 6 },
            { 7, 8, 9 }
        };

        Console.WriteLine("題目2：原始矩陣：");
        PrintMatrix(M);

        Console.WriteLine("旋轉 90°（往右）後：");
        var R = RotateRight90(M);
        PrintMatrix(R);

        Console.WriteLine("\n全部完成，按任意鍵結束…");
        Console.ReadKey();
    }

    // ====== 矩陣相乘：A(m×n) * B(n×p) => C(m×p) ======
    static int[,] Multiply(int[,] A, int[,] B)
    {
        int m = A.GetLength(0); // A 的列數
        int n = A.GetLength(1); // A 的行數 (= B 的列數)
        int p = B.GetLength(1); // B 的行數

        if (n != B.GetLength(0))
            throw new ArgumentException("A 的行數必須等於 B 的列數");

        int[,] C = new int[m, p];

        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < p; j++)
            {
                int sum = 0;
                for (int k = 0; k < n; k++)
                    sum += A[i, k] * B[k, j];
                C[i, j] = sum;
            }
        }
        return C;
    }

    // ====== 將 NxN 矩陣向右旋轉 90 度 ======
    static int[,] RotateRight90(int[,] M)
    {
        int nRows = M.GetLength(0);
        int nCols = M.GetLength(1);
        if (nRows != nCols) throw new ArgumentException("僅支援方陣旋轉");

        int N = nRows;
        int[,] R = new int[N, N];
        // 右旋公式：R[i, j] = M[N-1-j, i]
        for (int i = 0; i < N; i++)
            for (int j = 0; j < N; j++)
                R[i, j] = M[N - 1 - j, i];

        return R;
    }

    // ====== 輸出矩陣 ======
    static void PrintMatrix(int[,] M)
    {
        int r = M.GetLength(0);
        int c = M.GetLength(1);
        for (int i = 0; i < r; i++)
        {
            for (int j = 0; j < c; j++)
                Console.Write($"{M[i, j],4}");
            Console.WriteLine();
        }
    }

    static void Pause()
    {
        Console.WriteLine("（按 Enter 繼續）");
        Console.ReadLine();
    }
}
