using System;
using System.ComponentModel.DataAnnotations;

namespace WebAPI.ViewModels.Organisation
{
    public class DetailViewModel
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
    }
}
