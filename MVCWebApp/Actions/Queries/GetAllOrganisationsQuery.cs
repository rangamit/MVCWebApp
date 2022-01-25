using MediatR;
using MVCWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCWebApp.Actions.Queries
{
    public class GetAllOrganisationsQuery : IRequest<List<Organisation>>
    {
    }
}
