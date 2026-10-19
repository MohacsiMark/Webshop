using System.ComponentModel.DataAnnotations.Schema;

namespace ComputerShop.Models.DTOs
{
    public class AddNewComputerDto
    {
        public string? Brand { get; set; }

        public string? Type { get; set; }

        public float Display { get; set; }

        public int Memory { get; set; }
        public Guid OsId { get; set; }
    }
}
