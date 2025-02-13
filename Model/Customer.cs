using System.ComponentModel.DataAnnotations;

namespace CustomersWebApi.Model
{
    public class Customer
    {
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string? Phone { get; set; }
        public List<CustomerAddress> customerAddresses { get; set; }
    }
}
