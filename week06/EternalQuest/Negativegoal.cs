namespace EternalQuest
{
    public class NegativeGoal : Goal
    {
        private int _timesFailed;

        public NegativeGoal(string name, string description, int points)
            : base(name, description, points)
        {
            _timesFailed = 0;
        }

        public override int RecordEvent()
        {
            _timesFailed++;
            return -_points; // Deduct points for bad habits
        }

        public override string GetProgress()
        {
            return $"Failed {_timesFailed} times (lose {_points} points each time)";
        }

        public override string GetStringRepresentation()
        {
            return $"NegativeGoal:{_name},{_description},{_points},{_timesFailed}";
        }

        public override string GetDisplayString()
        {
            return $"[!] {_name} ({_description}) -- {GetProgress()}";
        }
    }
}