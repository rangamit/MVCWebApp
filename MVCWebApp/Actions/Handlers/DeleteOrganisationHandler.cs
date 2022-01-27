using MediatR;
using MVCWebApp.Actions.Commands;
using MVCWebApp.Data;
using MVCWebApp.Models;
using MVCWebApp.ViewModels.Organisation;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MVCWebApp.Actions.Handlers
{
    public class DeleteOrganisationHandler : IRequestHandler<DeleteOrganisationCommand, Models.Organisation>
    {
        private readonly ApplicationDBContext _dBContext;

        public DeleteOrganisationHandler(ApplicationDBContext dBContext)
        {
                _dBContext = dBContext;
        }
        public async Task<Organisation> Handle(DeleteOrganisationCommand request, CancellationToken cancellationToken)
        {

            var org = _dBContext.Organisations.FirstOrDefault(o => o.Id == request.Id);
            if (org != null)
            {
                _dBContext.Organisations.Remove(org);
                await _dBContext.SaveChangesAsync();
            }
            return org;
            //throw new System.NotImplementedException();
        }

    }
}
