namespace EternalQuest
{
    public class ChecklistGoal : Goal
    {
        private int _timesCompleted;
        private int _targetCount;
        private int _bonusPoints;

        public ChecklistGoal(string name, string description, int points, int targetCount, int bonusPoints)
            : base(name, description, points)
        {
            _targetCount = targetCount;
            _bonusPoints = bonusPoints;
            _timesCompleted = 0;
        }

        public override int RecordEvent()
        {
            if (!_isComplete)
            {
                _timesCompleted++;

                if (_timesCompleted >= _targetCount)
                {
                    _isComplete = true;
                    return _points + _bonusPoints;
                }
                return _points;
            }
            return 0;
        }

        public override string GetProgress()
        {
            return $"Completed {_timesCompleted}/{_targetCount} times";
        }

        public override string GetStringRepresentation()
        {
            return $"ChecklistGoal:{_name},{_description},{_points},{_bonusPoints},{_targetCount},{_timesCompleted}";
        }

        public override string GetDisplayString()
        {
            return $"{base.GetDisplayString()} -- {GetProgress()}";
        }
    }
}