using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicCrosswordLearning
{
    public class FileWordSource : IWordSource
    {
        private string filename;
        List<Word> words;

        public int Capacity { get; private set; }


        public FileWordSource(string filename)
        {
            this.filename = filename;
        }

        public IEnumerable<Word> GetWords(int cnt)
        {
            if (words == null)
            {
                words = new List<Word>();
                FillWords();
            }

            if (cnt > words.Count())
                throw new ApplicationException("Quantity of words is larger than source capacity");
            if (cnt <= 0)
                throw new ArgumentException("Number of requested words should be greater then 0");
            
            //TODO we are sorting the entire set of words and than take only cnt of them
            //than can be ineffitiant if Capacity is big
            Random rnd = new Random();
            var selectedWords = words.OrderBy(item => rnd.Next()).Take(cnt);
            
            return selectedWords;
            
        }

        private void FillWords()
        {
            try
            {
                words.Clear();
                using (var reader = new StreamReader(filename))
                {
                    string line;
                    int i = 1;
                    while ((line = reader.ReadLine()) != null)
                    {
                        var word = new Word() { Id= i, Value = line };
                        words.Add(word);
                        i++;
                    }                    
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
