namespace Entities.Exceptions.Store
{
    public class StoreNotFoundException : NotFoundException
    {
        public StoreNotFoundException(int id) : base($"{id} number ID not found!")
        {
        }
    }
}
