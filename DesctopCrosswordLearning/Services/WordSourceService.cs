using DesctopCrosswordLearning.Properties;
using LogicCrosswordLearning;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesctopCrosswordLearning.Services
{
    public class WordSourceService : IWordSourceService
    {
        private IWordSource wordsource;
        
        private string pathToFile = Settings.Default["wordFilePath"].ToString();
        public WordSourceService()
        {
            wordsource = new FileWordSource(pathToFile);
        }

        public IEnumerable<Word> GetWords(int quantityWords)
        {

            var words = wordsource.GetWords(quantityWords);
            return words;
        }
    }
}
