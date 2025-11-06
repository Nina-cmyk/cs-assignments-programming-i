using System;

class Program
{
    static void Main()
    {
        // 請試用者輸入一個正整數，輸出數字中最大的位數
        Console.Write("請輸入一個正整數: ");
        int number = int.Parse(Console.ReadLine());
        int maxDigit = 0;
        while (number > 0)
        {
            int digit = number % 10;
            if (digit > maxDigit)
            {
                maxDigit = digit;
            }
            number /= 10;
        }
        Console.WriteLine($"最大的位數是: {maxDigit}");
            
        }
}