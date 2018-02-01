using System;
using System.Collections.Generic;

namespace LogicCrosswordLearning.Services
{
    public class CrosswordService
    {
        public void GetCrossword(int n, int m, IEnumerable<Word> words)
        {
            var crosswordCreator = new CrosswordCreator.CrosswordCreator(n, m);
            var crossword = new Crossword();
            foreach (var word in words)
            {
                //var wordToInsert = ((bool)RTLRadioButton.IsChecked) ? word.Reverse().Aggregate("",(x,y) => x + y) : word;
                var addedWord = crosswordCreator.AddWord(word.Value.ToString());               
                switch (addedWord.Item3)
                {
                    case 0:
                        crossword.HorizontalWords.Add(new Tuple<int, int>(addedWord.Item1, addedWord.Item2), word);
                        break;
                    case 1:
                        crossword.VerticalWords.Add(new Tuple<int, int>(addedWord.Item1, addedWord.Item2), word);
                        break;
                    default:                       
                        break;

                }
            }
        }
    }
}
