using System.Collections.Generic;

using ToDo.Core.Entitys;

namespace ToDo.Core.Payloads
{
    public record CreateItemPayload(ItemEntity Item, string Error = null);
    public record CreateItemsPayload(IEnumerable<string> Ids, string Error = null);
    public record ActionsItemPayload(bool Success, string Error = null);
}
