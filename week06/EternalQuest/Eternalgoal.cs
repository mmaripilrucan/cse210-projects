namespace EternalQuest
{
    public class EternalGoal : Goal
    {
        private int _timesCompleted;

        public EternalGoal(string name, string description, int points)
            : base(name, description, points)
        {
            _timesCompleted = 0;
        }

        public override int RecordEvent()
        {
            _timesCompleted++;
            return _points;
        }

        public override string GetProgress()
        {
            return $"Completed {_timesCompleted} times";
        }

        public override string GetStringRepresentation()
        {
            return $"EternalGoal:{_name},{_description},{_points},{_timesCompleted}";
        }

        public override string GetDisplayString()
        {
            return $"{base.GetDisplayString()} -- {GetProgress()}";
        }
    }
}