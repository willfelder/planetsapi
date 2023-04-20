using Microsoft.AspNetCore.Mvc;

namespace UniverseAPI.Service
{
    public interface IPlanetsService
    {
        Task<List<Planets>> GetAllPlanets();
        Task<Planets?> GetSinglePlanet(int id);
        Task<List<Planets>> InsertPlanet(Planets planet);
        Task<List<Planets>?> UpdatePlanet(int id, Planets request);
        Task<List<Planets>?> RemovePlanet(int id);
    }
}
