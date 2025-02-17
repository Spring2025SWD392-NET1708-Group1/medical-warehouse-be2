using AutoMapper;
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
        public async Task<ItemDTO> CreateItemAsync(ItemDTO itemDTO)
        {
            var item = _mapper.Map<Item>(itemDTO);
            await _context.Items.AddAsync(item);
            await _context.SaveChangesAsync();
            return _mapper.Map<ItemDTO>(item);
        }

        public async Task<bool> DeleteItemAsync(int id)
        {
            var item = await _context.Items.FindAsync(id);
            if(item == null) return false;
            _context.Items.Remove(item);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<ItemDTO>> GetAllItemsAsync()
        {
            var items = await _context.Items.ToListAsync();
            return _mapper.Map<IEnumerable<ItemDTO>>(items);
        }

        public async Task<ItemDTO?> GetItemByIdAsync(int id)
        {
            var item = await _context.Items.FirstOrDefaultAsync(x => x.Id == id);
            return _mapper.Map<ItemDTO?>(item);
        }

        public async Task<bool> UpdateItemAsync(int id, ItemDTO itemDTO)
        {
            var item = await _context.Items.FirstOrDefaultAsync(x =>x.Id == id);
            if(item == null) return false;

            _mapper.Map(itemDTO, item);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
