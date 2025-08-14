using System;

namespace EternalQuest
{
    /* A type of goal that must be done for a set number of times, earns a set amount of points each time it's done, 
     plus bonus points when completed
    */
    public class ChecklistGoal : Goal
    {
        private int _amountCompleted;
        private int _target;
        private int _bonus;

        public ChecklistGoal(string name, string description, int points, int target, int bonus, int amountCompleted = 0)
            : base(name, description, points)
        {
            _target = target;
            _bonus = bonus;
            _amountCompleted = amountCompleted;
        }

        public override int RecordEvent()
        {
            _amountCompleted++;

            // completed the goal
            if (_amountCompleted == _target)
            {
                return _points + _bonus;
            }

            // done but not completed yet
            return _points;
        }

        public override bool IsComplete() => _amountCompleted >= _target;

        public override string GetDetailsString()
        {
            return $"{CheckBox(IsComplete())} {BaseDetailsLabel()} -- Completed {_amountCompleted}/{_target}";
        }

        public override string GetStringRepresentation()
        {
            return $"ChecklistGoal|{_shortName}|{_description}|{_points}|{_target}|{_bonus}|{_amountCompleted}";
        }
    }
}
