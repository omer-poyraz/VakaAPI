using Entities.Models;

namespace Repositories.EFCore.Extensions
{
    public static class SearchExtensions
    {
        public static IQueryable<User> SearchUser(this IQueryable<User> user, string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return user;

            var lowerCaseTerm = searchTerm.Trim().ToLower();
            return user.Where(u => u.UserName!.ToLower().Contains(lowerCaseTerm));
        }

        public static IQueryable<Product> SearchProduct(this IQueryable<Product> product, string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return product;

            var lowerCaseTerm = searchTerm.Trim().ToLower();
            return product.Where(p => p.ProductName!.ToLower().Contains(lowerCaseTerm));
        }

        public static IQueryable<Room> SearchRoom(this IQueryable<Room> room, string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return room;

            var lowerCaseTerm = searchTerm.Trim().ToLower();
            return room.Where(r => r.RoomName!.ToLower().Contains(lowerCaseTerm));
        }

        public static IQueryable<Store> SearchStore(this IQueryable<Store> store, string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return store;

            var lowerCaseTerm = searchTerm.Trim().ToLower();
            return store.Where(s => s.StoreName!.ToLower().Contains(lowerCaseTerm));
        }

        public static IQueryable<Structure> SearchStructure(this IQueryable<Structure> structure, string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return structure;

            var lowerCaseTerm = searchTerm.Trim().ToLower();
            return structure.Where(s => s.StructureName!.ToLower().Contains(lowerCaseTerm));
        }

        public static IQueryable<WorkOrder> SearchWorkOrder(this IQueryable<WorkOrder> workOrder, string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return workOrder;

            var lowerCaseTerm = searchTerm.Trim().ToLower();
            return workOrder.Where(w => w.WorkOrderName!.ToLower().Contains(lowerCaseTerm));
        }
    }
}
