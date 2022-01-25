using MediatR;
using MVCWebApp.Actions.Commands;
using MVCWebApp.Data;
using MVCWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MVCWebApp.Actions.Handlers
{
    public class CreateOrganisationHandler : IRequestHandler<CreateOrganisationCommand, Guid>
    {
        private readonly ApplicationDBContext _dbContext;
        public CreateOrganisationHandler(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }
        public async Task<Guid> Handle(CreateOrganisationCommand request, CancellationToken cancellationToken)
        {
            var org = new Organisation
            {
                City = request.City,
                Country = request.Country,
                Name = request.Name,
                State = request.State,
            };

            await _dbContext.Organisations.AddAsync(org, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return org.Id;
        }
    }
}
