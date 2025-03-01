using AutoMapper;
using BLL.DTOs;
using BLL.Interfaces;
using DAL.Entities;
using DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class StorageCategoryService : IStorageCategoryService
    {
        private readonly IStorageCategoryRepository _storageCategoryRepository;
        private readonly IMapper _mapper;
        public StorageCategoryService(IStorageCategoryRepository storageCategoryRepository, IMapper mapper)
        {
            _storageCategoryRepository = storageCategoryRepository;
            _mapper = mapper;
        }

        public async Task<StorageCategoryViewDTO> CreateStorageCategoryAsync(StorageCategoryCreateDTO createDTO)
        {
            var category = _mapper.Map<StorageCategory>(createDTO);
            await _storageCategoryRepository.AddAsync(category);

            return _mapper.Map<StorageCategoryViewDTO>(category);
        }

        public async Task<bool> DeleteStorageCategoryAsync(int id)
        {
            var category = _storageCategoryRepository.GetByIdAsync(id);
            if (category == null) return false;

            await _storageCategoryRepository.DeleteAsync(id);
            return true;
        }
        public async Task<IEnumerable<StorageCategoryViewDTO>> GetAllStorageCategoriesAsync()
        {
            var categories = await _storageCategoryRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<StorageCategoryViewDTO>>(categories);
        }

        public async Task<StorageCategoryViewDTO?> GetStorageCategoryByIdAsync(int id)
        {
            var category = await _storageCategoryRepository.GetByIdAsync(id);
            return category != null ? _mapper.Map<StorageCategoryViewDTO>(category) : null;
        }

        public async Task<bool> UpdateStorageCategoryAsync(int id, StorageCategoryUpdateDTO updateDTO)
        {
            var category = await _storageCategoryRepository.GetByIdAsync(id);
            if (category == null) return false;

            _mapper.Map(updateDTO, category);
            await _storageCategoryRepository.UpdateAsync(category);
            return true;
        }
    }
}
