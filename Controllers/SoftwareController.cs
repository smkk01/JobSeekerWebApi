using AutoMapper;
using CustomersWebApi.Data;

using CustomersWebApi.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CustomersWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SoftwareController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;
        public SoftwareController(AppDbContext appDbContext, IMapper mapper)
        {
            _appDbContext = appDbContext;
           
        }
        
        [HttpGet]
        public async Task<IActionResult> GetSoftware()
        {
            var software = await _appDbContext.Softwares               
                .ToListAsync();
            return Ok(software);
        }
    }
}
