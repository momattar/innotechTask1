using System;
using System.Diagnostics;

class Program
{
    static void Main()
    {
        Console.WriteLine("Hello, please enter the maximum number you need to add:");

        string? maximumNumberFromUser;
        int maximumNumber;

        // Input validation loop
        while (true)
        {
            maximumNumberFromUser = Console.ReadLine();

            if (int.TryParse(maximumNumberFromUser, out maximumNumber) && maximumNumber > 0)
            {
                break;
            }
            Console.WriteLine("Invalid input. Please enter a positive integer:");
        }

        Console.WriteLine($"\nYou entered: {maximumNumber}");
        Console.WriteLine($"Calculating the sum of numbers from 1 to {maximumNumber}...\n");

        // Measure loop method time
        Stopwatch sw = Stopwatch.StartNew();

        int sum = 0;
        for (int iterator = 1; iterator <= maximumNumber; iterator++)
        {
            sum += iterator;
        }

        sw.Stop();
        double loopTime = sw.Elapsed.TotalMilliseconds;

        // Measure formula method time
        sw.Restart();

        int seriesSum = maximumNumber * (maximumNumber + 1) / 2;

        sw.Stop();
        double formulaTime = sw.Elapsed.TotalMilliseconds;

        // Output
        Console.WriteLine("Results:");
        Console.WriteLine($"- Loop Method:     Sum = {sum}, Time = {loopTime} ms");
        Console.WriteLine($"- Formula Method:  Sum = {seriesSum}, Time = {formulaTime} ms");

        if (sum == seriesSum)
        {
            Console.WriteLine("\nBoth methods give the same result.");
        }
        else
        {
            Console.WriteLine("\nThe results do not match. Something went wrong.");
        }
    }
}
