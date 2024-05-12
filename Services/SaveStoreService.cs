using AutoMapper;
using Entities.DTOs.SaveStoreDto;
using Entities.Models;
using Repositories.Contracts;
using Services.Contracts;

namespace Services
{
    public class SaveStoreService : ISaveStoreService
    {
        private readonly IRepositoryManager _manager;
        private readonly ILoggerService _logger;
        private readonly IMapper _mapper;
        public SaveStoreService(IRepositoryManager manager, ILoggerService logger, IMapper mapper)
        {
            _manager = manager;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<SaveStoreDto> CreateSaveStoreAsync(SaveStoreDtoForInsertion saveStoreDtoForInsertion)
        {
            var save = _mapper.Map<SaveStore>(saveStoreDtoForInsertion);
            _manager.SaveStoreRepository.CreateSaveStore(save);
            await _manager.SaveAsync();
            return _mapper.Map<SaveStoreDto>(save);
        }

        public async Task<SaveStoreDto> DeleteSaveStoreAsync(int id, bool trackChanges)
        {
            var save = await _manager.SaveStoreRepository.GetSaveStoreAsync(id, trackChanges);
            _manager.SaveStoreRepository.DeleteSaveStore(save);
            await _manager.SaveAsync();
            return _mapper.Map<SaveStoreDto>(save);
        }

        public async Task<IEnumerable<SaveStoreDto>> GetAllSaveStoreAsync(bool trackChanges)
        {
            var save = await _manager.SaveStoreRepository.GetAllSaveStoreAsync(trackChanges);
            return _mapper.Map<IEnumerable<SaveStoreDto>>(save);
        }

        public async Task<SaveStoreDto> GetSaveStoreAsync(int id, bool trackChanges)
        {
            var save = await _manager.SaveStoreRepository.GetSaveStoreAsync(id, trackChanges);
            return _mapper.Map<SaveStoreDto>(save);
        }

        public async Task<SaveStoreDto> UpdateSaveStoreAsync(int id, SaveStoreDtoForUpdate updateStoreDtoForUpdate, bool trackChanges)
        {
            var save = await _manager.SaveStoreRepository.GetSaveStoreAsync(id, trackChanges);
            save = _mapper.Map<SaveStore>(updateStoreDtoForUpdate);
            _manager.SaveStoreRepository.UpdateSaveStore(save);
            await _manager.SaveAsync();
            return _mapper.Map<SaveStoreDto>(save);
        }
    }
}
