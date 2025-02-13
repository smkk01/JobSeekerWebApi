using CustomersWebApi.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CustomersWebApi.DTOs
{
    public class SoftwareExperienceDTO
    {        
            public int Id { get; set; }           
            public int ApplicantId { get; set; }
            public int SoftwareId { get; set; }
            public int Rating { get; set; }           
            public string Notes { get; set; }
            public bool IsHidden { get; set; } = false;

    }
}
