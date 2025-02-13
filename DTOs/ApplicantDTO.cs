using CustomersWebApi.Model;

namespace CustomersWebApi.DTOs
{
    public class ApplicantDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Gender { get; set; }       
        public int Age { get; set; }
        public string Qualification { get; set; }
        public int TotalExperience { get; set; }
        public string PhotoUrl { get; set; }
        public virtual List<ExperienceDTO> ExperienceDetail { get; set; } 
        public virtual List<SoftwareExperienceDTO> SoftwareExperience { get; set; }
    }
}
