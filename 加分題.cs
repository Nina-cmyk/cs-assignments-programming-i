using System;

class GuessNumber
{
    static void Main()
    {
        Random rand = new Random();
        int answer = rand.Next(1, 101); // 產生 1~100 的隨機數
        int guess;
        int maxAttempts = 10;

        Console.WriteLine("=== 猜數字遊戲 ===");
        Console.WriteLine("我已經想好了一個 1 到 100 的數字，請你來猜！");

        for (int attempt = 1; attempt <= maxAttempts; attempt++)
        {
            Console.Write($"第 {attempt} 次猜測，請輸入數字：");
            string input = Console.ReadLine();

            if (!int.TryParse(input, out guess))
            {
                Console.WriteLine("請輸入有效的整數！");
                attempt--;
                continue;
            }

            if (guess == answer)
            {
                Console.WriteLine("恭喜答對！");
                return;
            }
            else if (guess > answer)
            {
                Console.WriteLine("太大了！");
            }
            else
            {
                Console.WriteLine("太小了！");
            }
        }

        Console.WriteLine($"遊戲結束，正確答案是 {answer}。");
    }
}
