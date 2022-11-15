using GerenciamentoDeCampeonato.Models.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GerenciamentoDeCampeonato.Models.Entities
{
    public class Jogador : DefaultEntity
    {
        [Required]
        [MaxLength(100)]
        [Column(TypeName = "varchar(100)")]
        public string Name { get; set; }

        [Required]
        [Column(TypeName = "date")]
        public DateTime BirthDate { get; set; }

        [Required]
        [Column(TypeName = "decimal(12, 2)")]
        public double Salary { get; set; }

        [Required]
        [MaxLength(50)]
        [Column(TypeName = "varchar(50)")]
        public string Country { get; set; }

        [Required]
        public int TeamId { get; set; }

        [ForeignKey("TeamId")]
        public Time Team { get; set; }

        [Column(TypeName = "decimal(12, 2)")]
        public double? MarketValue { get; set; }

        [NotMapped]
        public int Age
        {
            get
            {
                return DateTime.Now.Year - BirthDate.Year;
            }
        }
    }
}
