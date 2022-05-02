using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillStudioApplication.Interfaces
{
        public interface IRepository<T>
        {
            Task<IEnumerable<T>> GetAllAsync(Guid Id);
            Task<T> GetByIdAsync(Guid id);
            Task<Guid> InsertAsync(T obj);
            Task UpdateAsync(T obj);
            Task DeleteAsync(Guid id);
        }
}
