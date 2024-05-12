using Entities.DTOs.SaveStoreDto;

namespace Services.Contracts
{
    public interface ISaveStoreService
    {
        Task<IEnumerable<SaveStoreDto>> GetAllSaveStoreAsync(bool trackChanges);
        Task<SaveStoreDto> GetSaveStoreAsync(int id, bool trackChanges);
        Task<SaveStoreDto> CreateSaveStoreAsync(SaveStoreDtoForInsertion saveStoreDtoForInsertion);
        Task<SaveStoreDto> UpdateSaveStoreAsync(int id, SaveStoreDtoForUpdate updateStoreDtoForUpdate, bool trackChanges);
        Task<SaveStoreDto> DeleteSaveStoreAsync(int id, bool trackChanges);
    }
}
