using System.Numerics;
using UniverseAPI.Models;

namespace UniverseAPI.Service
{
    public class PlanetsService : IPlanetsService
    {
        private readonly DataContext _dataContext;

        public PlanetsService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<List<Planets>> GetAllPlanets()
        {
            var planet = await _dataContext.Planets.ToListAsync();
            return planet;
        }
        public async Task<Planets?> GetSinglePlanet(int id)
        {
            var planet = await _dataContext.Planets.FindAsync(id);
            if (planet is null)
                return null;

            return planet;
        }

        public async Task<List<Planets>> InsertPlanet(Planets planet)
        {
            _dataContext.Planets.Add(planet);
            await _dataContext.SaveChangesAsync();

            return await _dataContext.Planets.ToListAsync();
        }

        public async Task<List<Planets>?> RemovePlanet(int id)
        {
            var planet = await _dataContext.Planets.FindAsync(id);
            if (planet is null)
                return null;

            _dataContext.Remove(planet);
            await _dataContext.SaveChangesAsync();

            return await _dataContext.Planets.ToListAsync();
        }

        public async Task<List<Planets>?> UpdatePlanet(int id, Planets request)
        {
            var planet = await _dataContext.Planets.FindAsync(id);
            if (planet is null)
                return null;

            planet.Name = request.Name;
            planet.LightTimeToTheSun = request.LightTimeToTheSun;
            planet.LengthOfYear = request.LengthOfYear;
            planet.PlanetType = request.PlanetType;

            await _dataContext.SaveChangesAsync();

            return await _dataContext.Planets.ToListAsync();
        }
    }
}
