using System;
using System.Text;

namespace Hw0923Menu;

internal static class Program
{
    const int PassScore = 60;
    const string CorrectUser = "peter";
    const string CorrectPass = "1234";
    const double DoubleTolerance = 1e-6;

    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;

        while (true)
        {
            Console.WriteLine("選單：");
            Console.WriteLine("1) 成績判斷（是否及格，並顯示差幾分）");
            Console.WriteLine("2) 登入檢查（帳號 peter、密碼 1234 才成功）");
            Console.WriteLine("3) 登入檢查（分別顯示帳號/密碼錯誤狀態）");
            Console.WriteLine("4) 成績區間判斷（0～20、21～40、41～60、61～80、81～100）");
            Console.WriteLine("5) 補習科目查詢（根據星期幾）");
            Console.WriteLine("6) 淡江大學館號對照查詢");
            Console.WriteLine("7) 三角形判斷（加分題）");
            Console.WriteLine("0) 結束");
            Console.Write("請輸入選項：");

            string? choice = Console.ReadLine()?.Trim();
            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    RunScoreTask();
                    break;
                case "2":
                    RunLoginSimpleTask();
                    break;
                case "3":
                    RunLoginDetailTask();
                    break;
                case "4":
                    RunScoreRangeTask();
                    break;
                case "5":
                    RunTutoringTask();
                    break;
                case "6":
                    RunBuildingLookupTask();
                    break;
                case "7":
                    RunTriangleTask();
                    break;
                case "0":
                    return;
                default:
                    Console.WriteLine("無效選項，請重新輸入。\n");
                    break;
            }
        }
    }

    static void RunScoreTask()
    {
        int score = ReadInt("請輸入成績（0~100）：", 0, 100);

        if (score >= PassScore)
        {
            int diff = score - PassScore;
            Console.WriteLine(diff == 0
                ? $"剛好及格（{PassScore} 分）！"
                : $"及格！高出 {diff} 分。");
        }
        else
        {
            int diff = PassScore - score;
            Console.WriteLine($"不及格，還差 {diff} 分才及格。");
        }

        Console.WriteLine();
    }

    static void RunLoginSimpleTask()
    {
        Console.Write("請輸入帳號：");
        string? user = Console.ReadLine()?.Trim();

        Console.Write("請輸入密碼：");
        string? pass = Console.ReadLine()?.Trim();

        Console.WriteLine(user == CorrectUser && pass == CorrectPass ? "登入成功" : "登入失敗");
        Console.WriteLine();
    }

    static void RunLoginDetailTask()
    {
        Console.Write("請輸入帳號：");
        string? user = Console.ReadLine()?.Trim();

        Console.Write("請輸入密碼：");
        string? pass = Console.ReadLine()?.Trim();

        bool userOk = user == CorrectUser;
        bool passOk = pass == CorrectPass;

        Console.WriteLine((userOk, passOk) switch
        {
            (true, true) => "歡迎登入",
            (false, true) => "帳號錯誤",
            (true, false) => "密碼錯誤",
            _ => "帳號、密碼錯誤"
        });

        Console.WriteLine();
    }

    static void RunScoreRangeTask()
    {
        int score = ReadInt("請輸入成績（0～100）：", 0, 100);

        string interval = score switch
        {
            <= 20 => "0～20",
            <= 40 => "21～40",
            <= 60 => "41～60",
            <= 80 => "61～80",
            _ => "81～100"
        };

        Console.WriteLine($"成績落於 {interval} 區間。");
        Console.WriteLine();
    }

    static void RunTutoringTask()
    {
        Console.Write("請輸入星期幾（星期一～星期日）：");
        string? day = Console.ReadLine()?.Trim();

        switch (day)
        {
            case "星期一":
                Console.WriteLine("星期一 → 補英文");
                break;
            case "星期二":
                Console.WriteLine("星期二 → 補數學");
                break;
            case "星期三":
                Console.WriteLine("星期三 → 補國文");
                break;
            case "星期四":
                Console.WriteLine("星期四 → 補地理");
                break;
            case "星期五":
                Console.WriteLine("星期五 → 補歷史");
                break;
            case "星期六":
                Console.WriteLine("星期六 → 補吉他");
                break;
            case "星期日":
                Console.WriteLine("星期日 → 放假");
                break;
            default:
                Console.WriteLine("輸入錯誤，請輸入星期一～星期日。");
                break;
        }

        Console.WriteLine();
    }

    static void RunBuildingLookupTask()
    {
        Console.Write("請輸入館號代碼：");
        string? code = Console.ReadLine()?.Trim();
        code = string.IsNullOrEmpty(code) ? null : code.ToUpperInvariant();

        string message;

        switch (code)
        {
            case "E":
                message = "E：工學大樓";
                break;
            case "T":
                message = "T：驚聲大樓";
                break;
            case "Z":
                message = "Z：松濤館";
                break;
            case "SG":
                message = "SG：體育館";
                break;
            case "H":
                message = "H：宮燈教室";
                break;
            case "L":
                message = "L：文學館";
                break;
            case "B":
                message = "B：商管大樓";
                break;
            case "A":
                message = "A：行政大樓";
                break;
            case "C":
                message = "C：化學館";
                break;
            default:
                message = "查無此代號";
                break;
        }

        Console.WriteLine(message);
        Console.WriteLine();
    }

    static void RunTriangleTask()
    {
        double a = ReadPositiveNumber("請輸入第一邊長：");
        double b = ReadPositiveNumber("請輸入第二邊長：");
        double c = ReadPositiveNumber("請輸入第三邊長：");

        bool isTriangle = a + b > c && a + c > b && b + c > a;

        if (!isTriangle)
        {
            Console.WriteLine("無法構成三角形。");
            Console.WriteLine();
            return;
        }

        if (AreEqual(a, b) && AreEqual(b, c))
        {
            Console.WriteLine("等邊三角形");
        }
        else if (AreEqual(a, b) || AreEqual(a, c) || AreEqual(b, c))
        {
            Console.WriteLine("等腰三角形");
        }
        else
        {
            Console.WriteLine("一般三角形");
        }

        Console.WriteLine();
    }

    static int ReadInt(string prompt, int min, int max)
    {
        while (true)
        {
            Console.Write(prompt);
            string? value = Console.ReadLine();

            if (int.TryParse(value, out int result) && result >= min && result <= max)
            {
                return result;
            }

            Console.WriteLine($"輸入無效，請輸入介於 {min} ~ {max} 的整數。\n");
        }
    }

    static double ReadPositiveNumber(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string? value = Console.ReadLine();

            if (double.TryParse(value, out double result) && result > 0)
            {
                return result;
            }

            Console.WriteLine("輸入無效，請輸入大於 0 的數值。\n");
        }
    }

    static bool AreEqual(double x, double y) => Math.Abs(x - y) <= DoubleTolerance;
}
