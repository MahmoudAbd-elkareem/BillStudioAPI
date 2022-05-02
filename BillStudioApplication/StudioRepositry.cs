using BillStudio.Domain.Entities;
using BillStudio.Infrastructure;
using BillStudioApplication.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillStudioApplication
{
    public class StudioRepositry :IRepository<Studio>
    {
        private StudioBillDbContext _context;
        private DbSet<Studio> StudioEntity;

        public StudioRepositry(StudioBillDbContext context)
        {
            _context = context;
            StudioEntity = context.Set<Studio>();
        }

        public async Task<IEnumerable<Studio>> GetAllAsync(Guid Id)
        {
            return await StudioEntity.Where(s=>s.userId == Id).ToListAsync();
        }
        public async Task<Studio> GetByIdAsync(Guid id)
        {
            return await StudioEntity.FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<Guid> InsertAsync(Studio obj)
        {

            _context.Entry(obj).State = EntityState.Added;
            await _context.SaveChangesAsync();
            return obj.Id;
        }
        public async Task UpdateAsync(Studio obj)
        {
            _context.Entry(obj).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(Guid id)
        {
            Studio p = await GetByIdAsync(id);
            StudioEntity.Remove(p);
            await _context.SaveChangesAsync();
        }
    }
}
