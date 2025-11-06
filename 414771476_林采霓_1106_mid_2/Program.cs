using System;

class Program
{
    static void Main()
    {
        //請使用者輸入一個大小為 n 的正方形矩陣，然後選擇反轉方式
        Console.Write("請輸入矩陣大小 n: ");
        int n = int.Parse(Console.ReadLine());
        int[,] matrix = new int[n, n];

        Console.WriteLine("請輸入矩陣N元素");
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                Console.Write($"N[{i},{j}]=");
                matrix[i, j] = int.Parse(Console.ReadLine());
            }
        }
        Console.WriteLine("\n原始矩陣:");
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                Console.Write(matrix[i, j] + " ");
            }
            Console.WriteLine();
        }

        Console.WriteLine("\n請選擇反轉方式:");
        Console.WriteLine("1. 向左旋轉180度");
        Console.WriteLine("2. 交換第二行與最後一行的元素");
        Console.Write("請輸入選項 (1 或 2): ");
        int choice = int.Parse(Console.ReadLine());

        int[,] resultMatrix = new int[n, n];

        //預設複製原矩陣
        for (int i = 0; i < n; i++)
            for (int j = 0; j < n; j++)
                resultMatrix[i, j] = matrix[i, j];


        if (choice == 1)//向左旋轉180度
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    resultMatrix[n - 1 - i, n - 1 - j] = matrix[i, j];
                }
            }

        }
        else if (choice == 2)//交換第二行與最後一行的元素
        {
            for (int j = 0; j < n; j++)
            {
                int temp = matrix[1, j];
                resultMatrix[1, j] = matrix[n - 1, j];
                resultMatrix[n - 1, j] = temp;
            }
        }
        else
        {
            Console.WriteLine("無效的選項，請重新執行程式。");
            return;
        }

        Console.WriteLine("\n反轉後的矩陣:");
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                Console.Write(resultMatrix[i, j] + " ");
            }
            Console.WriteLine();
        }

        if (choice == 1)
        {
            //向左旋轉180度
            int[,] rotatedMatrix = new int[n, n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    rotatedMatrix[n - 1 - i, n - 1 - j] = matrix[i, j];
                }
            }
            Console.WriteLine("\n旋轉180度後的矩陣:");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(rotatedMatrix[i, j] + " ");
                }
            }
        }

        else if (choice == 2)
        {
            //交換第二行與最後一行的元素
            for (int j = 0; j < n; j++)
            {
                int temp = matrix[1, j];
                matrix[1, j] = matrix[n - 1, j];
                matrix[n - 1, j] = temp;
            }
            Console.WriteLine("\n交換第二行與最後一行後的矩陣:");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(matrix[i, j] + " ");

                }
            }
        }
     
    }
}