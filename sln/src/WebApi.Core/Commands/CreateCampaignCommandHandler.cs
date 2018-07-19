using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using WebApi.Core.Models;

namespace WebApi.Core.Commands
{
    public class CreateCampaignCommandHandler : IRequestHandler<CreateCampaignCommand, Campaign>
    {
        public Task<Campaign> Handle(CreateCampaignCommand request, CancellationToken cancellationToken)
        {
            return Task.FromResult(new Campaign { Id = new Random().Next(), Name = request.Name, Slug = request.Name });
        }
    }
}