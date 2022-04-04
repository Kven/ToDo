using System.Collections.Generic;
using ToDo.Core.Entitys;

namespace ToDo.Core.Payloads
{
    /// <summary>
    /// Результат добавления задачи
    /// </summary>
    /// <param name="Item">Созданная задача</param>
    /// <param name="Error">Текст ошибки при ее возникновении</param>
    public record CreateItemPayload(ItemEntity Item, string Error = null);
    /// <summary>
    /// Результат добавления массива задач
    /// </summary>
    /// <param name="Ids">Массив идентификаторов добавленных задач</param>
    /// <param name="Error">Текст ошибки при ее возникновении</param>
    public record CreateItemsPayload(IEnumerable<string> Ids, string Error = null);
    /// <summary>
    /// Результат манипуляции над задачей
    /// </summary>
    /// <param name="Success">Результат выполнение</param>
    /// <param name="Error">Текст ошибки при ее возникновении</param>
    public record ActionsItemPayload(bool Success, string Error = null);
}
