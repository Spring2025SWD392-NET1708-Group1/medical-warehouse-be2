using AutoMapper;
using DAL.Context;
using BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DTOs;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace BLL.Services
{
    public class ItemCategoryService : IItemCategoryService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public ItemCategoryService(AppDbContext context, IMapper mapper)
        {
            _context = context; 
            _mapper = mapper;
        }

        public async Task<ItemCategoryDTO> CreateCategoryAsync(ItemCategoryDTO itemcategoryDTO)
        {
            var category = _mapper.Map<ItemCategory>(itemcategoryDTO);
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
            return _mapper.Map<ItemCategoryDTO>(category);
        }

        public async Task<bool> DeleteCategoryAsync(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null) return false;
            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<ItemCategoryDTO>> GetAllCategoriesAsync()
        {
            var categories = await _context.Categories.ToListAsync();
            return _mapper.Map<IEnumerable<ItemCategoryDTO>>(categories);
        }

        public async Task<ItemCategoryDTO?> GetCategoryByIdAsync(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            return _mapper?.Map<ItemCategoryDTO?>(category);
        }

        public async Task<bool> UpdateCategoryAsync(int id, ItemCategoryDTO itemcategoryDTO)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null) return false;
            _mapper.Map<ItemCategoryDTO> (category);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
