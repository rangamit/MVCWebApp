using MediatR;
using System;

namespace MVCWebApp.Actions.Commands
{
    public class DeleteOrganisationCommand : IRequest<Models.Organisation>
    {
        public DeleteOrganisationCommand(Guid id, string name)
        {
            Id = id;
            Name = name;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }

    }
}
