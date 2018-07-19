namespace WebApi.Core.Models
{
    using System.ComponentModel;

    public class Campaign
    {
        // [Range(0, int.MaxValue)]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Slug { get; set; }
    }
}
