using LogicCrosswordLearning.WordsResource;
using System;
using System.Collections.Generic;
using System.Linq;
using LogicCrosswordLearning.CrosswordCreator;

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

        public IEnumerable<Word> GetLearningWords(int cnt)
        {
            var words = new List<Word>();
            using (var context = new LogicCrosswordLearning.WordsResource.WordsContext()) // WordsContext())
            {
                Random rnd = new Random();
                //words = context.Words.OrderBy(item => rnd.Next())
                //    .Where(z => z.Language_ID == 1)
                //    .Distinct()
                //    .Take(cnt)
                //    .Select(z => new Word() { Id = z.Word_ID, Value = z.Value })
                //    .ToList();


                if (cnt > words.Count())
                    throw new ApplicationException("Quantity of words is larger than source capacity");
                if (cnt <= 0)
                    throw new ArgumentException("Number of requested words should be greater then 0");

                ////TODO we are sorting the entire set of words and than take only cnt of them
                ////than can be ineffitiant if Capacity is big
                ////Random rnd = new Random();
                ////var selectedWords = listWord.OrderBy(item => rnd.Next()).Take(cnt);
            }
            return words;
        }
    }
}
