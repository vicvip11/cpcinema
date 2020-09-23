using Core.Interface;
using Core.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Net.NetworkInformation;
using System.Text;

namespace Core.Service
{
    public class SqlService : ISqlService
    {
        private readonly ISqlRepository _sqlRepository;
        public SqlService(ISqlRepository sqlRepository)
        {
            _sqlRepository = sqlRepository;
        }

        public bool AddMovie(Movie movie)
        {
            string spqs = "AddMovie";
            var data = _sqlRepository.CallStoredProcedure($"{spqs} '{movie.Name}', '{movie.Length}', '{movie.Desc}', '{(int)movie.Genre}', 0x{BitConverter.ToString(movie.ImageBytes).Replace("-", "")}");

            if (1 == Convert.ToInt32(data[0][0])) {
                return true;
            }
            return false;
        }

        public List<Movie> GetMovies(long movieId)
        {
            string spqs = "GetMovies";
            var data = _sqlRepository.CallStoredProcedure($"{spqs} '{movieId}'");

            if (data.Count == 0 )
                return null;

            List<Movie> movies = new List<Movie>();
            foreach (var row in data)
            {
                movies.Add(new Movie
                {
                    Id = Convert.ToInt64(row[0]),
                    Name = Convert.ToString(row[1]),
                    Length = Convert.ToInt32(row[2]),
                    Desc = Convert.ToString(row[3]),
                    Genre = (MovieGenre)Convert.ToInt32(row[4]),
                    ImageString = Convert.ToBase64String((byte[])row[5])
                });
            }

            return movies;
        }

        public List<Movie> GetMoviesForAddShow()
        {
            string spqs = "GetMoviesFS";
            var data = _sqlRepository.CallStoredProcedure($"{spqs}");

            List<Movie> movies = new List<Movie>();
            foreach (var row in data)
            {
                movies.Add(new Movie
                {
                    Id = Convert.ToInt64(row[0]),
                    Name = Convert.ToString(row[1])
                });
            }

            return movies;
        }

        public List<short> GetHallsForAddShow()
        {
            string spqs = "GetHallsFS";
            var data = _sqlRepository.CallStoredProcedure($"{spqs}");

            List<short> halls = new List<short>();
            foreach (var row in data)
            {
                halls.Add(Convert.ToInt16(row[0]));
            }

            return halls;
        }

        public List<string> GetShowsForHall(short hallId, string date)
        {
            string spqs = "GetShowsFH";
            var data = _sqlRepository.CallStoredProcedure($"{spqs} '{hallId}', '{date}'");

            List<string> hallInUse = new List<string>();
            foreach (var row in data)
            {
                hallInUse.Add(row[0].ToString().Substring(0, 5) + " - " + row[1].ToString().Substring(0, 5));
            }

            return hallInUse;
        }

        public bool? AddShow(Show show)
        {
            string spqs = "AddShow";
            var data = _sqlRepository.CallStoredProcedure($"{spqs} '{show.HallId}', '{show.MovieId}', '{show.Data.ToString("yyyy-MM-dd")}', '{show.StartTime.ToShortTimeString()}', '{show.EndTime.ToShortTimeString()}'");
            if (1 == Convert.ToInt32(data[0][0])) {
                spqs = "AddSeatsForShow";
                data = _sqlRepository.CallStoredProcedure($"{spqs} ''");
                if (1 == Convert.ToInt32(data[0][0]))
                {
                    return true;
                }
                return false;
            }
            return null;
        }

        public List<Show> GetShows(long movieId)
        {
            string spqs = "GetShows"; 
            var data = _sqlRepository.CallStoredProcedure($"{spqs} {movieId}");
            return null;
        }
    }
}

