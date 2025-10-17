using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("持續輸入整數（輸入負數結束；輸入 0 不計算、請重輸）");

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
        Console.WriteLine($"平均 = {(count > 0 ? (sum / (double)count) : 0)}");
    }

    static int ReadInt()
    {
        while (true)
        {
            if (int.TryParse(Console.ReadLine(), out int v)) return v;
            Console.Write("輸入錯誤，請輸入整數：");
        }
    }
}