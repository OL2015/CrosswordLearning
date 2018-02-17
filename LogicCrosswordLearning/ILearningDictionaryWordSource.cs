using LogicCrosswordLearning;
using System.Collections.Generic;

namespace LogicCrosswordLearning.Services
{
    public interface ILearningDictionaryWordSource
    {
        IEnumerable<Word> RandomWords(int cnt);
    }
}