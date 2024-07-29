using inscription.Models;
using Microsoft.AspNetCore.Mvc;

namespace inscription.App.Interfases
{
    public interface ICareer
    {
        Task<IEnumerable<Career>> GetCarrer();


    }
}