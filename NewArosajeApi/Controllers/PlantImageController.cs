using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NewArosajeApi.DTO;
using NewArosajeApi.Entities;
using System.Net;

namespace NewArosajeApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlantImageController : ControllerBase
    {
        private readonly ArosajeapiContext ArosajeContext;

        public PlantImageController(ArosajeapiContext ArosajeContext)
        {
            this.ArosajeContext = ArosajeContext;
        }

        [HttpGet("GetAnnonces")]
        public async Task<ActionResult<List<PlanteImageDTO>>> Get()
        {
            var List = await ArosajeContext.Plantimages.Select(
                s => new PlanteImageDTO
                {
                    ImageId = s.ImageId,
                    Image = s.Image,
                    ImageDate = s.ImageDate,
                    PlantId = s.PlantId
                }
            ).ToListAsync();

            return List;

        }

        [HttpGet("GetAnnonce/{id}")]
        public async Task<ActionResult<PlanteImageDTO>> Get(int id)
        {
            var annonce = await ArosajeContext.Plantimages.Where(p => p.ImageId == id)
                .Select(s => new PlanteImageDTO
                {
                    ImageId = s.ImageId,
                    Image = s.Image,
                    ImageDate = s.ImageDate,
                    PlantId = s.PlantId
                })
                .FirstOrDefaultAsync();

            if (annonce == null)
            {
                return NotFound();
            }

            return annonce;
        }

        [HttpPost("InsertAnnonce")]
        public async Task<HttpStatusCode> InsertAnnonce(PlanteImageDTO Plante)
        {
            var entity = new Plantimage()
            {
                ImageId = Plante.ImageId,
                Image = Plante.Image,
                ImageDate = Plante.ImageDate,
                PlantId = Plante.PlantId
            };

            ArosajeContext.Plantimages.Add(entity);
            await ArosajeContext.SaveChangesAsync();

            return HttpStatusCode.Created;
        }

        [HttpPut("UpdatePlant/{id}")]
        public async Task<ActionResult> UpdatePlant(int id, PlanteImageDTO planteDTO)
        {
           

            var plant = await ArosajeContext.Plantimages.FindAsync(id);

            

            // Mettre à jour les valeurs des colonnes de la plante
            plant.Image = planteDTO.Image;
            plant.ImageDate = planteDTO.ImageDate;

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
            var plant = await ArosajeContext.Plantimages.FindAsync(id);

            if (plant == null)
            {
                return NotFound();
            }

            ArosajeContext.Plantimages.Remove(plant);
            await ArosajeContext.SaveChangesAsync();

            return NoContent();
        }



    }
}
