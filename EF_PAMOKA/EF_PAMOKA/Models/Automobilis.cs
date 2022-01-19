using System.ComponentModel.DataAnnotations;

namespace EF_PAMOKA.Models
{
    public class Automobilis
    {
        [Key]
        public int Id { get; set; }
        public string Marke { get; set; }
        public string Modelis { get; set; }
        public int? SavininkoId { get; set; }
    }
}
