using Entities.Models;
using Entities.RequestFeature;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
using Repositories.EFCore.Extensions;

namespace Repositories.EFCore
{
    public class StructureRepository : RepositoryBase<Structure>, IStructureRepository
    {
        public StructureRepository(RepositoryContext context) : base(context)
        {
        }

        public Structure CreateStructure(Structure structure)
        {
            Create(structure);
            return structure;
        }

        public Structure DeleteStructure(Structure structure)
        {
            Delete(structure);
            return structure;
        }

        public async Task<PagedList<Structure>> GetAllStructuresAsync(StructureParameters parameters, bool trackChanges)
        {
            var structures = await FindAll(trackChanges)
                .OrderBy(s => s.StructureId)
                .Include(s => s.WorkOrder)
                .Include(s => s.Rooms)
                .Include(s => s.Store)
                .SearchStructure(parameters.SearchTerm!)
                .ToListAsync();

            return PagedList<Structure>.ToPagedList(structures, parameters.PageNumber, parameters.PageSize);
        }

        public async Task<Structure> GetStructureAsync(int id, bool trackChanges) =>
            await FindByCondition(s => s.StructureId.Equals(id), trackChanges)
            .Include(s => s.WorkOrder)
            .Include(s => s.Rooms)
            .Include(s => s.Store)
            .SingleOrDefaultAsync();

        public Structure UpdateStructure(Structure structure)
        {
            Update(structure);
            return structure;
        }
    }
}
