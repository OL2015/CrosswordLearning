using System.Collections.Generic;
using LogicCrosswordLearning;

namespace DesctopCrosswordLearning.Services
{
    public interface IWordSourceService
    {
        IEnumerable<Word> GetWords(int quantityWords);
    }
}