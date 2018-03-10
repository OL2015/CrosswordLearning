using LogicCrosswordLearning.WordsResource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicCrosswordLearning.Services
{
    public class LearningDictionaryWordSource : ILearningDictionaryWordSource
    {
        private WordsContext context;
        private List<Word> words;

        public LearningDictionaryWordSource()
        {
            this.context = new WordsContext();
        }

        //public LearningDictionaryWordSource(WordsContext context)
        //{
        //    this.context = new WordsContext();
        //}

        public IEnumerable<Word> RandomWords(int cnt)
        {

            if (words == null)
            {
                words = new List<Word>();
                Random rnd = new Random();
                words = context.Words.OrderBy(item => rnd.Next())
                    .Where(z => z.Language_ID == 1)
                    .Distinct()
                    .Take(cnt)
                    .Select(z => new Word() { Id = z.Word_ID, Value = z.Value })
                    .ToList();
            }

            if (cnt > words.Count())
                throw new ApplicationException("Quantity of words is larger than source capacity");
            if (cnt <= 0)
                throw new ArgumentException("Number of requested words should be greater then 0");

            ////TODO we are sorting the entire set of words and than take only cnt of them
            ////than can be ineffitiant if Capacity is big
            ////Random rnd = new Random();
            ////var selectedWords = listWord.OrderBy(item => rnd.Next()).Take(cnt);

            return words;

        }
    }
}
