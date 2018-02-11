﻿using LogicCrosswordLearning;
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
        public string Index([FromBody] Tag tag)
        {
            var zzz = tag.Req;
            return "Success";
        }
    }

    public class Tag
    {
        public string Req { get; set; }
    }
}
