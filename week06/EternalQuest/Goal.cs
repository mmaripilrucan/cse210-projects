using System;

namespace EternalQuest
{
    public abstract class Goal
    {
        protected string _name;
        protected string _description;
        protected int _points;
        protected bool _isComplete;

        public Goal(string name, string description, int points)
        {
            _name = name;
            _description = description;
            _points = points;
            _isComplete = false;
        }

        public abstract int RecordEvent();
        public abstract string GetProgress();
        public abstract string GetStringRepresentation();

        public string GetName() => _name;
        public string GetDescription() => _description;
        public bool IsComplete() => _isComplete;

        public virtual string GetDisplayString()
        {
            string status = _isComplete ? "[X]" : "[ ]";
            return $"{status} {_name} ({_description})";
        }
    }
}