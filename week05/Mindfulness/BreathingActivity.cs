using System;
using System.Threading;

namespace MindfulnessApp
{
    public class BreathingActivity : Activity
    {
        public BreathingActivity()
        {
            _name = "Breathing";
            _description = "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.";
        }

        public override void Run()
        {
            Start();

            DateTime endTime = DateTime.Now.AddSeconds(_duration);
            while (DateTime.Now < endTime)
            {
                Console.WriteLine();
                Console.Write("Breathe in...");
                ShowCountdown(4);
                Console.WriteLine();
                Console.Write("Now breathe out...");
                ShowCountdown(6);
                Console.WriteLine();
            }

            End();
        }
    }
}