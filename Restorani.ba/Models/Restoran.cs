using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Restorani.ba.Models
{
    public class Restoran
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [DisplayName("Ime Restorana")]
        public string Name { get; set; }
        [Required]
        [DisplayName("Adresa")]
        public string Adress { get; set; }
        [Required]
        [DisplayName("Telefon")]
        public string Number { get; set; }
    }
}
