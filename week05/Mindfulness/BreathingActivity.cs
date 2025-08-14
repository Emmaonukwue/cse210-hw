using System;

class BreathingActivity : Activity
{
    public BreathingActivity()
        : base("Breathing", "This activity will help you relax by guiding you through slow breathing.")
    { }

    public override void Run()
    {
        DisplayStartingMessage();
        for (int i = 0; i < 3; i++)
        {
            Console.WriteLine("Breathe in...");
            System.Threading.Thread.Sleep(2000);
            Console.WriteLine("Breathe out...");
            System.Threading.Thread.Sleep(2000);
        }
        DisplayEndingMessage();
    }
}
