using Microsoft.AspNetCore.Mvc;
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
        public static List<Organisation> staticOrganizations = new List<Organisation>();
        public IActionResult Index()
        {
            IndexViewModel organisationViewModel = new IndexViewModel();

            organisationViewModel.Organisations = staticOrganizations;

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
                staticOrganizations.Add(new Organisation
                {
                    Id = Guid.NewGuid(),
                    City = createViewModel.City,
                    Country = createViewModel.Country,
                    Name = createViewModel.Name,
                    State = createViewModel.State,
                });
            }
            return RedirectToAction("Index");
        }

        public IActionResult Update(Guid id)
        {
            var org = staticOrganizations.FirstOrDefault(o => o.Id == id);

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
                var org = staticOrganizations.FirstOrDefault(o => o.Id == updateViewModel.Id);
                if (org != null)
                {
                    org.City = updateViewModel.City;
                    org.Country = updateViewModel.Country;
                    org.Name = updateViewModel.Name;
                    org.State = updateViewModel.State;
                }

            }
            return RedirectToAction("Index");
        }

        public IActionResult Delete(Guid id)
        {
            var org = staticOrganizations.FirstOrDefault(o => o.Id == id);

            return View(new DeleteViewModel
            {
                Id = org.Id,
                Name = org.Name
            });
        }

        [HttpPost]
        public IActionResult Delete([Bind] DeleteViewModel deleteViewModel)
        {
            var org = staticOrganizations.FirstOrDefault(o => o.Id == deleteViewModel.Id);
            if (org != null)
            {
                staticOrganizations.Remove(org);
            }
            return RedirectToAction("Index");
        }
    }
}
