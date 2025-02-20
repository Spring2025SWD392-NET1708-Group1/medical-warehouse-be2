using AutoMapper;
using BLL.DTOs;
using BLL.Interfaces;
using DAL.Entities;
using DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class ItemCategoryService : IItemCategoryService
    {
        private readonly IItemCategoryRepository _itemCategoryRepository;
        private readonly IMapper _mapper;

        public ItemCategoryService(IItemCategoryRepository itemCategoryRepository, IMapper mapper)
        {
            _itemCategoryRepository = itemCategoryRepository;
            _mapper = mapper;
        }

        public async Task<ItemCategoryDTO> CreateCategoryAsync(ItemCategoryDTO itemcategoryDTO)
        {
            var category = _mapper.Map<ItemCategory>(itemcategoryDTO);
            category.Id = Guid.NewGuid();

            await _itemCategoryRepository.AddAsync(category);
            return _mapper.Map<ItemCategoryDTO>(category);
        }

        public async Task<bool> DeleteCategoryAsync(Guid id)
        {
            var category = await _itemCategoryRepository.GetByIdAsync(id);
            if (category == null) return false;
            await _itemCategoryRepository.DeleteAsync(id);
            return true;
        }

        public async Task<IEnumerable<ItemCategoryDTO>> GetAllCategoriesAsync()
        {
            var categories = await _itemCategoryRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<ItemCategoryDTO>>(categories);
        }

        public async Task<ItemCategoryDTO?> GetCategoryByIdAsync(Guid id)
        {
            var category = await _itemCategoryRepository.GetByIdAsync(id);
            return category != null ? _mapper.Map<ItemCategoryDTO>(category) : null;
        }

        public async Task<bool> UpdateCategoryAsync(Guid id, ItemCategoryDTO itemcategoryDTO)
        {
            var category = await _itemCategoryRepository.GetByIdAsync(id);
            if (category == null) return false;

            _mapper.Map(itemcategoryDTO, category);
            await _itemCategoryRepository.UpdateAsync(category);
            return true;
        }
    }
}
