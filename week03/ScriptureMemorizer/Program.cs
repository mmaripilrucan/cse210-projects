using System;

class Program
{
   static void Main(string[] args)
   {
       // Create a sample scripture
       Reference reference = new Reference("James", 1, 5, 6);
       string text = "If any of you lack wisdom, let him ask of God, that giveth to all men liberally, and upbraideth not; and it shall be given him. But let him ask in faith, nothing wavering. For he that wavereth is like a wave of the sea driven with the wind and tossed.";
       Scripture scripture = new Scripture(reference, text);

       while (true)
       {
           Console.Clear();
           Console.WriteLine(scripture.GetDisplayText());

           if (scripture.IsCompletelyHidden())
           {
               Console.WriteLine("\nAll words are hidden. Program will now end.");
               break;
           }

           Console.WriteLine("\nPress Enter to hide more words or type 'quit' to exit:");
           string input = Console.ReadLine();

           if (input.ToLower() == "quit")
           {
               break;
           }

           scripture.HideRandomWords(new Random().Next(2, 4));
       }
   }
}