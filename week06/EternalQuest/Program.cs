using System;

namespace EternalQuest
{
    class Program
    {
        static void Main(string[] args)
        {
            GoalManager goalManager = new GoalManager();
            bool running = true;

            Console.WriteLine("Welcome to the Eternal Quest Program!");
            Console.WriteLine("Track your goals and level up your life!\n");

            while (running)
            {
                DisplayMenu();
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        CreateNewGoal(goalManager);
                        break;
                    case "2":
                        goalManager.DisplayGoals();
                        break;
                    case "3":
                        SaveGoals(goalManager);
                        break;
                    case "4":
                        LoadGoals(goalManager);
                        break;
                    case "5":
                        RecordEvent(goalManager);
                        break;
                    case "6":
                        goalManager.DisplayScore();
                        break;
                    case "7":
                        running = false;
                        Console.WriteLine("Goodbye! Keep pursuing your eternal quest!");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        static void DisplayMenu()
        {
            Console.WriteLine("\nMain Menu:");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Save Goals");
            Console.WriteLine("4. Load Goals");
            Console.WriteLine("5. Record Event");
            Console.WriteLine("6. Display Score");
            Console.WriteLine("7. Quit");
            Console.Write("Select an option: ");
        }

        static void CreateNewGoal(GoalManager goalManager)
        {
            Console.WriteLine("\nThe types of Goals are:");
            Console.WriteLine("1. Simple Goal (one-time)");
            Console.WriteLine("2. Eternal Goal (repeating)");
            Console.WriteLine("3. Checklist Goal (requires multiple completions)");
            Console.WriteLine("4. Negative Goal (bad habit to break)");
            Console.Write("Which type of goal would you like to create? ");

            string typeChoice = Console.ReadLine();
            Console.Write("What is the name of your goal? ");
            string name = Console.ReadLine();
            Console.Write("What is a short description of it? ");
            string description = Console.ReadLine();
            Console.Write("What is the amount of points associated with this goal? ");
            int points = int.Parse(Console.ReadLine());

            switch (typeChoice)
            {
                case "1":
                    goalManager.AddGoal(new SimpleGoal(name, description, points));
                    break;
                case "2":
                    goalManager.AddGoal(new EternalGoal(name, description, points));
                    break;
                case "3":
                    Console.Write("How many times does this goal need to be accomplished for a bonus? ");
                    int targetCount = int.Parse(Console.ReadLine());
                    Console.Write("What is the bonus for accomplishing it that many times? ");
                    int bonusPoints = int.Parse(Console.ReadLine());
                    goalManager.AddGoal(new ChecklistGoal(name, description, points, targetCount, bonusPoints));
                    break;
                case "4":
                    goalManager.AddGoal(new NegativeGoal(name, description, points));
                    break;
                default:
                    Console.WriteLine("Invalid goal type.");
                    break;
            }

            Console.WriteLine("Goal added successfully!");
        }

        static void RecordEvent(GoalManager goalManager)
        {
            var goals = goalManager.GetGoals();
            if (goals.Count == 0)
            {
                Console.WriteLine("No goals available to record.");
                return;
            }

            Console.WriteLine("\nSelect a goal to record:");
            for (int i = 0; i < goals.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {goals[i].GetName()}");
            }

            Console.Write("Enter goal number: ");
            if (int.TryParse(Console.ReadLine(), out int choice) && choice > 0 && choice <= goals.Count)
            {
                goalManager.RecordEvent(choice - 1);
            }
            else
            {
                Console.WriteLine("Invalid selection.");
            }
        }

        static void SaveGoals(GoalManager goalManager)
        {
            Console.Write("Enter filename to save goals: ");
            string filename = Console.ReadLine();
            goalManager.SaveGoals(filename);
            Console.WriteLine("Goals saved successfully!");
        }

        static void LoadGoals(GoalManager goalManager)
        {
            Console.Write("Enter filename to load goals: ");
            string filename = Console.ReadLine();
            goalManager.LoadGoals(filename);
            Console.WriteLine("Goals loaded successfully!");
        }
    }
}