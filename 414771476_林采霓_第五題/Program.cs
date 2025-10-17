using System;

class Program
{
    static void Main()
    {
        int[,] M =
        {
            { 1, 2, 3 },
            { 4, 5, 6 },
            { 7, 8, 9 }
        };

        Console.WriteLine("題目：原始矩陣：");
        PrintMatrix(M);

        Console.WriteLine("旋轉 90°（往右）後：");
        var R = RotateRight90(M);
        PrintMatrix(R);

        Console.WriteLine("旋轉 90°（往右）後再旋轉 90°（往右）：");
        var R2 = RotateRight90(R);
        PrintMatrix(R2);

        Console.WriteLine("旋轉 90°（往右）後再旋轉 90°（往右）再旋轉 90°（往右）：");
        var R3 = RotateRight90(R2);
        PrintMatrix(R3);
    }

    // 只支援 NxN 方陣：R[i,j] = M[N-1-j, i]
    static int[,] RotateRight90(int[,] M)
    {
        int n = M.GetLength(0);
        if (n != M.GetLength(1)) throw new ArgumentException("僅支援方陣旋轉");


        int[,] R = new int[n, n];
        for (int i = 0; i < n; i++)
            for (int j = 0; j < n; j++)
                R[i, j] = M[n - 1 - j, i];
        return R;
    }
    

    static void PrintMatrix(int[,] M)
    {
        int r = M.GetLength(0), c = M.GetLength(1);
        for (int i = 0; i < r; i++)
        {
            for (int j = 0; j < c; j++)
                Console.Write($"{M[i, j],4}");
            Console.WriteLine();
        }
    }
}