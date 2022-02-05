using MediatR;
using Microsoft.AspNetCore.Mvc;
using MVCWebApp.Actions.Commands;
using MVCWebApp.Actions.Queries;
using MVCWebApp.Data;
using MVCWebApp.Models;
using MVCWebApp.ViewModels.Organisation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCWebApp.Controllers
{
    public class OrganisationController : Controller
    {
        private readonly ApplicationDBContext _dbContext;
        private readonly IMediator _mediator;
        public OrganisationController(ApplicationDBContext dbContext, IMediator mediator)
        {
            _dbContext = dbContext;
            _mediator = mediator;
        }

        public async Task<IActionResult> Index()
        {
            IndexViewModel organisationViewModel = new IndexViewModel();

            organisationViewModel.Organisations = await _mediator.Send(new GetAllOrganisationsQuery());

            return View(organisationViewModel);
        }
       
        public IActionResult GetFromAPI()
        {
            return View();
        }
        
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add([Bind] CreateViewModel createViewModel)
        {
            if (ModelState.IsValid)
            {
                await _mediator.Send(new CreateOrganisationCommand(createViewModel.Name, createViewModel.City, createViewModel.State, createViewModel.Country));
            }
            return RedirectToAction("Index");
        }

        public IActionResult Update(Guid id)
        {
            var org = _dbContext.Organisations.FirstOrDefault(o => o.Id == id);

            return View(new UpdateViewModel
            {
                Id = org.Id,
                City = org.City,
                Country = org.Country,
                Name = org.Name,
                State = org.State,
            });
        }

        [HttpPost]
        public async Task<IActionResult> Update([Bind] UpdateViewModel updateViewModel)
        {
            if (ModelState.IsValid)
            {
                await _mediator.Send(new UpdateOrganisationCommand(updateViewModel.Id, updateViewModel.Name, updateViewModel.City, updateViewModel.State, updateViewModel.Country));
            }
            return RedirectToAction("Index");
        }

        public IActionResult Delete(Guid id)
        {
            var org = _dbContext.Organisations.FirstOrDefault(o => o.Id == id);

            return View(new DeleteViewModel
            {
                Id = org.Id,
                Name = org.Name
            });
        }

        [HttpPost]
        public async Task<IActionResult> Delete([Bind] DeleteViewModel deleteViewModel)
        {

            if (ModelState.IsValid)
            {
                await _mediator.Send(new DeleteOrganisationCommand(deleteViewModel.Id, deleteViewModel.Name));
            }
            return RedirectToAction("Index");

        }

        public async Task<IActionResult> View(Guid id)
        {
            var org = await _mediator.Send(new GetOrganisationQuery(id));

            return View(new ViewModel { City = org.City, Id = org.Id, Name = org.Name, Country = org.Country, State = org.State });
        }
    }
}
