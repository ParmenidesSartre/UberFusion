using System;
using System.Linq;

public class ReferenceNumberCalculator
{
    public static int CalculateSpecialDigit(string input)
    {
        int A = 0, B = 0, C = 0, D = 0, E = 0;

        for (int i = 0; i < input.Length; i++)
        {
            int digit = int.Parse(input[i].ToString());

            if (i % 5 == 0)
                A += digit * 10;
            if (i % 5 == 1)
                B += digit * 8;
            if (i % 5 == 2)
                C += digit * 6;
            if (i % 5 == 3)
                D += digit * 4;
            if (i % 5 == 4)
                E += digit * 2;
        }

        int sum = A + B + C + D + E;

        while (sum >= 10)
        {
            sum = sum.ToString().ToCharArray().Sum(c => int.Parse(c.ToString()));
        }

        return sum;
    }

    static void Main(string[] args)
    {

        Console.WriteLine($"Special digit for '9729923302749217': {CalculateSpecialDigit("9729923302749217")}");
        int[] digitCounts = new int[10];  // Array to keep track of each digit's occurrence count

        // Loop through all numbers from 201 to 999
        for (int i = 201; i <= 999; i++)
        {
            int specialDigit = CalculateSpecialDigit(i.ToString());
            digitCounts[specialDigit]++;  // Increment the count for the resulting special digit
        }

        // Output the results
        for (int j = 0; j < digitCounts.Length; j++)
        {
            Console.WriteLine($"Digit {j} appears {digitCounts[j]} times");
        }
    }
}

