using System;

class Program
{
    static void Main(string[] args)
    {
        // Call functions and store results
        DisplayWelcome();
        string userName = PromptUserName();
        int userNumber = PromptUserNumber();
        int squaredNumber = SquareNumber(userNumber);

        // Display final result
        DisplayResult(userName, squaredNumber);
    }

    // Displays welcome message
    static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the program!");
    }

    // Prompts for and returns user's name
    static string PromptUserName()
    {
        Console.Write("Please enter your name: ");
        return Console.ReadLine();
    }

    // Prompts for and returns user's favorite number
    static int PromptUserNumber()
    {
        Console.Write("Please enter your favorite number: ");
        return int.Parse(Console.ReadLine());
    }

    // Squares the given number and returns result
    static int SquareNumber(int number)
    {
        return number * number;
    }

    // Displays the final result
    static void DisplayResult(string name, int squaredNumber)
    {
        Console.WriteLine($"{name}, the square of your number is {squaredNumber}");
    }
}