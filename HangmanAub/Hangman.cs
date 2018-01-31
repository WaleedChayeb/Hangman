using System;
using System.Collections.Generic;
using System.Linq; 

namespace HangmanAub
{
    public class Hangman
    {
        List<Word> words = new List<Word>();
        List<WordMatrix> guessedchar = new List<WordMatrix>();
        int Life = 7;
        Word current = new Word();

        public Hangman()
        {
            GetWords();
        }

        public Result StartGame()
        {
            Random rnd = new Random();
            int index = rnd.Next(words.Count);
            current = words[index];
            return GetResult();
        }

        public Result Answer(char character)
        {
            character = Char.ToLower(character);
            if (guessedchar.Where(a => a.character == character).SingleOrDefault() == null)
            {
                int CorrectAnswers = 0;

                for (int i = 0; i < current.Value.Length; i++)
                {
                    if (current.Value[i].Equals(character))
                    {
                        CorrectAnswers++;
                        WordMatrix wm = new WordMatrix();
                        wm.index = i;
                        wm.character = character;
                        guessedchar.Add(wm);
                    }
                }
                if (CorrectAnswers == 0)
                    Life--;

            }

            return GetResult();
        }

        public Result GetResult()
        {
            Result n = new Result();
            n.life = Life;
            n.guessedchar = guessedchar;
            n.length = current.Value.Length;
            return n;
        }

        public void GetWords()
        {
            //we can get it from API as well.
            words.Add(new Word { Value = "cat" });
            words.Add(new Word { Value = "beirut" });
            words.Add(new Word { Value = "taxi" });
            words.Add(new Word { Value = "awkward" });
        }
    }

    public class Word
    {
        public string Value { get; set; }
    }

    public class Result
    {
        public int life { get; set; }
        public List<WordMatrix> guessedchar { get; set; }
        public int length { get; set; }
    }

    public class WordMatrix
    {
        public int index { get; set; }
        public char character { get; set; }

    }
}