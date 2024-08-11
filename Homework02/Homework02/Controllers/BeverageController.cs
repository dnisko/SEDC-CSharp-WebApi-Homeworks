using Homework02.Data;
using Homework02.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Homework02.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BeverageController : ControllerBase
    {
        private readonly StaticDb _db;

        public BeverageController(StaticDb db)
        {
            _db = db;
        }

        [HttpGet("GetAll")]
        public ActionResult GetAll()
        {
            return Ok(_db.Beverages);
        }

        [HttpGet("GetByIndex")]
        public ActionResult GetByIndex([FromQuery]int index)
        {
            if (index < 0 || index > _db.Beverages.Count)
            {
                return BadRequest(StatusCode(StatusCodes.Status400BadRequest,$"Enter positive number from 0 to {_db.Beverages.Count}"));
            }

            return Ok(_db.Beverages[index - 1]);
        }

        [HttpGet("GetByBrandAndType")]
        public ActionResult GetByBrandAndType([FromQuery] string brand,[FromQuery] string type)
        {
            var beverage = _db.Beverages.FirstOrDefault(x =>
                x.Brand.Equals(brand, StringComparison.OrdinalIgnoreCase) &&
                x.Type.Equals(type, StringComparison.OrdinalIgnoreCase));

            if (beverage == null)
            {
                return BadRequest(StatusCode(StatusCodes.Status400BadRequest, "enter brand and type."));
            }

            return Ok(beverage);
        }

        [HttpPost("AddFromBody")]
        public IActionResult AddBeverageFromBody([FromBody] Beverage beverage)
        {
            return Ok();
        }

        //Bonus
        [HttpPost("AddListFromBody")]
        public IActionResult AddListOfBeverageFromBody([FromBody] List<Beverage> beverages)
        {
            if (beverages == null || !beverages.Any())
            {
                return BadRequest("No data entered");
            }

            _db.Beverages.AddRange(beverages);
            return Ok(beverages);
        }
    }
}
