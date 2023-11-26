using MediatR;
using MovieManagement.Library.Data;
using MovieManagement.Library.Models;
using MovieManagement.Library.Queries;

namespace MovieManagement.Library.Handlers
{
    //This will be used to handle the request

    public class GetMovieListHandler : IRequestHandler<GetMovieListQuery, List<MovieModel>>
    {
        private readonly IDataRepository _dataRepository;

        public GetMovieListHandler(IDataRepository dataRepository)
        {
            _dataRepository = dataRepository;
        }

        public Task<List<MovieModel>> Handle(GetMovieListQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_dataRepository.GetMovies());
        }
    }
}
