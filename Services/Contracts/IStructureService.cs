using Entities.DTOs.StructureDto;
using Entities.RequestFeature;

namespace Services.Contracts
{
    public interface IStructureService
    {
        Task<(IEnumerable<StructureDto> structureDtos, MetaData metaData)> GetAllStructuresAsync(StructureParameters parameters, bool trackChanges);
        Task<StructureDto> GetStructureAsync(int id, bool trackChanges);
        Task<StructureDto> CreateStructureAsync(StructureDtoForInsertion structureDto);
        Task<StructureDto> UpdateStructureAsync(int id, StructureDtoForUpdate structureDto, bool trackChanges);
        Task<StructureDto> DeleteStructureAsync(int id, bool trackChanges);
    }
}
