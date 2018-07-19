namespace WebApi.Api.V1.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    using Newtonsoft.Json;
    using WebApi.Core.Commands;
    using WebApi.Core.Models;
    using WebApi.Core.Services;

    [ApiVersion("1.0")]
    [Route("api/v{api-version:apiVersion}/[controller]")]
    [ApiController]
    public class CampaignsController : ControllerBase
    {
        private readonly IMediator mediatorService;

        public CampaignsController(IMediator mediatorService)
        {
            this.mediatorService = mediatorService;
        }

        [HttpPost]
        public async Task<Campaign> Post([FromBody] Campaign campaign)
        {
            var newCampaign = await this.mediatorService.Send(new CreateCampaignCommand(campaign.Name, campaign.Slug));
            return newCampaign;
        }
    }
}
