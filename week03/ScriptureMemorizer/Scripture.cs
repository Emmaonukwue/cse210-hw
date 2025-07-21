using System;
using System.Collections.Generic;

public class Scripture
{
    private Reference _reference;
    private List<Word> _words;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();
        string[] parts = text.Split(' ');

        foreach (string part in parts)
        {
            _words.Add(new Word(part));
        }
    }

    public void HideRandomWords()
    {
        Random random = new Random();
        int wordsToHide = 3; // How many to hide at a time

        List<int> visibleIndexes = new List<int>();
        for (int i = 0; i < _words.Count; i++)
        {
            if (!_words[i].IsHidden())
            {
                visibleIndexes.Add(i);
            }
        }

        for (int i = 0; i < wordsToHide && visibleIndexes.Count > 0; i++)
        {
            int randomIndex = random.Next(visibleIndexes.Count);
            int wordIndex = visibleIndexes[randomIndex];
            _words[wordIndex].Hide();
            visibleIndexes.RemoveAt(randomIndex);
        }
    }

    public string GetDisplayText()
    {
        string fullText = _reference.GetDisplayText() + " ";
        foreach (Word word in _words)
        {
            fullText += word.GetDisplayText() + " ";
        }
        return fullText.Trim();
    }

    public bool AllWordsHidden()
    {
        foreach (Word word in _words)
        {
            if (!word.IsHidden())
            {
                return false;
            }
        }
        return true;
    }
}
