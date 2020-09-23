using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Claims;
using System.Threading.Tasks;
using Core.Interface;
using Core.Model;
using Infrastructure.WebApplication.ApiModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Infrastructure.WebApplication.Controllers
{
    [Authorize]
    [Route("staff")]
    public class StaffController : Controller
    {
        private readonly ISqlService _sqlService;
        public StaffController(ISqlService sqlService)
        {
            _sqlService = sqlService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        [Route("authentication")]
        public async Task<ActionResult> Authentication(string bu, string bp)
        {   
            if (bu == "OTcsMTAwLDEwOSwxMDUsMTEw" && bp == "ODAsOTcsMTE1LDExNSwxMTksNDgsMTE0LDEwMA==")
            {
                List<Claim> claims = new List<Claim> { new Claim(ClaimTypes.NameIdentifier, "cpcAuthCoockie") };
                ClaimsIdentity identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                ClaimsPrincipal principal = new ClaimsPrincipal(identity);
                await HttpContext.SignInAsync(principal);

                return RedirectToAction("~/staff/index");
            }
            return View("login");
        }

        [Route("addMovie")]
        public ActionResult<string> AddMovie(ApiMovie apiMovie)
        {
            string returnString = "Add movie failed: ";

            if (string.IsNullOrEmpty(apiMovie.Name)) {
                return returnString + "Movie need a name";
            } else if (string.IsNullOrEmpty(apiMovie.Length) || !Int32.TryParse(apiMovie.Length, out int i)) {
                return returnString + "You need to right a number in movie length";
            } else if (string.IsNullOrEmpty(apiMovie.Desc)) {
                return returnString + "please just write something in the movie description";
            } else if (apiMovie.Genre == null) {
                return returnString + "No genre is seleceted";
            } else if (apiMovie.File == null) {
                return returnString + "No image file is select";
            }

            byte[] imgBytes = new byte[apiMovie.File.Length];
            using (var ms = new MemoryStream())
            {
                apiMovie.File.CopyTo(ms);
                imgBytes = ms.ToArray();
            }

            Movie movie = new Movie
            {
                Name = apiMovie.Name,
                Length = Convert.ToInt32(apiMovie.Length),
                Desc = apiMovie.Desc,
                Genre = (MovieGenre)Convert.ToInt32(apiMovie.Genre),
                ImageBytes = imgBytes
            };

            bool success = _sqlService.AddMovie(movie);
            returnString = success ? "Add movie success" : returnString;

            return returnString;
        }

        [Route("getMovies")]
        public ActionResult<List<ApiShowGetMovies>> GetMovies()
        {
            List<ApiShowGetMovies> movies = new List<ApiShowGetMovies>();
            var data = _sqlService.GetMoviesForAddShow();

            foreach (var item in data)
            {
                movies.Add(new ApiShowGetMovies
                { 
                    Id = item.Id,
                    Name = item.Name
                });
            }

            return movies;
        }

        [Route("getHalls")]
        public ActionResult<List<short>> GetHalls()
        {
            var data = _sqlService.GetHallsForAddShow();
            return data;
        }

        [Route("getShowsFH")]
        public ActionResult<string> GetShowsForHall(short hall, string date)
        {
            date = date.Substring(0, 10);
            var data = _sqlService.GetShowsForHall(hall, date);
            string showTime = "Sallen er optagede mellem: " + string.Join(",", data);
            if (showTime == "Sallen er optagede mellem: ")
            {
                showTime = "der er ingen film denne dag";
            }
            return showTime;
        }

        [Route("addShow")]
        public ActionResult<string> AddShow(ApiShow apiShow)
        {
            string returnString = "Add Show failed: ";

            Show show = new Show {
                MovieId = apiShow.Movie,
                HallId = apiShow.Hall,
                Data = apiShow.Date,
                StartTime = apiShow.Time,
                EndTime = apiShow.Time.AddHours(4)
            };

            bool? success = _sqlService.AddShow(show);
            if (success == null)
                return returnString + "Time mabye overlab O.o";
            else if (success == false)
                return returnString + "Failed to add seats to show, but shows is added...";
            else 
                return "Add movie success";
        }
    }
}