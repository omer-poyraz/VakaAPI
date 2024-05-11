namespace Entities.Exceptions.Product
{
    public class ProductBadRequestException : BadRequestException
    {
        public ProductBadRequestException(int id) : base($"{id} number ID is bad request!")
        {
        }
    }
}
