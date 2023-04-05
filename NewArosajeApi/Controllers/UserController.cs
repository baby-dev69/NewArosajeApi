using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NewArosajeApi.DTO;
using NewArosajeApi.Entities;
using System.Net;

namespace NewArosajeApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ArosajeapiContext ArosajeContext;


        public UserController(ArosajeapiContext ArosajeContext)
        {
            this.ArosajeContext = ArosajeContext;
        }

        [HttpGet("GetUser/{id}")]
        public async Task<ActionResult<UserDTO>> Get(int id)
        {
            var annonce = await ArosajeContext.Userdata.Where(p => p.UserId == id)
                .Select(s => new UserDTO
                {
                    UserId = s.UserId,
                    FirstName = s.FirstName,
                    LastName = s.LastName,
                    Age = s.Age,
                    Email = s.Email,
                    Phone = s.Phone,
                    Status = s.Status,
                    UserAddress = s.UserAddress,
                    Username = s.Username,
                    Password = s.Password,
                    CityId = s.CityId,
                    TypeId = s.TypeId
                })
                .FirstOrDefaultAsync();

            if (annonce == null)
            {
                return NotFound();
            }

            return annonce;
        }


        [HttpPost("InsertUser")]
        public async Task<HttpStatusCode> InsertUser(UserDTO User)
        {
            var entity = new Userdatum()
            {
                UserId = User.UserId,
                FirstName = User.FirstName,
                LastName = User.LastName,
                Age = User.Age,
                Email = User.Email,
                Phone = User.Phone,
                Status = User.Status,
                UserAddress = User.UserAddress,
                Username = User.Username,
                Password = User.Password,
                CityId = User.CityId,
                TypeId = User.TypeId
            };

            ArosajeContext.Userdata.Add(entity);
            await ArosajeContext.SaveChangesAsync();

            return HttpStatusCode.Created;
        }


    }
}
