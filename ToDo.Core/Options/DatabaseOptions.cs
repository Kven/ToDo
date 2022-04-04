namespace ToDo.Core.Options
{
    /// <summary>
    /// Опции для добавления базы данных
    /// </summary>
    public class DatabaseOptions
    {
        public string ConnectionString { get; set; } = null!;
        public string DataBaseName { get; set; } = null!;
    }
}
