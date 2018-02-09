using LogicCrosswordLearning;
using Microsoft.AspNetCore.Mvc;
using WebCrosswordLearning.Services;
using WebCrosswordLearning.ViewModels;

namespace WebCrosswordLearning.Controllers
{
    
    public class CrosswordController : Controller
    {
        private IWordSourceService wordSourceService;

        public CrosswordController(IWordSourceService wordSourceService)
        {
            this.wordSourceService = wordSourceService;
        }

        [HttpGet]
        public IActionResult Index(int? n, int? m)
        {
            var crossword = wordSourceService.GetCrossword(n, m);
            return View("Crossword", crossword);
        }
        
        [HttpPost]        
        public void PostCrossword(string req)
        {
            var zzz = req;
        }
    }
}
