using System;

class Program
{
    static void Main()
    {
        // ===== 題目 1 =====
        Console.Write("題目1：請輸入一個整數 n：");
        int n1 = ReadInt();
        for (int i = 1; i <= n1; i++)
        {
            if (i % 3 == 0 && i % 2 == 0)   // 同時是3的倍數且為偶數 => 6的倍數
                Console.WriteLine("特別數字");
            else
                Console.WriteLine(i);
        }
        Pause();

        // ===== 題目 2（Collatz）=====
        Console.Write("題目2：請輸入一個正整數：");
        int n2 = ReadPositiveInt();
        Console.WriteLine("開始計算柯拉茲數列：");
        while (n2 != 1)
        {
            if (n2 % 2 == 0) n2 /= 2;
            else n2 = n2 * 3 + 1;
            Console.WriteLine(n2);
        }
        Console.WriteLine("遊戲結束！");
        Pause();

        // ===== 題目 3（總和與平均）=====
        Console.WriteLine("題目3：持續輸入整數（輸入負數結束；輸入 0 不計算、請重輸）");
        int sum = 0, count = 0;
        while (true)
        {
            Console.Write("請輸入一個整數（輸入負數結束）：");
            int x = ReadInt();
            if (x < 0) break;
            if (x == 0)
            {
                Console.WriteLine("0 不計算，請重新輸入");
                continue;
            }
            sum += x;
            count++;
        }

        Console.WriteLine("程式結束");
        Console.WriteLine($"總和 = {sum}");
        if (count > 0)
            Console.WriteLine($"平均 = {(double)sum / count}");
        else
            Console.WriteLine("平均 = 0（沒有任何正數被納入計算）");

        Console.WriteLine("\n全部完成，按任意鍵離開…");
        Console.ReadKey();
    }

    // 讀整數（允許負數與 0）
    static int ReadInt()
    {
        while (true)
        {
            if (int.TryParse(Console.ReadLine(), out int v))
                return v;
            Console.Write("輸入錯誤，請輸入整數：");
        }
    }

    // 讀正整數（>=1）
    static int ReadPositiveInt()
    {
        while (true)
        {
            if (int.TryParse(Console.ReadLine(), out int v) && v >= 1)
                return v;
            Console.Write("請輸入「正整數」：");
        }
    }

    static void Pause()
    {
        Console.WriteLine("（按 Enter 繼續下一題）");
        Console.ReadLine();
    }
}
