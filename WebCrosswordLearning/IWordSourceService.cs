using System.Collections.Generic;
using LogicCrosswordLearning;
using WebCrosswordLearning.ViewModels;

namespace WebCrosswordLearning.Services
{
    public interface IWordSourceService
    {    
        IEnumerable<Word> GetWords(int cnt);
        Crossword GetCrossword(int? n, int? m);
    }
}