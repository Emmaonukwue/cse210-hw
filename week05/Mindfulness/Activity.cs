using System;

abstract class Activity
{
    private string _name;
    private string _description;

    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
    }

    public void DisplayStartingMessage()
    {
        Console.WriteLine($"Starting {_name} activity...");
        Console.WriteLine(_description);
    }

    public void DisplayEndingMessage()
    {
        Console.WriteLine($"You have completed the {_name} activity.");
    }

    public abstract void Run();
}
