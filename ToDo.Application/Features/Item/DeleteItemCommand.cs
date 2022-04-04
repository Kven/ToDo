using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using ToDo.Core.Entitys;
using ToDo.Core.Payloads;
using ToDo.Core.Repository;

namespace ToDo.Application.Features.Item
{
    public class DeleteItemCommand : IRequest<ActionsItemPayload>
    {
        public string Id { get; }
        public DeleteItemCommand(string id)
        {
            Id = id;
        }
    }

    public class DeleteItemCommandHandler : IRequestHandler<DeleteItemCommand, ActionsItemPayload>
    {
        private readonly IRepository _repository;

        public DeleteItemCommandHandler(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<ActionsItemPayload> Handle(DeleteItemCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await _repository.DeleteAsync<ItemEntity>(request.Id);
                return new ActionsItemPayload(true);
            }
            catch (Exception ex)
            {
                return new ActionsItemPayload(false, ex.Message);
            }
        }
    }
}
