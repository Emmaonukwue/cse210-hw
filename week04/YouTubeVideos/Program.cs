using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Create a list to store videos
        List<Video> videos = new List<Video>();

        // First video
        Video video1 = new Video("Learning C#", "CodeMaster", 300);
        video1.AddComment(new Comment("Alice", "Great explanation!"));
        video1.AddComment(new Comment("Bob", "Very helpful, thanks!"));
        video1.AddComment(new Comment("Charlie", "Nice video."));
        videos.Add(video1);

        // Second video
        Video video2 = new Video("Abstraction in OOP", "DevWorld", 420);
        video2.AddComment(new Comment("Daisy", "Loved the examples."));
        video2.AddComment(new Comment("Eli", "Now I understand abstraction better."));
        video2.AddComment(new Comment("Frank", "This helped me with my homework."));
        videos.Add(video2);

        // Third video
        Video video3 = new Video("Top 10 C# Tips", "TechSavvy", 250);
        video3.AddComment(new Comment("Grace", "Tip #3 blew my mind."));
        video3.AddComment(new Comment("Hank", "Short and sweet."));
        video3.AddComment(new Comment("Ivy", "Very useful for beginners."));
        videos.Add(video3);

        // Loop through each video and display its info
        foreach (Video video in videos)
        {
            video.DisplayInfo();
        }
    }
}
