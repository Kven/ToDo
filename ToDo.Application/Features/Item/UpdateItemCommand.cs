using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using ToDo.Core.Entitys;
using ToDo.Core.Payloads;
using ToDo.Core.Repository;

namespace ToDo.Application.Features.Item
{
    public class UpdateItemCommand : IRequest<ActionsItemPayload>
    {
        public ItemEntity Item { get; }
        public UpdateItemCommand(ItemEntity item)
        {
            Item = item;
        }
    }

    public class UpdateItemCommandHandler : IRequestHandler<UpdateItemCommand, ActionsItemPayload>
    {
        private readonly IRepository _repository;

        public UpdateItemCommandHandler(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<ActionsItemPayload> Handle(UpdateItemCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await _repository.UpdateAsync(request.Item.Id, request.Item);
                return new ActionsItemPayload(true);
            }
            catch (Exception ex)
            {
                return new ActionsItemPayload(false, ex.Message);
            }
        }
    }
}
