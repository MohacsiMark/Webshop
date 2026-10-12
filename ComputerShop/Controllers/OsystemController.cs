using ComputerShop.Models;
using ComputerShop.Models.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ComputerShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OsystemController : ControllerBase
    {
        public ComputerShopDbContext _context = new();

        [HttpPost("AddOsystem")]
        public object AddNewOsystem([FromBody]AddNewOsystemDto addNewOsystemDto)
        {
            var osystem = new Osystem
            {
                Id = Guid.NewGuid(),
                Name=addNewOsystemDto.Name,
                Version = addNewOsystemDto.Version,
                RegisterTime = DateTime.Now,
                UpdateTime = DateTime.Now
            };

            if(osystem != null)
            {
                _context.Osystems.Add(osystem);
                _context.SaveChanges();

                return StatusCode(201, new { message = "Sikeres felvétel", result = osystem });
            }

            return StatusCode(400, new { message = "Sikeres felvétel", result = osystem });
        }

        [HttpGet("allOsystems")]
        public object GetAllOsystem()
        {
            var osystems = _context.Osystems.ToList();
            Exception e= new();
            if (osystems.Count > 0)
            {
                return StatusCode(200, new { message = "Sikeres lekérdezés", result = osystems });
            }
            else if(osystems.Count<1)
            {
                return StatusCode(200, new { message = "Üres tábla",result=osystems });
            }
            else
            {
                return StatusCode(400, new { message = "Hiba a lekérdezésben",result=e.Message });
            }
        }

        [HttpPost("updateOsystem")]
        public object UpdateOsystem([FromQuery]Guid id, [FromBody] UpdateOsystemDTO updateOsystemDto)
        {
            var osystem = _context.Osystems.FirstOrDefault(os => os.Id == id);

            if (osystem != null)
            {
                osystem.Name = updateOsystemDto.Name;
                osystem.Version = updateOsystemDto.Version;
                osystem.UpdateTime = DateTime.Now;

                _context.Osystems.Update(osystem);
                _context.SaveChanges();
                return StatusCode(200, new { message = "Sikeres módosítás", result = osystem });
            }

            return StatusCode(400, new { message = "Hiba a módosításban", result = osystem });
        }

        [HttpDelete("deleteOsystem")]

        public object DeleteOsystem([FromQuery] Guid id)
        {
            var osystem = _context.Osystems.FirstOrDefault(os => os.Id == id);
            if (osystem != null)
            {
                _context.Osystems.Remove(osystem);
                _context.SaveChanges();
                return StatusCode(200, new { message = "Sikeres törlés", result = osystem });
            }
            return StatusCode(400, new { message = "Hiba a törlésben", result = osystem });
        }


    }
}
