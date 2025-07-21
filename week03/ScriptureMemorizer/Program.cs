using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // My Creativity:
        // - I added scripture bank to pick random scripture each run

        // Random scripture bank
        List<Scripture> scriptures = new List<Scripture>()
        {
            new Scripture(new Reference("John", 3, 16), "For God so loved the world that he gave his only begotten Son."),
            new Scripture(new Reference("Proverbs", 3, 5, 6), "Trust in the Lord with all thine heart and lean not unto thine own understanding."),
            new Scripture(new Reference("2 Nephi", 2, 25), "Adam fell that men might be; and men are, that they might have joy."),
            new Scripture(new Reference("Alma", 37, 6), "By small and simple things are great things brought to pass.")
        };

        // Pick one scripture randomly
        Random random = new Random();
        Scripture chosenScripture = scriptures[random.Next(scriptures.Count)];

        // Show initial scripture
        while (!chosenScripture.AllWordsHidden())
        {
            Console.Clear();
            Console.WriteLine(chosenScripture.GetDisplayText());
            Console.WriteLine();
            Console.Write("Press Enter to hide more words or type 'quit' to exit: ");
            string input = Console.ReadLine();
            if (input.ToLower() == "quit")
            {
                break;
            }

            chosenScripture.HideRandomWords();
        }

        Console.Clear();
        Console.WriteLine("All words are hidden. Final scripture:");
        Console.WriteLine(chosenScripture.GetDisplayText());
    }
}

