using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Data;
using WebAPI.Models;
using WebAPI.ViewModels.Organisation;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrganisationController : ControllerBase
    {
        private readonly ApplicationDBContext _dbContext;

        public OrganisationController(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public IEnumerable<Organisation> Get()
        {
            var organsiations = _dbContext.Organisations.ToList();
            return organsiations;
        }

        [HttpPost("AddOrgnisation")]
        public IActionResult AddOrgnisation([Bind] CreateViewModel createViewModel)
        {
            var org = new Organisation
            {
                City = createViewModel.City,
                Country = createViewModel.Country,
                Name = createViewModel.Name,
                State = createViewModel.State,
            };
            _dbContext.Organisations.Add(org);
            _dbContext.SaveChanges();

            return Ok();
        }
    }
}
