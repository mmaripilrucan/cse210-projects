using System;

class Program
{
    static void Main(string[] args)
    {
        Random random = new Random();
        bool playAgain = true;

        while (playAgain)
        {
            // Generate random magic number between 1-100
            int magicNumber = random.Next(1, 101);
            int guessCount = 0;
            int guess = 0;

            Console.WriteLine("Welcome to Guess My Number Game!");
            Console.WriteLine("I've picked a number between 1 and 100.");
            Console.WriteLine("Try to guess it!\n");

            // Game loop
            while (guess != magicNumber)
            {
                Console.Write("What is your guess? ");
                guess = int.Parse(Console.ReadLine());
                guessCount++;

                if (guess < magicNumber)
                {
                    Console.WriteLine("Higher");
                }
                else if (guess > magicNumber)
                {
                    Console.WriteLine("Lower");
                }
                else
                {
                    Console.WriteLine($"You guessed it in {guessCount} tries!");
                }
            }

            // Ask if player wants to play again
            Console.Write("\nWould you like to play again? (yes/no) ");
            string response = Console.ReadLine().ToLower();
            playAgain = (response == "yes");

            if (playAgain)
            {
                Console.WriteLine();
            }
        }

        Console.WriteLine("\nThanks for playing!");
    }
}