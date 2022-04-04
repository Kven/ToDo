using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ToDo.Core.Entitys;
using ToDo.Core.Repository;

namespace ToDo.Application.Features.Item
{
    public class GetItemsQuery : IRequest<IQueryable<ItemEntity>> { }

    public class GetItemsQueryHandler : IRequestHandler<GetItemsQuery, IQueryable<ItemEntity>>
    {
        private readonly IRepository _repository;

        public GetItemsQueryHandler(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<IQueryable<ItemEntity>> Handle(GetItemsQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetAsync<ItemEntity>();
        }
    }

}
