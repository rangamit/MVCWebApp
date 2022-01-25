using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCWebApp.Actions.Commands
{
    public class CreateOrganisationCommand : IRequest<Guid>
    {
        public CreateOrganisationCommand(string name, string city, string state, string country)
        {
            Name = name;
            City = city;
            State = state;
            Country = country;
        }

        public string Name { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
    }
}
