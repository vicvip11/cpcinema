using Core.Model;
using System.Collections.Generic;

namespace Core.Interface
{
    public interface ISqlService
    {
        List<Movie> GetMovies(long movieId);
        bool AddMovie(Movie movie);
        List<Movie> GetMoviesForAddShow();
        List<short> GetHallsForAddShow();
        List<string> GetShowsForHall(short hallId, string date);
        bool? AddShow(Show show);
        List<Show> GetShows(long movieId);
    }
}
