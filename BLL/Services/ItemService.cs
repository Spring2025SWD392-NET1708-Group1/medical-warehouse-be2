﻿using AutoMapper;
using BLL.DTOs;
using BLL.Interfaces;
using DAL.Context;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class ItemService : IItemService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public ItemService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ItemViewDTO> CreateItemAsync(ItemCreateDTO itemDTO)
        {
            var item = _mapper.Map<Item>(itemDTO);
            item.Id = Guid.NewGuid();

            await _context.Items.AddAsync(item);
            await _context.SaveChangesAsync();
            return _mapper.Map<ItemViewDTO>(item);
        }

        public async Task<bool> DeleteItemAsync(Guid id)
        {
            var item = await _context.Items.FirstOrDefaultAsync(x => x.Id == id);
            if (item == null) return false;
            _context.Items.Remove(item);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<ItemViewDTO>> GetAllItemsAsync()
        {
            var items = await _context.Items.ToListAsync();
            return _mapper.Map<IEnumerable<ItemViewDTO>>(items);
        }

        public async Task<ItemViewDTO?> GetItemByIdAsync(Guid id)
        {
            var item = await _context.Items.FirstOrDefaultAsync(x => x.Id == id);
            return item != null ? _mapper.Map<ItemViewDTO>(item) : null;
        }

        public async Task<bool> UpdateItemAsync(Guid id, ItemUpdateDTO itemDTO)
        {
            var item = await _context.Items.FirstOrDefaultAsync(x =>x.Id == id);
            if(item == null) return false;

            _mapper.Map(itemDTO, item);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
