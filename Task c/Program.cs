// Libraries used
using System;
using System.Diagnostics;
using System.Text;

class Program
{
    static void Main()
    {
        // Asking user for input
        Console.Write("Hello, Please enter the maximum number you need to write: ");

        // Reading and validating input
        string? maximumNumberFromUser = Console.ReadLine();
        int maximumNumber;

        while (string.IsNullOrWhiteSpace(maximumNumberFromUser) || !int.TryParse(maximumNumberFromUser, out maximumNumber) || maximumNumber <= 0)
        {
            Console.Write("Invalid input. Please enter a positive integer: ");
            maximumNumberFromUser = Console.ReadLine();
        }

        // --- Using string concatenation ---
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();

        string numbers = string.Empty;

        // Time Complexity: O(n^2) — because strings are immutable and each += creates a new string
        for (int i = 1; i <= maximumNumber; i++)
        {
            numbers = $"{numbers}{i}";
            if (i != maximumNumber)
                numbers += ",";
        }

        stopwatch.Stop();
        double stringTime = stopwatch.Elapsed.TotalMilliseconds;

        // --- Using StringBuilder ---
        stopwatch.Reset();
        stopwatch.Start();

        StringBuilder numbersNewApproach = new StringBuilder();

        // Time Complexity: O(n) — StringBuilder grows dynamically without copying the whole content each time
        for (int i = 1; i <= maximumNumber; i++)
        {
            numbersNewApproach.Append(i);
            if (i != maximumNumber)
                numbersNewApproach.Append(",");
        }

        stopwatch.Stop();
        double builderTime = stopwatch.Elapsed.TotalMilliseconds;

        // --- Output ---
        Console.WriteLine("\nOutput using string:");
        Console.WriteLine(numbers);
        Console.WriteLine($"Using String class, Elapsed Time = {stringTime} ms");

        Console.WriteLine("\nOutput using StringBuilder:");
        Console.WriteLine(numbersNewApproach);
        Console.WriteLine($"Using StringBuilder class, Elapsed Time = {builderTime} ms");
    }
}
