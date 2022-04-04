using HotChocolate;
using MediatR;
using System.Threading.Tasks;
using ToDo.Application.Features.Item;
using ToDo.Core.Payloads;

namespace ToDo.Web.Mutations
{
    /// <summary>
    /// Класс мутаций для GraphQL
    /// </summary>
    public partial class Mutation
    {
        /// <summary>
        /// Создание новой записи
        /// </summary>
        /// <param name="cmd">Команда создания объекта</param>
        /// <param name="mediator">Сервис медиатора</param>
        /// <returns>Созданный объект и текст ошибки, если она возникла</returns>
        public async Task<CreateItemPayload> CreateItem(CreateItemCommand cmd, [Service] IMediator mediator)
        {
            return await mediator.Send(cmd);
        }

        /// <summary>
        /// Создание массива новых записей
        /// </summary>
        /// <param name="mediator">Сервис медиатора</param>
        /// <param name="cmds">Команда создания массива объектов</param>
        /// <returns>Массив идентификаторов созданныъ объектов и текст ошибки, если она возникла</returns>
        public async Task<CreateItemsPayload> CreateItems([Service] IMediator mediator, params CreateItemCommand[] cmds)
        {
            return await mediator.Send(new CreateItemsCommand(cmds));
        }

        /// <summary>
        /// Завершить задачу
        /// </summary>
        /// <param name="cmd">Команда для завершения задачи</param>
        /// <param name="mediator">Сервис медиатора</param>
        /// <returns>Результат выполнения и текст ошибки, если она возникла</returns>
        public async Task<ActionsItemPayload> CompliteItem(CompliteItemCommand cmd, [Service] IMediator mediator)
        {
            return await mediator.Send(cmd);
        }

        /// <summary>
        /// Обновить задачу
        /// </summary>
        /// <param name="cmd">Команда для обновления задачи</param>
        /// <param name="mediator">Сервис медиатора</param>
        /// <returns>Результат выполнения и текст ошибки, если она возникла</returns>
        public async Task<ActionsItemPayload> UpdateItem(UpdateItemCommand cmd, [Service] IMediator mediator)
        {
            return await mediator.Send(cmd);
        }

        /// <summary>
        /// Удалить задачу
        /// </summary>
        /// <param name="cmd">Команда для удаления задачи</param>
        /// <param name="mediator">Сервис медиатора</param>
        /// <returns>Результат выполнения и текст ошибки, если она возникла</returns>
        public async Task<ActionsItemPayload> DeleteItem(DeleteItemCommand cmd, [Service] IMediator mediator)
        {
            return await mediator.Send(cmd);
        }
    }
}
