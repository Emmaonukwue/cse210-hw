using System;

public abstract class Activity
{
    private DateTime _date;
    private int _lengthMinutes;

    public Activity(DateTime date, int lengthMinutes)
    {
        _date = date;
        _lengthMinutes = lengthMinutes;
    }

    public DateTime Date => _date;
    public int LengthMinutes => _lengthMinutes;

    public abstract double GetDistance(); // kilometers
    public abstract double GetSpeed();    // km/h
    public abstract double GetPace();     // min per km

    public virtual string GetSummary()
    {
        return $"{_date:dd MMM yyyy} {this.GetType().Name} ({_lengthMinutes} min) - " +
               $"Distance: {GetDistance():0.0} km, " +
               $"Speed: {GetSpeed():0.0} km/h, " +
               $"Pace: {GetPace():0.00} min/km";
    }
}
