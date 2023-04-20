using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UniverseAPI.Models;
using UniverseAPI.Service;

namespace UniverseAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlanetsController : ControllerBase
    {
        private readonly IPlanetsService _planetsService;

        public PlanetsController(IPlanetsService planetsService)
        {
            _planetsService = planetsService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Planets>>> GetAllPlanets()
        {
            return await _planetsService.GetAllPlanets();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<Planets>>> GetSinglePlanet(int id)
        {
            var result = await _planetsService.GetSinglePlanet(id);
            if(result is null)
                return NotFound("Planet was not found.");

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<List<Planets>>> InsertPlanet(Planets planet)
        {
            var result = await _planetsService.InsertPlanet(planet);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<Planets>>> UpdatePlanet(int id, Planets request)
        {
            var result = await _planetsService.UpdatePlanet(id, request);
            if (result is null)
                return NotFound("Planet was not found.");

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Planets>>> RemovePlanet(int id)
        {
            var result = await _planetsService.RemovePlanet(id);
            if (result is null)
                return NotFound("Planet was not found.");

            return Ok(result);
        }
    }
}
