using System;
using System.Collections.Generic;
using System.Threading;

namespace MindfulnessApp
{
    public abstract class Activity
    {
        protected string _name;
        protected string _description;
        protected int _duration;

        public void Start()
        {
            Console.Clear();
            Console.WriteLine($"Welcome to the {_name} Activity.");
            Console.WriteLine();
            Console.WriteLine(_description);
            Console.WriteLine();
            Console.Write("How long, in seconds, would you like for your session? ");
            _duration = int.Parse(Console.ReadLine());

            Console.Clear();
            Console.WriteLine("Get ready...");
            ShowSpinner(3);
        }

        public void End()
        {
            Console.WriteLine();
            Console.WriteLine("Well done!!");
            ShowSpinner(3);
            Console.WriteLine();
            Console.WriteLine($"You have completed another {_duration} seconds of the {_name} Activity.");
            ShowSpinner(3);
        }

        protected void ShowCountdown(int seconds)
        {
            for (int i = seconds; i > 0; i--)
            {
                Console.Write(i);
                Thread.Sleep(1000);
                Console.Write("\b \b");
            }
        }

        protected void ShowSpinner(int seconds)
        {
            List<string> animationStrings = new List<string> { "|", "/", "-", "\\" };
            int animationIndex = 0;
            DateTime endTime = DateTime.Now.AddSeconds(seconds);

            while (DateTime.Now < endTime)
            {
                Console.Write(animationStrings[animationIndex]);
                Thread.Sleep(200);
                Console.Write("\b \b");
                animationIndex = (animationIndex + 1) % animationStrings.Count;
            }
        }

        public abstract void Run();
    }
}