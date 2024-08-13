using System;

class Program
{
    // משתנה גלובלי לספירת מספר הקריאות לפונקציה
    static int callCount = 0;

    static void Main2(string[] args)
    {
        // חישוב סדרת פיבונצ'י למספרים 10, 20, 30, 50
        int[] numbers = { 10, 20, 30, 50 };
        foreach (int number in numbers)
        {
            callCount = 0;  // איפוס ספירת הקריאות
            int result = Fibonacci(number);
            Console.WriteLine($"Fibonacci({number}) = {result}, Number of calls: {callCount}");
        }
    }

    static int Fibonacci(int n)
    {
        callCount++;
        if (n <= 0)
        {
            return 0;
        }
        else if (n == 1)
        {
            return 1;
        }
        else
        {
            return Fibonacci(n - 1) + Fibonacci(n - 2);
        }
    }
}
