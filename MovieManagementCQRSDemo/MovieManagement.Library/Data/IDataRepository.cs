using MovieManagement.Library.Models;

namespace MovieManagement.Library.Data
{
    public interface IDataRepository
    {
        //Query
        List<MovieModel> GetMovies();

        //Command
        MovieModel AddMovie(MovieModel movie);
    }
}
