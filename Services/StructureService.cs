using AutoMapper;
using Entities.DTOs.StructureDto;
using Entities.Exceptions.Structure;
using Entities.Models;
using Entities.RequestFeature;
using Repositories.Contracts;
using Services.Contracts;

namespace Services
{
    public class StructureService : IStructureService
    {
        private readonly IRepositoryManager _manager;
        private readonly ILoggerService _logger;
        private readonly IMapper _mapper;
        public StructureService(IRepositoryManager manager, ILoggerService logger, IMapper mapper)
        {
            _manager = manager;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<StructureDto> CreateStructureAsync(StructureDtoForInsertion structureDto)
        {
            var structure = _mapper.Map<Structure>(structureDto);
            _manager.StructureRepository.CreateStructure(structure);
            await _manager.SaveAsync();
            return _mapper.Map<StructureDto>(structure);
        }

        public async Task<StructureDto> DeleteStructureAsync(int id, bool trackChanges)
        {
            var structure = await CheckExists(id, trackChanges);
            _manager.StructureRepository.DeleteStructure(structure);
            await _manager.SaveAsync();
            return _mapper.Map<StructureDto>(structure);
        }

        public async Task<(IEnumerable<StructureDto> structureDtos, MetaData metaData)> GetAllStructuresAsync(StructureParameters parameters, bool trackChanges)
        {
            var structures = await _manager.StructureRepository.GetAllStructuresAsync(parameters, trackChanges);
            var structureDto = _mapper.Map<IEnumerable<StructureDto>>(structures);
            return (structureDto, structures.MetaData);
        }

        public async Task<StructureDto> GetStructureAsync(int id, bool trackChanges)
        {
            var structure = await CheckExists(id, trackChanges);
            return _mapper.Map<StructureDto>(structure);
        }

        public async Task<StructureDto> UpdateStructureAsync(int id, StructureDtoForUpdate structureDto, bool trackChanges)
        {
            var structure = await CheckExists(id, trackChanges);
            structure = _mapper.Map<Structure>(structureDto);
            _manager.StructureRepository.UpdateStructure(structure);
            await _manager.SaveAsync();
            return _mapper.Map<StructureDto>(structure);
        }

        private async Task<Structure> CheckExists(int id, bool trackChanges)
        {
            var entity = await _manager.StructureRepository.GetStructureAsync(id, trackChanges);
            if (entity is null)
            {
                _logger.LogError($"{id} number Id not found exception!");
                throw new StructureNotFoundException(id);
            }
            return entity;
        }
    }
}
