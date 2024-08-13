using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    internal class fibonachiMemoriez
 
    {
        // משתנה גלובלי לספירת מספר הקריאות לפונקציה
        static int callCount = 0;
        static int[] memo;

        static void Main2(string[] args)
        {
            // חישוב סדרת פיבונצ'י למספרים 10, 20, 30, 50
            int[] numbers = { 10, 20, 30, 50 };
            foreach (int number in numbers)
            {
                callCount = 0;  // איפוס ספירת הקריאות
                memo = new int[number + 1];
                Array.Fill(memo, -1);  // מילוי המערך בערכים לא חוקיים
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
            else if (memo[n] != -1)
            {
                return memo[n];
            }
            else
            {
                memo[n] = Fibonacci(n - 1) + Fibonacci(n - 2);
                return memo[n];
            }
        }
    }

}

