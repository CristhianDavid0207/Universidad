using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using inscription.App.Interfases;
using inscription.Models;

namespace inscription.App.Services
{
    public class CareerService : ICareer
    {
        private readonly ICareer _carrerRepository;

        public CareerService(ICareer carrerRepository)
        {
            _carrerRepository = carrerRepository;
        }

        public async Task<IEnumerable<Career>> GetCarrer()
        {
            return await _carrerRepository.GetCarrer();
            throw new NotImplementedException();
        }

    }
}