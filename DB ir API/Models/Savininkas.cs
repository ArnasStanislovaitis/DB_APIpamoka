using System.ComponentModel.DataAnnotations;

namespace DB_ir_API.Models
{
    public class Savininkas
    {
        [Key]
        public int Id { get; set; } 
        public string Vardas { get; set; }
    }
}
