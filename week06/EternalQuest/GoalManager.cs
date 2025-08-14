using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace EternalQuest
{
    public class GoalManager
    {
        private readonly List<Goal> _goals = new List<Goal>();
        private int _score;

        public void Start()
        {
            bool done = false;
            while (!done)
            {
                Console.Clear();
                DisplayPlayerInfo();
                Console.WriteLine();
                Console.WriteLine("Menu:");
                Console.WriteLine("  1. Create New Goal");
                Console.WriteLine("  2. List Goals");
                Console.WriteLine("  3. Save Goals");
                Console.WriteLine("  4. Load Goals");
                Console.WriteLine("  5. Record Event");
                Console.WriteLine("  6. Reset (clear all goals)");
                Console.WriteLine("  0. Quit");
                Console.Write("Select an option: ");
                string choice = Console.ReadLine()?.Trim() ?? string.Empty;

                Console.WriteLine();
                switch (choice)
                {
                    case "1": CreateGoal(); break;
                    case "2": ListGoalDetails(); Pause(); break;
                    case "3": SaveGoals(); break;
                    case "4": LoadGoals(); break;
                    case "5": RecordEvent(); break;
                    case "6": _goals.Clear(); _score = 0; Console.WriteLine("Cleared all goals and score."); Pause(); break;
                    case "0": done = true; break;
                    default: Console.WriteLine("Invalid selection."); Pause(); break;
                }
            }
        }

        public void DisplayPlayerInfo()
        {
            Console.WriteLine($"Score: {_score}   Level: {ComputeLevel(_score)}   Badges: {BadgesForScore(_score)}");
        }

        public void ListGoalNames()
        {
            if (_goals.Count == 0)
            {
                Console.WriteLine("(no goals yet)");
                return;
            }

            for (int i = 0; i < _goals.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
            }
        }

        public void ListGoalDetails()
        {
            Console.WriteLine("Your Goals:");
            ListGoalNames();
        }

        public void CreateGoal()
        {
            Console.WriteLine("Choose the type of goal:");
            Console.WriteLine("  1. Simple Goal");
            Console.WriteLine("  2. Eternal Goal");
            Console.WriteLine("  3. Checklist Goal");
            Console.Write("Type: ");
            string choice = Console.ReadLine()?.Trim() ?? string.Empty;

            Console.Write("Name: ");
            string name = Console.ReadLine() ?? string.Empty;

            Console.Write("Description: ");
            string description = Console.ReadLine() ?? string.Empty;

            int points = PromptInt("Points for this goal: ");

            switch (choice)
            {
                case "1":
                    _goals.Add(new SimpleGoal(name, description, points));
                    break;

                case "2":
                    _goals.Add(new EternalGoal(name, description, points));
                    break;

                case "3":
                    int target = PromptInt("Times to complete: ");
                    int bonus = PromptInt("Bonus on final completion: ");
                    _goals.Add(new ChecklistGoal(name, description, points, target, bonus));
                    break;

                default:
                    Console.WriteLine("Unknown type. No goal created.");
                    Pause();
                    return;
            }

            Console.WriteLine("Goal created successfully.");
            Pause();
        }

        public void RecordEvent()
        {
            if (_goals.Count == 0)
            {
                Console.WriteLine("No goals to record yet.");
                Pause();
                return;
            }

            Console.WriteLine("Record which goal?");
            ListGoalNames();
            Console.Write("Enter number: ");
            if (!int.TryParse(Console.ReadLine(), out int index) || index < 1 || index > _goals.Count)
            {
                Console.WriteLine("Invalid selection.");
                Pause();
                return;
            }

            Goal goal = _goals[index - 1];
            int earned = goal.RecordEvent();
            _score += earned;

            Console.WriteLine($"Congrats! You earned {earned} points.");
            if (goal is ChecklistGoal && goal.IsComplete())
            {
                Console.WriteLine("🎉 Checklist completed! Bonus applied!");
            }

            // flavor for exceeding requirements
            int newLevel = ComputeLevel(_score);
            Console.WriteLine($"New Score: {_score} (Level {newLevel}) {LevelUpFlavor(_score)}");

            Pause();
        }

        public void SaveGoals()
        {
            Console.Write("Enter filename to save (e.g., goals.txt): ");
            string filename = Console.ReadLine()?.Trim() ?? "goals.txt";

            using (StreamWriter output = new StreamWriter(filename))
            {
                // First line stores score
                output.WriteLine($"Score|{_score}");

                // Following lines: one per goal
                foreach (Goal goal in _goals)
                {
                    output.WriteLine(goal.GetStringRepresentation());
                }
            }

            Console.WriteLine($"Saved {_goals.Count} goals to \"{filename}\".");
            Pause();
        }

        public void LoadGoals()
        {
            Console.Write("Enter filename to load (e.g., goals.txt): ");
            string filename = Console.ReadLine()?.Trim() ?? "goals.txt";

            if (!File.Exists(filename))
            {
                Console.WriteLine("File not found.");
                Pause();
                return;
            }

            string[] lines = File.ReadAllLines(filename);
            _goals.Clear();
            _score = 0;

            foreach (string raw in lines)
            {
                string line = raw.Trim();
                if (line.Length == 0) continue;

                string[] parts = line.Split('|');

                if (parts.Length >= 2 && parts[0] == "Score")
                {
                    if (int.TryParse(parts[1], out int s)) _score = s;
                    continue;
                }

                // style reconstruction based on type
                string type = parts[0];
                switch (type)
                {
                    case "SimpleGoal":
                        // SimpleGoal|name|description|points|isComplete
                        string sName = parts[1];
                        string sDesc = parts[2];
                        int sPoints = int.Parse(parts[3], CultureInfo.InvariantCulture);
                        bool sDone = bool.Parse(parts[4]);
                        _goals.Add(new SimpleGoal(sName, sDesc, sPoints, sDone));
                        break;

                    case "EternalGoal":
                        // EternalGoal|name|description|points
                        string eName = parts[1];
                        string eDesc = parts[2];
                        int ePoints = int.Parse(parts[3], CultureInfo.InvariantCulture);
                        _goals.Add(new EternalGoal(eName, eDesc, ePoints));
                        break;

                    case "ChecklistGoal":
                        // ChecklistGoal|name|description|points|target|bonus|amountCompleted
                        string cName = parts[1];
                        string cDesc = parts[2];
                        int cPoints = int.Parse(parts[3], CultureInfo.InvariantCulture);
                        int cTarget = int.Parse(parts[4], CultureInfo.InvariantCulture);
                        int cBonus = int.Parse(parts[5], CultureInfo.InvariantCulture);
                        int cDone = int.Parse(parts[6], CultureInfo.InvariantCulture);
                        _goals.Add(new ChecklistGoal(cName, cDesc, cPoints, cTarget, cBonus, cDone));
                        break;

                    default:
                        // ignore to keep loading robust when unknown
                        break;
                }
            }

            Console.WriteLine($"Loaded {_goals.Count} goals. Current score: {_score}.");
            Pause();
        }

        // ===== Helpers =====

        private static int PromptInt(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine() ?? string.Empty;
                if (int.TryParse(input, out int value) && value >= 0)
                {
                    return value;
                }
                Console.WriteLine("Please enter a non-negative integer.");
            }
        }

        private static void Pause()
        {
            Console.WriteLine("Press ENTER to continue...");
            Console.ReadLine();
        }

        // compute level & badges based on score
        private static int ComputeLevel(int score)
        {
            // Level every 500 points (1-based)
            return Math.Max(1, (score / 500) + 1);
        }

        private static string BadgesForScore(int score)
        {
            // badge names for milestones
            if (score >= 5000) return "Master";
            if (score >= 2500) return "Legend";
            if (score >= 1000) return "Hero";
            if (score >= 500) return "Apprentice";
            return "Rookie";
        }

        private static string LevelUpFlavor(int score)
        {
            // messages to keep it fun
            if (score == 0) return string.Empty;
            if (score % 1000 == 0) return "— Milestone reached!";
            if (score % 500 == 0) return "— Level up!";
            return string.Empty;
        }
    }
}
