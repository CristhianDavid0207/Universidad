using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DocumentFormat.OpenXml.InkML;
using inscription.App.Interfases;
using inscription.Models;
using inscription.Infraestructures.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace inscription.App.Implemets
{
    public class CareerRepository : ICareer
    {
        private readonly InscriptionsContext _context;

        public CareerRepository(InscriptionsContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Career>> GetCarrer()
        {
            return await _context.Careers.ToListAsync();
            throw new NotImplementedException();
        }


    }
}