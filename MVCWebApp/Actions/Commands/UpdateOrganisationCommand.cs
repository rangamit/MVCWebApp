using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCWebApp.Actions.Commands
{
    public class UpdateOrganisationCommand : IRequest<Models.Organisation>
    {
        public UpdateOrganisationCommand(Guid id, string name , string city, string state, string country)
        {
            Id = id; 
            Name = name;
            City = city;
            State = state;
            Country = country;  
        }

        public Guid Id { get; set; }

        public string Name { get; set; }

        public string City { get; set; }

        public string  State { get; set; }

        public string Country { get; set; }
    }
}
