using System;
using System.Collections.Generic;

public class Scripture 
{
    private Reference _reference;
    private List<Word> _words = new List<Word>();
    private static Random random = new Random();

    public Scripture(Reference reference, string text)
    {
        string[] wordsInText = text.Split(' ');

        foreach (string word in wordsInText)
        {
            _words.Add(new Word(word));
        }

        _reference = reference;
    }

    public void HideRandomWords(int numberToHide)
    {

        int hiddenWords = 0;
        int visibleWords = 0;

        foreach (Word word in _words)
        {
            if (!word.IsHidden())
            {
                visibleWords++;
            }
        }

        if (numberToHide > visibleWords)
        {
            numberToHide = random.Next(1, visibleWords + 1);
        }

        if (visibleWords == 0)
        {
            return;
        }

        while (hiddenWords < numberToHide)
        {
            int randomIndex = random.Next(0, _words.Count);
            Word randomWord = _words[randomIndex];

            while (randomWord.IsHidden()) 
            {
                randomIndex = random.Next(0, _words.Count);
                randomWord = _words[randomIndex];
            }
            
            if (!randomWord.IsHidden())
            {
                randomWord.Hide();
                hiddenWords++;
            }
        }
    }

    public string GetStringText()
    {
        string result = "";
        foreach (Word word in _words)
        {
            result += word.GetDisplayText() + " ";
        }

        return result;
    }

    public bool isCompletelyHidden()
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
