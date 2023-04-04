using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NewArosajeApi.DTO;
using NewArosajeApi.Entities;
using System.Net;

namespace NewArosajeApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AnnonceController : ControllerBase
    {
        private readonly ArosajeapiContext ArosajeContext;

        public AnnonceController(ArosajeapiContext ArosajeContext)
        {
            this.ArosajeContext = ArosajeContext;
        }

        [HttpGet("GetAnnonces")]
        public async Task<ActionResult<List<PlanteDTO>>> Get()
        {
            var List = await ArosajeContext.Plants.Select(
                s => new PlanteDTO
                {
                    PlantId = s.PlantId,
                    Name = s.Name,
                    Species = s.Species,
                    PlantDescription = s.PlantDescription,
                    PlantAddress = s.PlantAddress,
                    UserId = s.UserId
                }
            ).ToListAsync();

            return List;

        }

        [HttpGet("GetAnnonce/{id}")]
        public async Task<ActionResult<PlanteDTO>> Get(int id)
        {
            var annonce = await ArosajeContext.Plants.Where(p => p.PlantId == id)
                .Select(s => new PlanteDTO
                { 
                    PlantId = s.PlantId,
                    Name = s.Name,
                    Species = s.Species,
                    PlantDescription = s.PlantDescription,
                    PlantAddress = s.PlantAddress,
                    UserId = s.UserId
                })
                .FirstOrDefaultAsync();

            if (annonce == null)
            {
                return NotFound();
            }

            return annonce;
        }

        [HttpPost("InsertAnnonce")]
        public async Task<HttpStatusCode> InsertAnnonce(PlanteDTO Plante)
        {
            var entity = new Plant()
            {
                PlantId = Plante.PlantId,
                Name = Plante.Name,
                Species = Plante.Species,
                PlantDescription = Plante.PlantDescription,
                PlantAddress = Plante.PlantAddress,
                UserId = Plante.UserId
            };

            ArosajeContext.Plants.Add(entity);
            await ArosajeContext.SaveChangesAsync();

            return HttpStatusCode.Created;
        }

        [HttpPut("UpdatePlant/{id}")]
        public async Task<ActionResult> UpdatePlant(int id, PlanteDTO planteDTO)
        {
            if (id != planteDTO.PlantId)
            {
                return BadRequest();
            }

            var plant = await ArosajeContext.Plants.FindAsync(id);

            if (plant == null)
            {
                return NotFound();
            }

            // Mettre à jour les valeurs des colonnes de la plante
            plant.Name = planteDTO.Name;
            plant.Species = planteDTO.Species;
            plant.PlantDescription = planteDTO.PlantDescription;
            plant.PlantAddress = planteDTO.PlantAddress;

            try
            {
                await ArosajeContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                
            }

            return NoContent();
        }

        [HttpDelete("DeletePlant/{id}")]
        public async Task<ActionResult> DeletePlant(int id)
        {
            var plant = await ArosajeContext.Plants.FindAsync(id);

            if (plant == null)
            {
                return NotFound();
            }

            ArosajeContext.Plants.Remove(plant);
            await ArosajeContext.SaveChangesAsync();

            return NoContent();
        }



    }
}
