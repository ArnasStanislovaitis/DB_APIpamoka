using System.ComponentModel.DataAnnotations;

namespace EF_PAMOKA.Models
{
    public class Savininkas
    {
        [Key]
        public int Id { get; set; }
        public string Vardas { get; set; }
    }
}
