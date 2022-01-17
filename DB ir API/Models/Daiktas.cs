using System.ComponentModel.DataAnnotations;

namespace DB_ir_API.Models
{
    public class Daiktas
    {
        [Key]
        public int ID { get; set; }
        public string Pavadinimas {get;set;}
        public int? SavininkasId {get;set;}


    }

}
