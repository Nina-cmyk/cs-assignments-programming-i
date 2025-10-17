using System;

class Program
{
    static void Main()
    {
        Console.Write("請輸入一個整數 n：");
        int n = ReadInt();

        for (int i = 1; i <= n; i++)
        {
            if (i % 5 == 0) Console.WriteLine("特別數字"); 
            else            Console.WriteLine(i);
        }
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