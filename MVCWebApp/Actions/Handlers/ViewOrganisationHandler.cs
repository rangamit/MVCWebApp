using MediatR;
using Microsoft.EntityFrameworkCore;
using MVCWebApp.Actions.Commands;
using MVCWebApp.Actions.Queries;
using MVCWebApp.Data;
using MVCWebApp.Models;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MVCWebApp.Actions.Handlers
{
    public class GetOrganisationHandler : IRequestHandler<GetOrganisationQuery, Models.Organisation>
    {
        private readonly ApplicationDBContext _dBContext;

        public GetOrganisationHandler(ApplicationDBContext dBContext)
        {
            _dBContext = dBContext;
        }

        public async Task<Organisation> Handle(GetOrganisationQuery request, CancellationToken cancellationToken)
        {
            var org =  await _dBContext.Organisations.FirstOrDefaultAsync(o => o.Id == request.Id);
            return org;
        }
    }
}
