using LogicCrosswordLearning;
using System.Collections.Generic;

namespace WebCrosswordLearning.ViewModels
{
    public class WordListViewModel
    {
        public IEnumerable<Word> Words { get; set; }
        public Word SelectedWord { get; set; }
    }
}
