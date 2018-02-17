using System;
using System.Collections.Generic;

namespace LogicCrosswordLearning.Services
{
    public class CrosswordService
    {
        public Crossword GetCrossword(int n, int m, IEnumerable<Word> words)
        {
            var crosswordCreator = new CrosswordCreator.CrosswordCreator(n, m, words);
            
            //foreach (var word in words)
            //{
            //    //var wordToInsert = ((bool)RTLRadioButton.IsChecked) ? word.Reverse().Aggregate("",(x,y) => x + y) : word;
            //    var addedWord = crosswordCreator.AddWord(word.ToString());
            //    switch (addedWord.Item3)
            //    {
            //        case 0:
            //            crosswordCreator.HorizontalWords.Add(new Tuple<int, int>(addedWord.Item1, addedWord.Item2), word);
            //            break;
            //        case 1:
            //            crosswordCreator.VerticalWords.Add(new Tuple<int, int>(addedWord.Item1, addedWord.Item2), word);
            //            break;
            //        default:                       
            //            break;

            //    }
            //}
            var crossword = crosswordCreator.GetCrossword();
            return crossword;
        }
    }
}
