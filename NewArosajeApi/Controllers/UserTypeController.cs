using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NewArosajeApi.DTO;
using NewArosajeApi.Entities;
using System.Net;

namespace NewArosajeApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserTypeController : ControllerBase
    {
        private readonly ArosajeapiContext ArosajeContext;


        public UserTypeController(ArosajeapiContext ArosajeContext)
        {
            this.ArosajeContext = ArosajeContext;
        }

        [HttpGet("GetTypeUser/{id}")]
        public async Task<ActionResult<UserTypeDTO>> Get(int id)
        {
            var annonce = await ArosajeContext.Usertypes.Where(p => p.TypeId == id)
                .Select(s => new UserTypeDTO
                {
                    TypeId = s.TypeId,
                    Label = s.Label
                })
                .FirstOrDefaultAsync();

            if (annonce == null)
            {
                return NotFound();
            }

            return annonce;
        }


    }
}
