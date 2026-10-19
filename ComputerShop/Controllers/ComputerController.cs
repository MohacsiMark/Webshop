using ComputerShop.Models;
using ComputerShop.Models.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ComputerShop.Controllers
{
    [Route("computer")]
    [ApiController]
    public class ComputerController : ControllerBase
    {
        public ComputerShopDbContext _context = new();

        [HttpPost("AddComputer")]
        public object AddNewComputer([FromBody] AddNewComputerDto addNewComputerDto)
        {
            var computer = new Computer
            {
                Id=Guid.NewGuid(),
                Brand = addNewComputerDto.Brand,
                Type = addNewComputerDto.Type,
                Display = addNewComputerDto.Display,
                Memory = addNewComputerDto.Memory,
                CreatedTime = DateTime.Now,
                OsId = addNewComputerDto.OsId,
            };

            if (computer != null)
            {
                _context.Computers.Add(computer);
                _context.SaveChanges();

                return StatusCode(201, new { message = "Sikeres felvétel", result = computer });
            }

            return StatusCode(400, new { message = "Sikeres felvétel", result = computer });
        }

        [HttpGet("allComputers")]
        public object GetAllComputers()
        {
            var computers=_context.Computers.ToList();
            Exception e = new();
            if (computers.Count > 0)
            {
                return StatusCode(200, new { message = "Sikeres lekérdezés", result = computers });
            }
            else if (computers.Count < 1)
            {
                return StatusCode(200, new { message = "Üres tábla", result = computers });
            }
            else
            {
                return StatusCode(400, new { message = "Hiba a lekérdezésben", result = e.Message });
            }
        }

        [HttpPost("updateComputer")]
        public object UpdateComputer([FromQuery] Guid id, [FromBody] UpdateComputerDto updateComputerDto)
        {
            var computer = _context.Computers.FirstOrDefault(c => c.Id == id);

            if (computer != null)
            {
                computer.Brand = updateComputerDto.Brand;
                computer.Type = updateComputerDto.Type;
                computer.Display = updateComputerDto.Display;
                computer.Memory = updateComputerDto.Memory;
                computer.OsId = updateComputerDto.OsId;

                _context.Computers.Update(computer);
                _context.SaveChanges();
                return StatusCode(200, new { message = "Sikeres módosítás", result = computer });
            }

            return StatusCode(400, new { message = "Hiba a módosításban", result = computer });
        }

        [HttpDelete("deleteComputer")]

        public object DeleteComputer([FromQuery] Guid id)
        {
            var computer = _context.Computers.FirstOrDefault(c => c.Id == id);
            if (computer != null)
            {
                _context.Computers.Remove(computer);
                _context.SaveChanges();
                return StatusCode(200, new { message = "Sikeres törlés", result = computer });
            }
            return StatusCode(400, new { message = "Hiba a törlésben", result = computer });
        }

        [HttpGet("GetComputerId")]
        public object GetComputerId([FromQuery] Guid Id)
        {
            var computer=_context.Computers.FirstOrDefault(c=>c.Id == Id);
            if (computer != null)
            {
                return StatusCode(200, new { message = "Sikeres lekérdezés", result = computer });
            }
            return StatusCode(400, new { message = "Hiba a lekérdezésben", result = computer });
        }

        [HttpGet("allOsystemsWithComputers")]

        public object GetAllOsystemWithComputers()
        {
            var osystems = _context.Osystems.Include(o => o.Computers);

            return StatusCode(200, new { message = "Sikeres lekérdezés", result = osystems });
        }
    }
}