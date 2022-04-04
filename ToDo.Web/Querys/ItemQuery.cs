using HotChocolate;
using HotChocolate.Data;
using MediatR;
using System.Linq;
using System.Threading.Tasks;
using ToDo.Application.Features.Item;
using ToDo.Core.Entitys;

namespace ToDo.Web.Querys
{
    public partial class Query
    {
        /// <summary>
        /// Запрос для получения задач
        /// </summary>
        /// <param name="mediator">Сервис медиатора</param>
        /// <returns>Набор задач с возможностью фильтрации</returns>
        [UseFiltering]
        [UseSorting]
        public async Task<IQueryable<ItemEntity>> GetItems([Service] IMediator mediator)
        {
            return await mediator.Send(new GetItemsQuery());
        }
    }
}
