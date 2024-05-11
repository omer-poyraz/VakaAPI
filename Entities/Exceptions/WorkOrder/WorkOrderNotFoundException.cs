namespace Entities.Exceptions.WorkOrder
{
    public class WorkOrderNotFoundException : NotFoundException
    {
        public WorkOrderNotFoundException(int id) : base($"{id} number ID not found!")
        {
        }
    }
}
