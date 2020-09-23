using System;

namespace Infrastructure.WebApplication.ApiModels
{
    public class ApiShow
    {
        public long Movie { get; set; }
        public short Hall { get; set; }

        public DateTime Date { get; set; }
        public DateTime Time { get; set; }
    }
}
