
using Core.Interface;
using Core.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Infrastructure.WebApplication.Controllers
{
    [Route("api/cpc")]
    public class CpcController : Controller
    {
        private readonly ISqlService _sqlService;
        public CpcController(ISqlService sqlService)
        {
            _sqlService = sqlService;
        }

        [Route("getMovies")]
        public ActionResult<List<Movie>> GetMovies(long movieId, long userId)
        {
            //var data = _sqlService.GetMovies(movieId);
            return null;
        }

        [Route("getShows")]
        public ActionResult<List<Show>> GetShows(long movieId)
        {
            var data = _sqlService.GetShows(movieId);
            return null;
        }
    }
}