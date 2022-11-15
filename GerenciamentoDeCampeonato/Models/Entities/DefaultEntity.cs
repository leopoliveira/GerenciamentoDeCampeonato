using System.ComponentModel.DataAnnotations;

namespace GerenciamentoDeCampeonato.Models.Entities
{
    public class DefaultEntity
    {
        [Key]
        [Required]
        public virtual int Id { get; set; }

    }
}
