using System;

class Program
{
    static void Main()
    {
        // 1. BMI 計算
        double height = 175; // 公分
        double weight = 75.6;
        double bmi = weight / Math.Pow(height / 100, 2);
        Console.WriteLine("BMI = " + bmi);

        // 2. 團購教科書 20 本打 85 折
        int price = 520;
        int qty = 20;
        int total = price * qty;
        double discountTotal = total * 0.85;
        Console.WriteLine($"原價: {total}, 特價85折: {discountTotal}");

        // 3. 使用者輸入價格與數量再打折
        Console.Write("請輸入價格: ");
        int userPrice = int.Parse(Console.ReadLine());
        Console.Write("請輸入數量: ");
        int userQty = int.Parse(Console.ReadLine());
        int userTotal = userPrice * userQty;
        double userDiscount = userTotal * 0.85;
        Console.WriteLine($"售價: {userPrice} 數量: {userQty}");
        Console.WriteLine($"原價: {userTotal} 特價85折: {userDiscount}");

        // 4. 攝氏轉華氏
        Console.Write("請輸入攝氏溫度: ");
        double c = double.Parse(Console.ReadLine());
        double f = c * 9 / 5 + 32;
        Console.WriteLine($"華氏溫度 = {f}");

        // 5. 秒數轉換
        Console.Write("請輸入秒數: ");
        int sec = int.Parse(Console.ReadLine());
        int min = sec / 60;
        int secRemain = sec % 60;
        Console.WriteLine($"{min}:{secRemain.ToString().PadLeft(2, '0')}");

        // 6. 台幣換美元
        Console.Write("請輸入台幣金額: ");
        double twd = double.Parse(Console.ReadLine());
        double usd = twd / 32.5;
        Console.WriteLine($"美金 = {usd:F2}");
    }
}
