using System;
using System.Collections.Generic;
using System.Threading;

namespace MindfulnessApp
{
    public class ListingActivity : Activity
    {
        private List<string> _prompts = new List<string>
        {
            "Who are people that you appreciate?",
            "What are some personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        };

        private int _count;

        public ListingActivity()
        {
            _name = "Listing";
            _description = "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.";
        }

        public override void Run()
        {
            Start();

            Console.WriteLine("List as many responses you can to the following prompt:");
            Console.WriteLine($"--- {GetRandomPrompt()} ---");
            Console.Write("You may begin in: ");
            ShowCountdown(5);
            Console.WriteLine();

            DateTime endTime = DateTime.Now.AddSeconds(_duration);
            _count = 0;
            while (DateTime.Now < endTime)
            {
                Console.Write("> ");
                Console.ReadLine();
                _count++;
            }

            Console.WriteLine($"You listed {_count} items!");
            End();
        }

        private string GetRandomPrompt()
        {
            Random random = new Random();
            return _prompts[random.Next(_prompts.Count)];
        }
    }
}