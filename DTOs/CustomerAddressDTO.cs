using System.ComponentModel.DataAnnotations;

namespace CustomersWebApi.DTOs
{
    public class CustomerAddressDTO
    {
        public int Id { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Country { get; set; }
        public int CustomerId { get; set; }
    }
}
