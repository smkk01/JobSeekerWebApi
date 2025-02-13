using CustomersWebApi.Data;
using CustomersWebApi.DTOs;
using CustomersWebApi.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using static CustomersWebApi.Controllers.ApplicantController;
using System;
using System.Collections.Generic;

namespace CustomersWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicantController : ControllerBase
    {

        private readonly AppDbContext _appDbContext;
        private readonly IMapper _mapper;

        public ApplicantController(AppDbContext appDbContext, IMapper mapper)
        {
            _appDbContext = appDbContext;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetApplicants()
        {
            var applicant = await _appDbContext.Applicant
                .Include(c => c.ExperienceDetail)
                .Include(s => s.SoftwareExperienceDetail)
                .ToListAsync();
            return Ok(applicant);
        }

        [HttpGet("GetApplicantById")]
        public async Task<IActionResult> Get(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            var applicant = await _appDbContext.Applicant
                .Include(c => c.ExperienceDetail)
                .Include (c => c.SoftwareExperienceDetail)
                .Where(c => c.Id == id).FirstOrDefaultAsync();

            if (applicant == null)
            {
                return NotFound();
            }
            var newCustomer = MapApplicantDTOObject(applicant);          

            
            return Ok(newCustomer);
            
        }
        private Applicant MapApplicantObject(ApplicantDTO applicant)
        {
            var result = new Applicant();
            result.Name = applicant.Name;
            result.Gender = applicant.Gender;
            result.Age = applicant.Age;
            result.Qualification = applicant.Qualification;
            result.PhotoUrl = applicant.PhotoUrl;
            result.ExperienceDetail = new List<Experience>();
            applicant.ExperienceDetail.ForEach(c =>
            {
                var newExperience = new Experience();
                newExperience.CompanyName = c.CompanyName;
                newExperience.Designation = c.Designation;
                newExperience.YearsWorked = c.YearsWorked;
                result.ExperienceDetail.Add(newExperience);
            });

            result.SoftwareExperienceDetail = new List<SoftwareExperience>();
            applicant.SoftwareExperience.ForEach(c =>
            {
                var newSExperience = new SoftwareExperience();
                newSExperience.SoftwareId = c.SoftwareId;
                newSExperience.ApplicantId = c.ApplicantId;
                newSExperience.Rating = c.Rating;
                newSExperience.IsHidden = c.IsHidden;
                newSExperience.Notes = c.Notes;
                result.SoftwareExperienceDetail.Add(newSExperience);
            });


            return result;
        }

        private ApplicantDTO MapApplicantDTOObject(Applicant applicant)
        {
            var result = new ApplicantDTO();
            result.Name = applicant.Name;
            result.Gender = applicant.Gender;
            result.Age = applicant.Age;
            result.Qualification = applicant.Qualification;
            result.PhotoUrl = applicant.PhotoUrl;
            result.ExperienceDetail = new List<ExperienceDTO>();
            applicant.ExperienceDetail.ForEach(c =>
            {
                var newExperience = new ExperienceDTO();
                newExperience.CompanyName = c.CompanyName;
                newExperience.Designation = c.Designation;
                newExperience.YearsWorked = c.YearsWorked;
                result.ExperienceDetail.Add(newExperience);
            });

            result.SoftwareExperience = new List<SoftwareExperienceDTO>();
            applicant.SoftwareExperienceDetail.ForEach(c =>
            {
                var newSExperience = new SoftwareExperienceDTO();
                newSExperience.SoftwareId = c.SoftwareId;
                newSExperience.ApplicantId = c.ApplicantId;
                newSExperience.Rating = c.Rating;
                newSExperience.IsHidden = c.IsHidden;
                newSExperience.Notes = c.Notes;
                result.SoftwareExperience.Add(newSExperience);
            });


            return result;
        }

        [HttpPost]
        public async Task<IActionResult> Post(ApplicantDTO applicant)
        {
            
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }           

            var newApplicant = _mapper.Map<Applicant>(applicant);
            var newsoft = _mapper.Map<List<SoftwareExperience>>(applicant.SoftwareExperience);
            newApplicant.SoftwareExperienceDetail.AddRange(newsoft);          
            _appDbContext.Applicant.Add(newApplicant);            

            await _appDbContext.SaveChangesAsync();                   
           
            return Created($"/applicant/{newApplicant.Id}", applicant);
        }
        

        [HttpPut("UpdateApplicant")]
        public async Task<IActionResult> Put(ApplicantDTO applicant)
        {           

            List<Experience> experiences = _appDbContext.ExperienceDetail.Where(a => a.ApplicantId == applicant.Id).ToList();
            _appDbContext.ExperienceDetail.RemoveRange(experiences);

            List<SoftwareExperience> softwareexperiences = _appDbContext.SoftwareExperiences.Where(a => a.ApplicantId == applicant.Id).ToList();
            _appDbContext.SoftwareExperiences.RemoveRange(softwareexperiences);

            await _appDbContext.SaveChangesAsync();
           
            var updateApplicant = _mapper.Map<Applicant>(applicant);           
            var newsoft = _mapper.Map<List<SoftwareExperience>>(applicant.SoftwareExperience);
            updateApplicant.SoftwareExperienceDetail.AddRange(newsoft);
            updateApplicant.ExperienceDetail.RemoveAll(n => n.YearsWorked == 0);
            updateApplicant.ExperienceDetail.RemoveAll(n => n.IsDeleted == true);

            updateApplicant.SoftwareExperienceDetail.RemoveAll(n => n.IsHidden == true);

            _appDbContext.Attach(updateApplicant);
            _appDbContext.Entry(updateApplicant).State = EntityState.Modified;
            await _appDbContext.ExperienceDetail.AddRangeAsync(updateApplicant.ExperienceDetail);
            await _appDbContext.SoftwareExperiences.AddRangeAsync(updateApplicant.SoftwareExperienceDetail);

            await _appDbContext.SaveChangesAsync();
            return Ok(updateApplicant);
        }

        [HttpPut("DeleteApplicantById")]
        public async Task<IActionResult> Delete(int id)
        {
            // var newCustomer = MapCustomerObject(customer);
            var applicantToDelete = await _appDbContext
                .Applicant.Include(c => c.ExperienceDetail)
                
                .Where(c => c.Id == id)
                .FirstOrDefaultAsync();
            if (applicantToDelete == null)
            {
                return NotFound();
            }

            _appDbContext.Applicant.Remove(applicantToDelete);
            await _appDbContext.SaveChangesAsync();
            return NoContent();
        }
                     

    }
}
