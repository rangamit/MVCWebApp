using MediatR;
using MVCWebApp.Models;
using System;

namespace MVCWebApp.Actions.Queries
{
    public class GetOrganisationQuery : IRequest<Organisation>
    {
        public GetOrganisationQuery(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}
