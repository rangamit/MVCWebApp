using Microsoft.AspNetCore.Mvc;
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
        public OrganisationController(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            IndexViewModel organisationViewModel = new IndexViewModel();

            organisationViewModel.Organisations = _dbContext.Organisations.ToList();

            return View(organisationViewModel);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add([Bind] CreateViewModel createViewModel)
        {
            if (ModelState.IsValid)
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
        public IActionResult Update([Bind] UpdateViewModel updateViewModel)
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
            return RedirectToAction("Index");
        }

        public IActionResult Delete(Guid id)
        {
            var org =  _dbContext.Organisations.FirstOrDefault(o => o.Id == id);

            return View(new DeleteViewModel
            {
                Id = org.Id,
                Name = org.Name
            });
        }

        [HttpPost]
        public IActionResult Delete([Bind] DeleteViewModel deleteViewModel)
        {
            var org = _dbContext.Organisations.FirstOrDefault(o => o.Id == deleteViewModel.Id);
            if (org != null)
            {
                _dbContext.Organisations.Remove(org);
                _dbContext.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public IActionResult View(Guid id)
        {
            var viewId = _dbContext.Organisations.FirstOrDefault(o => o.Id == id);
            return View(new ViewModel
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
