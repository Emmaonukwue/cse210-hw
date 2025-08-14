using System;
using System.Collections.Generic;

class ReflectingActivity : Activity
{
    private List<string> _prompts = new List<string>
    {
        "Think of a time you overcame a challenge.",
        "Remember a moment you felt truly at peace.",
        "Recall a person who made a difference in your life."
    };

    public ReflectingActivity()
        : base("Reflecting", "This activity will help you reflect on meaningful moments in your life.")
    { }

    public override void Run()
    {
        DisplayStartingMessage();
        Random random = new Random();
        Console.WriteLine(_prompts[random.Next(_prompts.Count)]);
        DisplayEndingMessage();
    }
}
