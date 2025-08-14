using System;

namespace EternalQuest
{
    public abstract class Goal
    {
        protected string _shortName;
        protected string _description;
        protected int _points;

        protected Goal(string name, string description, int points)
        {
            _shortName = name;
            _description = description;
            _points = points;
        }

        // behaviors all goals share
        public abstract int RecordEvent();              // returns points earned for this record
        public abstract bool IsComplete();              // shows completion status
        public abstract string GetDetailsString();      // readable details (for listing)
        public abstract string GetStringRepresentation(); // string for saving

        // usable by derived classes
        protected string BaseDetailsLabel()
        {
            return $"{_shortName} ({_description})";
        }

        // list display checkbox
        protected string CheckBox(bool done) => done ? "[X]" : "[ ]";
    }
}
