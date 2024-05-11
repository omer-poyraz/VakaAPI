using System.Text.Json;

namespace Entities.LogModels
{
    public class LogDetails
    {
        public object? ModelName { get; set; }
        public object? Controller { get; set; }
        public object? Action { get; set; }
        public object? Id { get; set; }
        public object? CreateAt { get; set; }

        public LogDetails()
        {
            CreateAt = DateTime.Now;
        }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
