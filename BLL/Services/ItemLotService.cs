using AutoMapper;
using BLL.DTOs;
using BLL.Interfaces;
using BLL.Utils;
using DAL.Entities;
using DAL.Repositories.Implementations;
using DAL.Repositories.Interfaces;

namespace BLL.Services
{
    public class ItemLotService : IItemLotService
    {
        private readonly IMapper _mapper;
        private readonly IItemLotRepository _itemLotRepository;
        private readonly JwtUtils _jwtUtils;

        public ItemLotService(IMapper mapper, IItemLotRepository itemLotRepository, JwtUtils jwtUtils)
        {
            _mapper = mapper;
            _itemLotRepository = itemLotRepository;
            _jwtUtils = jwtUtils;
        }

        public async Task<IEnumerable<ItemLotViewDTO>> GetAllItemLotsAsync()
        {
            var itemLots = await _itemLotRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<ItemLotViewDTO>>(itemLots);
        }

        public async Task<ItemLotViewDTO?> GetItemLotByIdAsync(Guid id)
        {
            var itemLot = await _itemLotRepository.GetByIdAsync(id);
            return _mapper.Map<ItemLotViewDTO?>(itemLot);
        }

        public async Task<ItemLotViewDTO> CreateItemLotAsync(ItemLotCreateDTO itemLotDTO)
        {
            var itemLot = _mapper.Map<ItemLot>(itemLotDTO);
            itemLot.ItemLotId = Guid.NewGuid();
            itemLot.Status = Common.Enums.LotStatus.Pending;

            await _itemLotRepository.AddAsync(itemLot);
            return _mapper.Map<ItemLotViewDTO>(itemLot);
        }

        public async Task<bool> UpdateItemLotAsync(Guid id, ItemLotUpdateDTO itemLotDTO)
        {
            var itemLot = await _itemLotRepository.GetByIdAsync(id);
            if (itemLot == null) return false;

            _mapper.Map(itemLotDTO, itemLot);
            await _itemLotRepository.UpdateAsync(itemLot);
            return true;
        }

        public async Task<bool> UpdatItemLotAdminAsync(Guid id, ItemLotAdminUpdateDTO itemLotDTO)
        {
            var itemLot = await _itemLotRepository.GetByIdAsync(id);
            if (itemLot == null) return false;

            _mapper.Map(itemLotDTO, itemLot);
            await _itemLotRepository.UpdateAsync(itemLot);
            return true;

        }
        public async Task<bool> DeleteItemLotAsync(Guid id)
        {
            var itemLot = await _itemLotRepository.GetByIdAsync(id);
            if (itemLot == null) return false;

            await _itemLotRepository.DeleteAsync(id);
            return true;
        }

        public async Task<IEnumerable<ItemLotViewDTO>> GetExpiredItemsByDateAsync(DateTime date)
        {
            var itemLots = await _itemLotRepository.GetExpiredItemsByDateAsync(date);
            return _mapper.Map<IEnumerable<ItemLotViewDTO>>(itemLots);
        }

        public async Task<IEnumerable<ItemLotViewDTO>> GetByItemIdAsync(Guid itemId)
        {
            var itemLots = await _itemLotRepository.GetByItemIdAsync(itemId);
            return _mapper.Map<IEnumerable<ItemLotViewDTO>>(itemLots);
        }

        public async Task<IEnumerable<ItemLotViewDTO>> GetItemLotByStorageAsync(int storageId)
        {
            var itemLots = await _itemLotRepository.GetByStorageIdAsync(storageId);
            return _mapper.Map<IEnumerable<ItemLotViewDTO>>(itemLots);
        }

        public async Task<IEnumerable<ItemLotViewDTO>> GetByStorageIdForStaffAsync()
        {
            var user = await _jwtUtils.GetUserFromToken();
            Console.WriteLine("User storage: "+ user.StorageId.Value);
            var itemLots = await _itemLotRepository.GetByStorageIdForStaffAsync(user.StorageId.Value);
            return _mapper.Map<IEnumerable<ItemLotViewDTO>>(itemLots);
        }

        public async Task<IEnumerable<ItemLotViewDTO>> GetLotCreateRequestAsync()
        {
            var itemLots = await _itemLotRepository.GetCreateLotRequestAsync();
            return _mapper.Map<IEnumerable<ItemLotViewDTO>>(itemLots);
        }
    }
}
