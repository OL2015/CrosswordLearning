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
        private IWordSourceService wordSourceService;
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
            this.wordSourceService = wordSourceService;

        }

        public void RefreshWords()
        {
            var words = wordSourceService.GetWords(QuantityWords);
            SelectedWords = new ObservableCollection<Word>(words);
        }
    }
}