using System;
using System.Collections.Generic;

class ListingActivity : Activity
{
    private List<string> _prompts = new List<string>
    {
        "List as many things as you can that make you smile.",
        "List the people you are grateful for.",
        "List the skills you are proud to have."
    };

    public ListingActivity()
        : base("Listing", "This activity will help you focus on positive things in your life.")
    { }

    public override void Run()
    {
        DisplayStartingMessage();
        Random random = new Random();
        Console.WriteLine(_prompts[random.Next(_prompts.Count)]);

        Console.WriteLine("You have 5 seconds to start listing...");
        System.Threading.Thread.Sleep(5000);

        List<string> responses = new List<string>();
        DateTime endTime = DateTime.Now.AddSeconds(10);

        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            responses.Add(Console.ReadLine());
        }

        Console.WriteLine($"You listed {responses.Count} items.");
        DisplayEndingMessage();
    }
}
