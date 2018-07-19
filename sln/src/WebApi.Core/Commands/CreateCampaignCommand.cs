namespace WebApi.Core.Commands
{
    using MediatR;
    using WebApi.Core.Models;

    public class CreateCampaignCommand : IRequest<Campaign>
    {
        public CreateCampaignCommand(string name, string slug)
        {
            this.Name = name;
            this.Slug = slug;

        }

        public string Name { get; }

        public string Slug { get; }
    }
}