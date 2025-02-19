using AutoMapper;
using BLL.DTOs;
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
    public class LotCategoryService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public LotCategoryService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<LotCategoryViewDTO> CreateLotCategory(LotCategoryCreateDTO lotCategoryDTO)
        {
            var lotCategory = _mapper.Map<LotCategory>(lotCategoryDTO);
            await _context.LotCategories.AddAsync(lotCategory);
            await _context.SaveChangesAsync();
            return _mapper.Map<LotCategoryViewDTO>(lotCategory);
        }

        public async Task<bool> DeleteLotCategory(Guid id)
        {
            var lotCategory = await _context.LotCategories.FirstOrDefaultAsync(x => x.Id == id);
            if (lotCategory == null) return false;

            _context.LotCategories.Remove(lotCategory);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<LotCategoryViewDTO>> GetAllLotCategories()
        {
            var lotCategories = await _context.LotCategories.ToListAsync();
            return _mapper.Map<IEnumerable<LotCategoryViewDTO>>(lotCategories);
        }

        public async Task<LotCategoryViewDTO?> GetLotCategory(Guid id)
        {
            var lotCategory = await _context.LotCategories.FirstOrDefaultAsync(x => x.Id == id);
            return _mapper.Map<LotCategoryViewDTO?>(lotCategory);
        }

        public async Task<bool> UpdateLotCategory(Guid id, LotCategoryUpdateDTO lotCategoryDTO)
        {
            var lotCategory = await _context.LotCategories.FirstOrDefaultAsync(x => x.Id == id);
            if (lotCategory == null) return false;

            _mapper.Map(lotCategoryDTO, lotCategory);
            await _context.SaveChangesAsync();
            return true;
        }
    }

}
