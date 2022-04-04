using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using ToDo.Core.Entitys;
using ToDo.Core.Payloads;
using ToDo.Core.Repository;

namespace ToDo.Application.Features.Item
{
    /// <summary>
    /// Команда для создания задачи
    /// </summary>
    public class CreateItemCommand : IRequest<CreateItemPayload>
    {
        /// <summary>
        /// Заголовок
        /// </summary>
        public string Title { get; }
        public CreateItemCommand(string title)
        {
            Title = title;
        }
    }

    public class CreateItemCommandHandler : IRequestHandler<CreateItemCommand, CreateItemPayload>
    {
        private readonly IRepository _repository;

        public CreateItemCommandHandler(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<CreateItemPayload> Handle(CreateItemCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var item = new ItemEntity
                {
                    Title = request.Title,
                };
                await _repository.CreateAsync(item);
                return new CreateItemPayload(item);
            }
            catch (Exception ex)
            {
                return new CreateItemPayload(null, ex.Message);
            }
        }
    }
}
