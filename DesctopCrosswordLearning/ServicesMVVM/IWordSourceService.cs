using System.Collections.Generic;
using LogicCrosswordLearningData;

namespace DesctopCrosswordLearning.Services
{
    public interface IWordSourceService
    {
        IEnumerable<Word> GetWords(int quantityWords);
    }
}