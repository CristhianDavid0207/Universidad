using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using inscription.App.Interfases;
using Microsoft.AspNetCore.Mvc;

namespace inscription.Controllers.Carrers
{
    public class PostCareerController : Controller
    {
        private readonly ICareer _careerService;

        public PostCareerController(ICareer careerService)
        {
            _careerService = careerService;
        }

        
    }
}