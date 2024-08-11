using Homework01.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Homework01.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        [HttpGet("GetAll")]
        public ActionResult GetAll()
        {
            return Ok(StaticDb.Users);
        }

        [HttpGet("GetById/{id:int}")]
        public ActionResult Get(int id)
        {
            if (id < 0 || id > StaticDb.Users.Count)
            {
                return BadRequest($"Please enter positive number to {StaticDb.Users.Count}");
            }

            return Ok(StaticDb.Users[id - 1]);
        }
    }
}
