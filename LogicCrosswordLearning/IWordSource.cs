using System.Collections.Generic;

namespace LogicCrosswordLearning
{
    public interface IWordSource
    {
        int Capacity { get; }
        /// <summary>
        /// Return collection from N randomly selected words
        /// </summary>
        /// <param name="cnt"></param>
        /// <returns></returns>
        IEnumerable<Word> GetWords(int cnt);
    }
}