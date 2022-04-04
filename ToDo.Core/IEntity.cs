namespace ToDo.Core
{
    /// <summary>
    /// Интерфейс базовой модели
    /// </summary>
    public interface IEntity
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        string Id { get; init; }
    }
}
