namespace WebApi.Web.Api.V1.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using MediatR;
    using WebApi.Core.Responses;
    using WebApi.Core.Commands;
    using System.Threading.Tasks;

    [ApiVersion("1.0")]
    [Route("api/v{api-version:apiVersion}/[controller]")]
    [ApiController]
    public class MediatrController
    {
        private readonly IMediator mediator;

        public MediatrController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        // GET api/values
        [HttpGet("{id:alpha}")]
        public async Task<string> Get(string id)
        {
            var result = await this.mediator.Send(new SimpleWithReturnCommand<SimpleWithReturnResponse>(id));
            return result.Result;
        }
    }
}