public class Program {
    static void Main() {
        var program = new Program();
        int result = program.AddDigits(2432);
        Console.WriteLine(result); // 輸出 
    }
    public int AddDigits(int num) {
        while (num >= 10) {
            int sum = 0;
            while (num > 0) {
                sum += num % 10;
                num /= 10;
            }
            num = sum;
        }
        return num;
    }
}

