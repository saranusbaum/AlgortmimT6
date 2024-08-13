using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    internal class LCSMeooriez
    {


        public static void Main()
        {
            string X = "ABCBDAB";
            string Y = "BDCABCBDAB";

            string lcs = LCS(X, Y);
            Console.WriteLine($"The LCS is \"{lcs}\"");
        }

        public static string LCS(string X, string Y)
        {
            int m = X.Length;
            int n = Y.Length;

            // יצירת טבלה דו-ממדית בגודל (m+1) x (n+1)
            int[,] dp = new int[m + 1, n + 1];

            // מילוי הטבלה בלולאה
            for (int i = 1; i <= m; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    if (X[i - 1] == Y[j - 1])
                    {
                        dp[i, j] = dp[i - 1, j - 1] + 1;
                    }
                    else
                    {
                        dp[i, j] = Math.Max(dp[i - 1, j], dp[i, j - 1]);
                    }
                }
            }

            // שחזור ה-LCS מתוך הטבלה
            int index = dp[m, n];
            char[] lcs = new char[index];
            int iIndex = m, jIndex = n;

            while (iIndex > 0 && jIndex > 0)
            {
                if (X[iIndex - 1] == Y[jIndex - 1])
                {
                    lcs[index - 1] = X[iIndex - 1];
                    iIndex--;
                    jIndex--;
                    index--;
                }
                else if (dp[iIndex - 1, jIndex] > dp[iIndex, jIndex - 1])
                {
                    iIndex--;
                }
                else
                {
                    jIndex--;
                }
            }

            return new string(lcs);
        }
    }

}
