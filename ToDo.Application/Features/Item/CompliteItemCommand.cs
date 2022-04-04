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
    public class CompliteItemCommand : IRequest<ActionsItemPayload>
    {
        public string Id { get; }
        public CompliteItemCommand(string id)
        {
            Id = id;
        }
    }

    public class CompliteItemCommandHandler : IRequestHandler<CompliteItemCommand, ActionsItemPayload>
    {
        private readonly IRepository _repository;

        public CompliteItemCommandHandler(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<ActionsItemPayload> Handle(CompliteItemCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var item = (await _repository.FindAsync<ItemEntity>(s => s.Id == request.Id)).FirstOrDefault();

                if (item == null) throw new ApplicationException("Item not found");

                if (item.Complited) throw new ApplicationException("Item already Complited");

                item.Complited = true;
                await _repository.UpdateAsync(item.Id, item);
                return new ActionsItemPayload(true);
            }
            catch (Exception ex)
            {
                return new ActionsItemPayload(false, ex.Message);
            }
        }
    }
}
