using MediatR;
using MovieManagement.Library.Models;

namespace MovieManagement.Library.Queries
{
    public record GetMovieListQuery() : IRequest<List<MovieModel>>;
}
