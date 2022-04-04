using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ToDo.Core.Entitys;
using ToDo.Core.Payloads;
using ToDo.Core.Repository;

namespace ToDo.Application.Features.Item
{
    public class CreateItemsCommand : IRequest<CreateItemsPayload>
    {
        public CreateItemCommand[] Commands { get; }
        public CreateItemsCommand(params CreateItemCommand[] commands)
        {
            Commands = commands;
        }
    }

    public class CreateItemsCommandHandler : IRequestHandler<CreateItemsCommand, CreateItemsPayload>
    {
        private readonly IRepository _repository;

        public CreateItemsCommandHandler(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<CreateItemsPayload> Handle(CreateItemsCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var items = request.Commands.Select(i => new ItemEntity(i.Title)).ToArray();
                await _repository.CreateManyAsync(items);
                return new CreateItemsPayload(items.Select(s => s.Id).ToArray());
            }
            catch (Exception ex)
            {
                return new CreateItemsPayload(null, ex.Message);
            }
        }
    }
}
