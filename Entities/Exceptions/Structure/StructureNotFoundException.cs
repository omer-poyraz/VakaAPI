namespace Entities.Exceptions.Structure
{
    public class StructureNotFoundException : NotFoundException
    {
        public StructureNotFoundException(int id) : base($"{id} number Id not found!")
        {
        }
    }
}
