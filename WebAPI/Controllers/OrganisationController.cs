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

 

        [HttpPost("UpdateOrganisation")]
        public IActionResult UpdateOrganisation([Bind] UpdateViewModel updateViewModel)
        {
            if (ModelState.IsValid)
            {
                var org = _dbContext.Organisations.FirstOrDefault(o => o.Id == updateViewModel.Id);
                if (org != null)
                {
                    org.City = updateViewModel.City;
                    org.Country = updateViewModel.Country;
                    org.Name = updateViewModel.Name;
                    org.State = updateViewModel.State;
                    _dbContext.SaveChanges();
                }

            }
            return Ok();
        }


        [HttpDelete("DeleteOrganisation/{Id}")]
        public IActionResult DeleteOrganisation(Guid id)
        {
            var org = _dbContext.Organisations.FirstOrDefault(o => o.Id == id);
            if (org != null)
            {
                _dbContext.Organisations.Remove(org);
                _dbContext.SaveChanges();
            }
            return Ok();
        }

        [HttpGet("DetailOrganisation/{Id}")]
        public IActionResult DetailOrganisation(Guid id)
        {
            var viewId = _dbContext.Organisations.FirstOrDefault(o => o.Id == id);
            return Ok(new DetailViewModel
            {
                Id = viewId.Id,
                City = viewId.City,
                Country = viewId.Country,
                Name = viewId.Name,
                State = viewId.State,
            });
        }

    }
}
