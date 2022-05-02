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
    public class UserRepositry : IRepository<User>
    {
        private StudioBillDbContext _context;
        private DbSet<User> UserEntity;
        private DbSet<Studio> StudioEntity;

        public UserRepositry(StudioBillDbContext context)
        {
            _context = context;
            UserEntity = context.Set<User>();
            StudioEntity = context.Set<Studio>();
        }

        public async Task<IEnumerable<User>> GetAllAsync(Guid Id)
        {
           throw new NotImplementedException();
        }
        public async Task<User> GetByIdAsync(Guid id)
        {
            return await UserEntity.FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<Guid> InsertAsync(User obj)
        {
            _context.Entry(obj).State = EntityState.Added;
            obj.Studios.ForEach(s => _context.Entry(s).State = EntityState.Added);
            await _context.SaveChangesAsync();

            return obj.Id;
        }
        public async Task UpdateAsync(User obj)
        {
            _context.Entry(obj).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(Guid id)
        {
            User p = await GetByIdAsync(id);
            UserEntity.Remove(p);
            await _context.SaveChangesAsync();
        }
    }
}
