namespace Entities.Exceptions.Room
{
    public class RoomNotFoundException : NotFoundException
    {
        public RoomNotFoundException(int id) : base($"{id} number ID not found!")
        {
        }
    }
}
