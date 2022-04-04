using HotChocolate;
using MediatR;
using System.Threading.Tasks;
using ToDo.Application.Features.Item;
using ToDo.Core.Payloads;

namespace ToDo.Web.Mutations
{
    public partial class Mutation
    {
        public async Task<CreateItemPayload> CreateItem(CreateItemCommand cmd, [Service] IMediator mediator)
        {
            return await mediator.Send(cmd);
        }

        public async Task<CreateItemsPayload> CreateItems([Service] IMediator mediator, params CreateItemCommand[] cmds)
        {
            return await mediator.Send(new CreateItemsCommand(cmds));
        }

        public async Task<ActionsItemPayload> CompliteItem(CompliteItemCommand cmd, [Service] IMediator mediator)
        {
            return await mediator.Send(cmd);
        }

        public async Task<ActionsItemPayload> UpdateItem(UpdateItemCommand cmd, [Service] IMediator mediator)
        {
            return await mediator.Send(cmd);
        }

        public async Task<ActionsItemPayload> DeleteItem(DeleteItemCommand cmd, [Service] IMediator mediator)
        {
            return await mediator.Send(cmd);
        }
    }
}
