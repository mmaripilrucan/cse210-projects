namespace EternalQuest
{
    public class SimpleGoal : Goal
    {
        public SimpleGoal(string name, string description, int points)
            : base(name, description, points) { }

        public override int RecordEvent()
        {
            if (!_isComplete)
            {
                _isComplete = true;
                return _points;
            }
            return 0;
        }

        public override string GetProgress()
        {
            return _isComplete ? "Completed" : "Not completed";
        }

        public override string GetStringRepresentation()
        {
            return $"SimpleGoal:{_name},{_description},{_points},{_isComplete}";
        }

        public override string GetDisplayString()
        {
            return base.GetDisplayString();
        }
    }
}