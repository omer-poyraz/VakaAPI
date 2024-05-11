namespace Entities.Exceptions.WorkOrder
{
    public class WorkOrderBadRequestException : BadRequestException
    {
        public WorkOrderBadRequestException(int id) : base($"{id} number ID bad request!")
        {
        }
    }
}
