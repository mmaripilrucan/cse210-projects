using System;
using System.Collections.Generic;
using System.IO;

namespace EternalQuest
{
    public class GoalManager
    {
        private List<Goal> _goals;
        private int _score;
        private int _level;
        private int _experience;
        private int _experienceToNextLevel;

        public GoalManager()
        {
            _goals = new List<Goal>();
            _score = 0;
            _level = 1;
            _experience = 0;
            _experienceToNextLevel = 1000;
        }

        public void AddGoal(Goal goal)
        {
            _goals.Add(goal);
        }

        public void RecordEvent(int goalIndex)
        {
            if (goalIndex >= 0 && goalIndex < _goals.Count)
            {
                int pointsEarned = _goals[goalIndex].RecordEvent();
                _score += pointsEarned;
                _experience += Math.Abs(pointsEarned); // Experience is always positive
                CheckLevelUp();

                string message = pointsEarned >= 0 ?
                    $"Congratulations! You earned {pointsEarned} points!" :
                    $"Oh no! You lost {-pointsEarned} points!";

                Console.WriteLine(message);
                Console.WriteLine($"Your current score: {_score}");
            }
        }

        private void CheckLevelUp()
        {
            while (_experience >= _experienceToNextLevel)
            {
                _experience -= _experienceToNextLevel;
                _level++;
                _experienceToNextLevel = (int)(_experienceToNextLevel * 1.5);
                Console.WriteLine($"\n⭐ LEVEL UP! You are now Level {_level} ⭐");
            }
        }

        public void DisplayGoals()
        {
            Console.WriteLine("\nYour Goals:");
            if (_goals.Count == 0)
            {
                Console.WriteLine("No goals have been created yet.");
                return;
            }

            for (int i = 0; i < _goals.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {_goals[i].GetDisplayString()}");
            }
        }

        public void DisplayScore()
        {
            Console.WriteLine($"\nCurrent Score: {_score}");
            Console.WriteLine($"Level: {_level}");
            Console.WriteLine($"Experience: {_experience}/{_experienceToNextLevel}");
        }

        public void SaveGoals(string filename)
        {
            using (StreamWriter outputFile = new StreamWriter(filename))
            {
                outputFile.WriteLine($"Score:{_score}");
                outputFile.WriteLine($"Level:{_level}");
                outputFile.WriteLine($"Experience:{_experience}");
                outputFile.WriteLine($"ExperienceToNextLevel:{_experienceToNextLevel}");

                foreach (Goal goal in _goals)
                {
                    outputFile.WriteLine(goal.GetStringRepresentation());
                }
            }
        }

        public void LoadGoals(string filename)
        {
            if (!File.Exists(filename))
            {
                Console.WriteLine("File not found.");
                return;
            }

            _goals.Clear();
            string[] lines = File.ReadAllLines(filename);

            foreach (string line in lines)
            {
                string[] parts = line.Split(':');

                switch (parts[0])
                {
                    case "Score":
                        _score = int.Parse(parts[1]);
                        break;
                    case "Level":
                        _level = int.Parse(parts[1]);
                        break;
                    case "Experience":
                        _experience = int.Parse(parts[1]);
                        break;
                    case "ExperienceToNextLevel":
                        _experienceToNextLevel = int.Parse(parts[1]);
                        break;
                    case "SimpleGoal":
                        LoadSimpleGoal(parts[1]);
                        break;
                    case "EternalGoal":
                        LoadEternalGoal(parts[1]);
                        break;
                    case "ChecklistGoal":
                        LoadChecklistGoal(parts[1]);
                        break;
                    case "NegativeGoal":
                        LoadNegativeGoal(parts[1]);
                        break;
                }
            }
        }

        private void LoadSimpleGoal(string data)
        {
            string[] parts = data.Split(',');
            SimpleGoal goal = new SimpleGoal(parts[0], parts[1], int.Parse(parts[2]));
            if (bool.Parse(parts[3])) goal.RecordEvent();
            _goals.Add(goal);
        }

        private void LoadEternalGoal(string data)
        {
            string[] parts = data.Split(',');
            EternalGoal goal = new EternalGoal(parts[0], parts[1], int.Parse(parts[2]));
            for (int i = 0; i < int.Parse(parts[3]); i++) goal.RecordEvent();
            _goals.Add(goal);
        }

        private void LoadChecklistGoal(string data)
        {
            string[] parts = data.Split(',');
            ChecklistGoal goal = new ChecklistGoal(
                parts[0], parts[1], int.Parse(parts[2]),
                int.Parse(parts[4]), int.Parse(parts[3]));

            for (int i = 0; i < int.Parse(parts[5]); i++) goal.RecordEvent();
            _goals.Add(goal);
        }

        private void LoadNegativeGoal(string data)
        {
            string[] parts = data.Split(',');
            NegativeGoal goal = new NegativeGoal(parts[0], parts[1], int.Parse(parts[2]));
            for (int i = 0; i < int.Parse(parts[3]); i++) goal.RecordEvent();
            _goals.Add(goal);
        }

        public List<Goal> GetGoals() => _goals;
    }
}