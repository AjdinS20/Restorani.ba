using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Restorani.ba.Models
{
    public class Jelo
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [DisplayName("Naziv Jela")]
        public string Name { get; set; }
        [Required]
        [DisplayName("Cijena")]
        public decimal Price { get; set; }

        [DisplayName("Ime Restorana")]
        public int RestoranId { get; set; }
        [ForeignKey("RestoranId")]
        public virtual Restoran Restoran { get; set; }

    }
}
