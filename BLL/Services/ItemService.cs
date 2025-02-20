﻿using AutoMapper;
using BLL.DTOs;
using BLL.Interfaces;
using DAL.Entities;
using DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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

        public async Task<IEnumerable<ItemViewDTO>> GetAllItemsAsync()
        {
            var items = await _itemRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<ItemViewDTO>>(items);
        }

        public async Task<ItemViewDTO?> GetItemByIdAsync(Guid id)
        {
            var item = await _itemRepository.GetByIdAsync(id);
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
    }
}
