using LogicCrosswordLearning;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using WebCrosswordLearning.ViewModels;

namespace WebCrosswordLearning.Services
{
    public class WordSourceService : IWordSourceService
    {
        private IConfiguration configuration;
        private int quantityWord;

        public WordSourceService(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public IEnumerable<Word> GetWords(int quantityWord)
        {
            var filepath = configuration.GetConnectionString("FileConnection");
            var wordSource = new FileWordSource(filepath);
            var v = wordSource.GetWords(quantityWord);           
            return v;
        }
    }
}
