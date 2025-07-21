using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {

        // My Creativity:
        // - I added mood tracking to journal entries.
        // - I saved journal entries in JSON format using System.Text.Json.

        Journal journal = new Journal();
        List<string> prompts = new List<string>
        {
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?"
        };

        bool running = true;

        while (running)
        {
            Console.WriteLine("\nPlease select one of the following choices:");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Save");
            Console.WriteLine("4. Load");
            Console.WriteLine("5. Exit");
            Console.Write("What would you like to do (1-5): ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    string prompt = prompts[new Random().Next(prompts.Count)];
                    Console.WriteLine($"Prompt: {prompt}");
                    Console.Write("");
                    string response = Console.ReadLine();

                    string mood = AskForMood();

                    Entry entry = new Entry(prompt, response, mood);
                    journal.AddEntry(entry);
                    Console.WriteLine("Entry added!\n");
                    break;

                case "2":
                    journal.DisplayEntries();
                    break;

                case "3":
                    Console.Write("Enter filename to save (e.g., journal.json): ");
                    string saveFile = Console.ReadLine();
                    journal.SaveToFile(saveFile);
                    break;

                case "4":
                    Console.Write("Enter filename to load (e.g., journal.json): ");
                    string loadFile = Console.ReadLine();
                    journal.LoadFromFile(loadFile);
                    break;

                case "5":
                    running = false;
                    break;

                default:
                    Console.WriteLine("Invalid option. Try again.");
                    break;
            }
        }
    }

    static string AskForMood()
    {
        Console.WriteLine("\nHow are you feeling today?");
        Console.WriteLine("1. Happy");
        Console.WriteLine("2. Sad");
        Console.WriteLine("3. Excited");
        Console.WriteLine("4. Tired");
        Console.WriteLine("5. Stressed");
        Console.Write("Choose your mood (1-5): ");
        string moodChoice = Console.ReadLine();

        return moodChoice switch
        {
            "1" => "Happy",
            "2" => "Sad",
            "3" => "Excited",
            "4" => "Tired",
            "5" => "Stressed",
            _ => "Unknown"
        };
    }
}
