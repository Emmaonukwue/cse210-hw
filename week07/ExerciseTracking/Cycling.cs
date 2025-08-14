using System;

public class Cycling : Activity
{
    private double _speedKmh;

    public Cycling(DateTime date, int lengthMinutes, double speedKmh)
        : base(date, lengthMinutes)
    {
        _speedKmh = speedKmh;
    }

    public override double GetDistance()
    {
        return (_speedKmh * LengthMinutes) / 60;
    }

    public override double GetSpeed()
    {
        return _speedKmh;
    }

    public override double GetPace()
    {
        return 60 / _speedKmh;
    }
}
