using Microsoft.AspNetCore.Mvc;
using WebCrosswordLearning.Services;

namespace WebCrosswordLearning.Controllers
{
    public class CrosswordController : Controller
    {
        private IWordSourceService wordSourceService;

        public CrosswordController(IWordSourceService wordSourceService)
        {
            this.wordSourceService = wordSourceService;
        }
        public IActionResult Index(int? n, int? m)
        {
            var crossword = wordSourceService.GetCrossword(n, m);
            return View("Crossword", crossword);
        }
    }
}
