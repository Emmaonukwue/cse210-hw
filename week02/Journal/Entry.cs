using System;

public class Entry
{
    public string Date { get; set; }
    public string Prompt { get; set; }
    public string Response { get; set; }
    public string Mood { get; set; }

    // Default constructor for JSON
    public Entry() {}

    public Entry(string prompt, string response, string mood)
    {
        Date = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
        Prompt = prompt;
        Response = response;
        Mood = mood;
    }

    public string GetDisplay()
    {
        return $"Date: {Date}\nMood: {Mood}\nPrompt: {Prompt}\nResponse: {Response}\n";
    }
}
