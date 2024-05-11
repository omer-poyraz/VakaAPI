namespace Entities.Exceptions.Store
{
    public class StoreBadRequestException : BadRequestException
    {
        public StoreBadRequestException(int id) : base($"{id} number Id bad request!")
        {
        }
    }
}
