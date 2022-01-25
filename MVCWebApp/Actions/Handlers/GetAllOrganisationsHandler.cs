using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MVCWebApp.Actions.Queries;
using MVCWebApp.Data;
using MVCWebApp.Models;

namespace MVCWebApp.Actions.Handlers
{
    public class GetAllOrganisationsHandler : IRequestHandler<GetAllOrganisationsQuery, List<Organisation>>
    {
        private readonly ApplicationDBContext _dbContext;
        public GetAllOrganisationsHandler(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task<List<Organisation>> Handle(GetAllOrganisationsQuery request, CancellationToken cancellationToken)
        {
            var organisations = await _dbContext.Organisations.ToListAsync();
            return organisations;
        }
    }
}
