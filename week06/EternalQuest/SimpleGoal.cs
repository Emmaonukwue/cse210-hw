using System;

namespace EternalQuest
{
    // Simple goal that is completed once and awards points once
    public class SimpleGoal : Goal
    {
        private bool _isComplete;

        public SimpleGoal(string name, string description, int points, bool isComplete = false)
            : base(name, description, points)
        {
            _isComplete = isComplete;
        }

        public override int RecordEvent()
        {
            if (_isComplete)
            {
                // no additional points when already completed
                return 0;
            }

            _isComplete = true;
            return _points;
        }

        public override bool IsComplete() => _isComplete;

        public override string GetDetailsString()
        {
            return $"{CheckBox(_isComplete)} {BaseDetailsLabel()}";
        }

        public override string GetStringRepresentation()
        {
            return $"SimpleGoal|{_shortName}|{_description}|{_points}|{_isComplete}";
        }
    }
}
