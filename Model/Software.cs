using CustomersWebApi.DTOs;
using System.ComponentModel.DataAnnotations;

namespace CustomersWebApi.Model
{
    public class Software
    {
        [Key]
        public int id { get; set; }
        [Required]
        [StringLength(150)]
        public string Name { get; set; }
        
    }
}
