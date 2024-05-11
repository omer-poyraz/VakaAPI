namespace Entities.Exceptions.Product
{
    public class ProductNotFoundException : NotFoundException
    {
        public ProductNotFoundException(int id) : base($"{id} number ID is not found!")
        {
        }
    }
}
