using Microsoft.AspNetCore.Http;

namespace Infrastructure.WebApplication.ApiModels
{
    public class ApiMovie
    {
        public string Name { get; set; }
        public string Length { get; set; }
        public string Desc { get; set; }
        public string Genre { get; set; }
        public IFormFile File { get; set; }
    }
}
