using AutoMapper;
using BLL.DTOs;
using BLL.Interfaces;
using DAL.Entities;
using DAL.Repositories.Interfaces;

namespace BLL.Services
{
    public class ItemService : IItemService
    {
        private readonly IItemRepository _itemRepository;
        private readonly IMapper _mapper;

        public ItemService(IItemRepository itemRepository, IMapper mapper)
        {
            _itemRepository = itemRepository;
            _mapper = mapper;
        }

        public async Task<ItemViewDTO> CreateItemAsync(ItemCreateDTO itemDTO)
        {
            var item = _mapper.Map<Item>(itemDTO);
            item.Id = Guid.NewGuid();

            await _itemRepository.AddAsync(item);
            return _mapper.Map<ItemViewDTO>(item);
        }

        public async Task<bool> DeleteItemAsync(Guid id)
        {
            var item = await _itemRepository.GetByIdAsync(id);
            if (item == null) return false;
            await _itemRepository.DeleteAsync(id);
            return true;
        }

        public async Task<IEnumerable<ItemViewDTO>> GetAllItemsWithDetailsAsync()
        {
            var items = await _itemRepository.GetAllWithCategoryAndStorageAsync(); // Fetch related data
            return _mapper.Map<IEnumerable<ItemViewDTO>>(items);
        }

        public async Task<ItemViewDTO?> GetItemByIdWithDetailsAsync(Guid id)
        {
            var item = await _itemRepository.GetByIdWithCategoryAndStorageAsync(id); // Fetch related data
            return item != null ? _mapper.Map<ItemViewDTO>(item) : null;
        }

        public async Task<bool> UpdateItemAsync(Guid id, ItemUpdateDTO itemDTO)
        {
            var item = await _itemRepository.GetByIdAsync(id);
            if (item == null) return false;

            _mapper.Map(itemDTO, item);
            await _itemRepository.UpdateAsync(item);
            return true;
        }

        public async Task<IEnumerable<ItemViewDTO>> GetItemsExpiringByDateAsync(DateTime expiryDate)
        {
            var items = await _itemRepository.GetItemsExpiringByDateAsync(expiryDate);
            return _mapper.Map<IEnumerable<ItemViewDTO>>(items);
        }

        public async Task<IEnumerable<ItemViewDTO>> GetItemsByExpiryRangeAsync(DateTime startDate, DateTime endDate)
        {
            var items = await _itemRepository.GetItemsByExpiryRangeAsync(startDate, endDate);
            return items.Select(item => new ItemViewDTO
            {
                Id = item.Id,
                Name = item.Name,
                Description = item.Description,
                CategoryName = item.ItemCategory.Name,
                StorageName = item.Storage.Name,
                Quantity = item.Quantity,
                Price = item.Price,
                ExpiryDate = item.ExpiryDate
            });
        }
    }
}
