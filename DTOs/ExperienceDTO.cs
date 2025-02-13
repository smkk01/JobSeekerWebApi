using CustomersWebApi.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CustomersWebApi.DTOs
{
    public class ExperienceDTO
    {
        public int ExperienceId { get; set; }             
        public string CompanyName { get; set; }
        public string Designation { get; set; }        
        public int YearsWorked { get; set; }
        public int ApplicantId { get; set; }
        [NotMapped]
        public bool IsDeleted { get; set; } = false;

    }
}
