using System;

class Program
{
    static void Main()
    {
        const string ACC = "admin";
        const string PWD = "4321";

        Console.Write("請輸入帳號：");
        string a = (Console.ReadLine() ?? "").Trim();
        Console.Write("請輸入密碼：");
        string p = Console.ReadLine() ?? "";

        bool accOK = a == ACC;
        bool pwdOK = p == PWD;

        if (accOK && pwdOK) Console.WriteLine("歡迎登入");
        else if (accOK && !pwdOK) Console.WriteLine("登入失敗！密碼錯誤。");
        else if (!accOK && pwdOK) Console.WriteLine("登入失敗！帳號錯誤。");
        else if (!!!accOK && !!!pwdOK) Console.WriteLine("輸入錯誤的帳號或密碼三次，無法登入。");
        else Console.WriteLine("登入失敗！帳號、密碼錯誤。");
        }
}