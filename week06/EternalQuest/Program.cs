using System;

namespace EternalQuest
{
    class Program
    {
        /*
        Exceeding Requirements
        1) Program shows level and a badge title from the player’s score.
        2) Feedback: the user receives messages when they record goal
        3) Save/Load: made the save and load simple
        */

        static void Main(string[] args)
        {
            Console.Title = "Eternal Quest";
            GoalManager manager = new GoalManager();
            manager.Start();
        }
    }
}
