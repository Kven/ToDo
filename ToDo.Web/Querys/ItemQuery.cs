using HotChocolate;
using HotChocolate.Data;

using MediatR;

using System.Linq;
using System.Threading.Tasks;

using ToDo.Core.Entitys;

namespace ToDo.Web.Querys
{
    public partial class Query
    {
        [UseFiltering]
        [UseSorting]
        public async Task<IQueryable<ItemEntity>> GetItems([Service] IMediator mediator)
        {
            return await mediator.Send(new GetItemsQuery());
        }
    }
}
