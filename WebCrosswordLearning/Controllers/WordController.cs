using Microsoft.AspNetCore.Mvc;
using System.Linq;
using WebCrosswordLearning.Services;
using WebCrosswordLearning.ViewModels;

namespace WebCrosswordLearning.Controllers
{
    public class WordController : Controller
    {
        private IWordSourceService wordSource;

        public WordController(IWordSourceService wordSource)
        {
            this.wordSource = wordSource;

        }

        public IActionResult WordList(int? id)
        {            
            var words = wordSource.GetWords(2);
            var vm = new WordListViewModel();
            vm.Words = words;
            if (id != null)
            {
                vm.SelectedWord = words.FirstOrDefault(z => z.Id == id);
            }
            return View(vm);
        }
                
    }
}
