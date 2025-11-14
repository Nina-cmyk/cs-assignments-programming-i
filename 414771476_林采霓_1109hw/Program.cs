using System;

class Program
{
    // ============================================================
    // 函數：計算標準差（未進位，不四捨五入）
    // 使用母體標準差公式：
    //  σ = sqrt( (1/n) * Σ(x - 平均)^2 )
    // ============================================================
    static double CalcStdDevRaw(int[] arr)
    {
        int n = arr.Length;
        double mean = 0;

        // 計算平均值
        foreach (var x in arr)
            mean += x;
        mean /= n;

        // 計算 Σ(x - 平均)^2
        double sum = 0;
        foreach (var x in arr)
            sum += Math.Pow(x - mean, 2);

        // 套用標準差公式並回傳（未四捨五入）
        return Math.Sqrt(sum / n);
    }

    // ============================================================
    // 函數：計算標準差（進位後，四捨五入到小數點第 3 位）
    // ============================================================
    static double CalcStdDevRounded(int[] arr)
    {
        return Math.Round(CalcStdDevRaw(arr), 3);
    }

    // ============================================================
    // 第 1 題：陣列 {1, 2, 3, 4, 5} 的標準差
    // ============================================================
    static void Question1()
    {
        Console.WriteLine("====== 第 1 題：陣列 {1,2,3,4,5} 標準差 ======");

        // 宣告陣列
        int[] nums = { 1, 2, 3, 4, 5 };

        // 計算未進位標準差與進位後標準差
        double raw = CalcStdDevRaw(nums);
        double rounded = CalcStdDevRounded(nums);

        // 印出結果
        Console.WriteLine($"標準差(未進位) = {raw}");
        Console.WriteLine($"標準差(有進位) = {rounded}");
        Console.WriteLine();
    }

    // ============================================================
    // 第 2 題：產生 20 個介於 0–100 的亂數，並計算資訊
    // ============================================================
    static void Question2()
    {
        Console.WriteLine("====== 第 2 題：隨機產生 20 個整數 ======");

        Random rnd = new Random();
        int[] arr = new int[20];

        // 產生 20 個亂數並印出
        for (int i = 0; i < arr.Length; i++)
        {
            arr[i] = rnd.Next(0, 101); // 0~100
            Console.WriteLine($"第 {i + 1} 個數字為 {arr[i]}");
        }

        // -----------------------------
        // 計算總和
        // -----------------------------
        int sum = 0;
        foreach (var x in arr)
            sum += x;

        // -----------------------------
        // 計算平均值（四捨五入到小數第 2 位）
        // -----------------------------
        double avg = Math.Round(sum / 20.0, 2);

        // -----------------------------
        // 計算最大值與最小值
        // -----------------------------
        int max = arr[0];
        int min = arr[0];
        foreach (var x in arr)
        {
            if (x > max) max = x;
            if (x < min) min = x;
        }

        // -----------------------------
        // 計算標準差（未進位與進位後）
        // -----------------------------
        double rawStd = CalcStdDevRaw(arr);
        double roundedStd = CalcStdDevRounded(arr);

        // -----------------------------
        // 印出結果
        // -----------------------------
        Console.WriteLine("=====================================");
        Console.WriteLine("總和 = " + sum);
        Console.WriteLine("平均值 = " + avg);
        Console.WriteLine("最大值 = " + max);
        Console.WriteLine("最小值 = " + min);
        Console.WriteLine($"標準差(未進位) = {rawStd}");
        Console.WriteLine($"標準差(有進位) = {roundedStd}");
        Console.WriteLine();
    }

    // ============================================================
    // Main：程式進入點，呼叫兩題的方法
    // ============================================================
    static void Main()
    {
        Question1();
        Question2();
    }
}
