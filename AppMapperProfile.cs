using AutoMapper;
using CustomersWebApi.DTOs;
using CustomersWebApi.Model;

namespace CustomersWebApi
{
    public class AppMapperProfile:Profile
    {
        public AppMapperProfile() 
        {
            CreateMap<CustomerDTO, Customer>();
            CreateMap<Customer, CustomerDTO>();
            CreateMap<CustomerAddressDTO, CustomerAddress>();
            CreateMap<CustomerAddress, CustomerAddressDTO>();

            CreateMap<ApplicantDTO, Applicant>();
            CreateMap<Applicant, ApplicantDTO>();
            CreateMap<ExperienceDTO, Experience>();
            CreateMap<Experience, ExperienceDTO>();

            CreateMap<SoftwareExperienceDTO, SoftwareExperience>();
            CreateMap<SoftwareExperience, SoftwareExperienceDTO>();

           
        }
    }
}
