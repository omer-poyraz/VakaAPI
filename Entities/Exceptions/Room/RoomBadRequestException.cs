namespace Entities.Exceptions.Room
{
    public class RoomBadRequestException : BadRequestException
    {
        public RoomBadRequestException(int id) : base($"{id} number ID bad request!")
        {
        }
    }
}
