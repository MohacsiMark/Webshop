using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComputerShop.Models
{
    public class Computer
    {
        [Key]
        [MaxLength(36)]
        public Guid Id { get; set; }

        [Column(TypeName ="varchar(37)")]
        public string? Brand { get; set; }

        [Column(TypeName ="varchar(30)")]
        public string? Type { get; set; }

        [Column(TypeName ="double")]
        public float Display { get; set; }

        public int Memory { get; set; }
        public DateTime CreatedTime { get; set; }
        public Osystem Os { get; set; }

        public Guid OsId { get; set; }
    }
}
