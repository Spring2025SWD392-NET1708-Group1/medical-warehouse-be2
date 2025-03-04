using AutoMapper;
using BLL.DTOs;
using BLL.Interfaces;
using DAL.Entities;
using DAL.Repositories.Interfaces;

namespace BLL.Services
{
    public class StorageService : IStorageService
    {
        private readonly IStorageRepository _storageRepository;
        private readonly IMapper _mapper;
        public StorageService(IStorageRepository storageRepository, IMapper mapper)
        {
            _storageRepository = storageRepository;
            _mapper = mapper;
        }


        public async Task<StorageViewDTO> CreateStorageAsync(StorageCreateDTO storageDTO)
        {
            var storage = _mapper.Map<Storage>(storageDTO);
            await _storageRepository.AddAsync(storage);

            return _mapper.Map<StorageViewDTO>(storage);
        }

        public async Task<bool> DeleteStorageAsync(int id)
        {
            var storage = await _storageRepository.GetByIdAsync(id);
            if (storage == null) return false;

            await _storageRepository.DeleteAsync(id);
            return true;
        }

        public async Task<IEnumerable<StorageViewDTO>> GetAllStoragesAsync()
        {
            var storages = await _storageRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<StorageViewDTO>>(storages);
        }

        public async Task<StorageViewDTO?> GetStorageByIdAsync(int id)
        {
            var storage = await _storageRepository.GetByIdAsync(id);
            return storage != null ? _mapper.Map<StorageViewDTO>(storage) : null;
        }

        public async Task<IEnumerable<StorageViewDTO>> GetStoragesByCategoryIdAsync(int categoryId)
        {
            var storages = await _storageRepository.GetByCategoryIdAsync(categoryId);
            return _mapper.Map<IEnumerable<StorageViewDTO>>(storages);
        }

        public async Task<bool> UpdateStorageAsync(int id, StorageUpdateDTO storageDTO)
        {
            var storage = await _storageRepository.GetByIdAsync(id);
            if (storage == null) return false;

            _mapper.Map(storageDTO, storage);
            await _storageRepository.UpdateAsync(storage);
            return true;

        }
    }
}
