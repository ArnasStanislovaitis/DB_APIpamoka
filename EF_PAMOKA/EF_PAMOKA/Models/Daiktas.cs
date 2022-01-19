using System.ComponentModel.DataAnnotations;

namespace EF_PAMOKA.Models
{
    public class Daiktas
    {
        [Key]
        public int Id { get; set; }
        public string Pavadinimas { get; set; }
        public int? SavininkoId { get; set; }
    }
}
