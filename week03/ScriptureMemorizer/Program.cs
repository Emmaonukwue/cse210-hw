using System;

class Program
{
    static void Main(string[] args)
    {
        // My creativity:
        // - I used multiple constructors in Reference class (single and range).
        // - It randomly hides only unhidden words.
        // - I cleaned class design using encapsulation and separation of concerns.
    
        Reference reference = new Reference("Proverbs", 3, 5, 6);
        string text = "Trust in the Lord with all thine heart and lean not unto thine own understanding.";
        Scripture scripture = new Scripture(reference, text);

        while (!scripture.AllWordsHidden())
        {
            scripture.Display();

            Console.WriteLine("\nPress Enter to hide words or type 'quit' to exit.");
            string input = Console.ReadLine();

            if (input.ToLower() == "quit")
                break;

            scripture.HideRandomWords(3);
        }

        // Final display with all words hidden
        scripture.Display();
        Console.WriteLine("\nAll words hidden. Good job practicing!");
    }
}
