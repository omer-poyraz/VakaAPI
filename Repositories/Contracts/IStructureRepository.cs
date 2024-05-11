using Entities.Models;
using Entities.RequestFeature;

namespace Repositories.Contracts
{
    public interface IStructureRepository : IRepositoryBase<Structure>
    {
        Task<PagedList<Structure>> GetAllStructuresAsync(StructureParameters parameters, bool trackChanges);
        Task<Structure> GetStructureAsync(int id, bool trackChanges);
        Structure CreateStructure(Structure structure);
        Structure UpdateStructure(Structure structure);
        Structure DeleteStructure(Structure structure);
    }
}
