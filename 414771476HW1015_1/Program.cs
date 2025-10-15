using System;

class Program
{
    static void Main()
    {
        // ========= 題目 1 =========
        // 請印出 10 個 2 的倍數（從 2 開始）
        Console.WriteLine("題目1：印出 10 個 2 的倍數（從 2 開始）");
        for (int i = 1; i <= 10; i++)
        {
            Console.WriteLine(i * 2);
        }
        Pause();

        // ========= 題目 2 =========
        // 使用者輸入一個數字後，印出相同數量的 *
        Console.Write("題目2：請輸入一個數字：");
        int n2 = ReadInt();
        for (int i = 0; i < n2; i++)
        {
            Console.Write("*");
        }
        Console.WriteLine();
        Pause();

        // ========= 題目 3 =========
        // 使用者輸入一個數字 n，計算 1~n 的總和，並顯示每一步的累計值
        Console.Write("題目3：請輸入一個數字 n：");
        int n3 = ReadInt();
        int sum = 0;
        for (int i = 1; i <= n3; i++)
        {
            sum += i;
            Console.WriteLine($"i={i} 時，累計值為 {sum}");
        }
        Pause();

        // ========= 題目 4 =========
        // 使用者輸入一個數字 n，印出 n 列「1 2 3 ... n」
        Console.Write("題目4：請輸入一個數字：");
        int n4 = ReadInt();
        for (int r = 0; r < n4; r++)
        {
            for (int c = 1; c <= n4; c++)
            {
                Console.Write(c);
                if (c < n4) Console.Write(" ");
            }
            Console.WriteLine();
        }
        Pause();

        // ========= 題目 5 =========
        // 使用者輸入一個數字 n，印出遞增三角形（1~n 列）
        Console.Write("題目5：請輸入一個數字：");
        int n5 = ReadInt();
        for (int i = 1; i <= n5; i++)
        {
            for (int j = 0; j < i; j++)
            {
                Console.Write("*");
            }
            Console.WriteLine();
        }
        Pause();

        // ========= 題目 6 =========
        // 使用者輸入一個數字 n，印出遞減三角形（n~1 列）
        Console.Write("題目6：請輸入一個數字：");
        int n6 = ReadInt();
        for (int i = n6; i >= 1; i--)
        {
            for (int j = 0; j < i; j++)
            {
                Console.Write("*");
            }
            Console.WriteLine();
        }

        Console.WriteLine("\n全部題目完成，按任意鍵結束…");
        Console.ReadKey();
    }

    // 讀整數
    static int ReadInt()
    {
        while (true)
        {
            var s = Console.ReadLine();
            if (int.TryParse(s, out int v) && v >= 0) return v;
            Console.Write("請輸入非負整數：");
        }
    }

    // 小停頓
    static void Pause()
    {
        Console.WriteLine("（按 Enter 繼續）");
        Console.ReadLine();
    }
}
