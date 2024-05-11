namespace Entities.Exceptions.Structure
{
    public class StructureBadRequestException : BadRequestException
    {
        public StructureBadRequestException(int id) : base($"{id} number ID bad request!")
        {
        }
    }
}
