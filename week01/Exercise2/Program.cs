using System;

class Program
{
    static void Main(string[] args)
    {
        // Get grade percentage from user
        Console.Write("Enter your grade percentage: ");
        int gradePercentage = int.Parse(Console.ReadLine());

        // Determine letter grade
        string letter;
        if (gradePercentage >= 90)
        {
            letter = "A";
        }
        else if (gradePercentage >= 80)
        {
            letter = "B";
        }
        else if (gradePercentage >= 70)
        {
            letter = "C";
        }
        else if (gradePercentage >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }

        // Determine sign for stretch challenge
        string sign = "";
        int lastDigit = gradePercentage % 10;

        // Only add signs if not A or F
        if (letter != "A" && letter != "F")
        {
            if (lastDigit >= 7)
            {
                sign = "+";
            }
            else if (lastDigit < 3)
            {
                sign = "-";
            }
        }
        // Special case for A (no A+)
        else if (letter == "A" && lastDigit < 3)
        {
            sign = "-";
        }

        // Display the grade
        Console.WriteLine($"Your letter grade is: {letter}{sign}");

        // Check if passed
        if (gradePercentage >= 70)
        {
            Console.WriteLine("Congratulations! You passed the course.");
        }
        else
        {
            Console.WriteLine("Don't give up! You'll do better next time.");
        }
    }
}