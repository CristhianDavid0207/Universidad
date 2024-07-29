using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using inscription.App.Interfases;
using Microsoft.AspNetCore.Mvc;

namespace inscription.Controllers.Carrers
{
    public class GetCareerController : Controller
    {
        private readonly ICareer _careerService;

        public GetCareerController(ICareer careerService)
        {
            _careerService = careerService;
        }

        public async Task<IActionResult> Index()
        {
            var careens = await _careerService.GetCarrer();
            return View(careens);
        }
    }
}