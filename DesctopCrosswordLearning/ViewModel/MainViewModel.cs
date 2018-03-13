using DesctopCrosswordLearning.Services;
using GalaSoft.MvvmLight;
using LogicCrosswordLearning;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace DesctopCrosswordLearning.ViewModel
{

    public class MainViewModel : ViewModelBase
    {
        private IWordSourceService WordSourceService { get;}
        private ObservableCollection<Word> selectedWords = new ObservableCollection<Word>();

        public ObservableCollection<Word> SelectedWords
        {
            get { return selectedWords; }
            set
            {
                Set(() => SelectedWords, ref selectedWords, value);
            }

        }

        public int QuantityWords { get; set; }

        public MainViewModel(IWordSourceService wordSourceService)
        {
            WordSourceService = wordSourceService;
            QuantityWords = 2;
            RefreshWords();
        }

        public void RefreshWords()
        {
            var words = WordSourceService.GetWords(QuantityWords);
            SelectedWords = new ObservableCollection<Word>(words);
        }
    }
}