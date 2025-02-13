using CustomersWebApi.Model;
using System.ComponentModel.DataAnnotations;

namespace CustomersWebApi.DTOs
{
    public class CustomerDTO
    {
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string? Phone { get; set; }
        public List<CustomerAddressDTO> customerAddresses { get; set; }
    }
}
