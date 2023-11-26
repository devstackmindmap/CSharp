using MediatR;
using MovieManagement.Library.Models;

namespace MovieManagement.Library.Queries
{
    public record GetMovieByIdQuery(int id) : IRequest<MovieModel>;
}
