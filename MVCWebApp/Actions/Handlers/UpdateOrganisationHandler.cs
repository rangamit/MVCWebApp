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
    public class UpdateOrganisationHandler : IRequestHandler<UpdateOrganisationCommand, Models.Organisation>
    {
        private readonly ApplicationDBContext _dBContext;

        public UpdateOrganisationHandler(ApplicationDBContext dBContext)
        {
            _dBContext = dBContext;
        }
        public async Task<Models.Organisation> Handle(UpdateOrganisationCommand request, CancellationToken cancellationToken)
        {
            var org = _dBContext.Organisations.FirstOrDefault(o => o.Id == request.Id);

            if (org != null)
            {
                org.City = request.City;
                org.Country = request.Country;
                org.Name = request.Name;
                org.State = request.State;
                await _dBContext.SaveChangesAsync();
            }
            
            return org;
        }
    }
}
