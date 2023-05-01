using Microsoft.EntityFrameworkCore;
using OlderTask.Domain.Common;
using OlderTask.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OlderTask.Infrastructure;
using OrderTask.Business.Contracts.Persistence.IRepository;

namespace OrderTask.Business.Contracts.Persistence.Repository
{
    public class AsyncRepository<T> : IAsyncRepository<T> where T : Auditing
    {

        private readonly GlobalAppdbContext dbContext;
        public AsyncRepository(GlobalAppdbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<T> AddAsync(T Obj)
        {
            await dbContext.Set<T>().AddAsync(Obj);
            await dbContext.SaveChangesAsync();
            return Obj;
        }

        public async Task<T> DeleteAsync(T Obj)
        {
            dbContext.Set<T>().Remove(Obj);
            await dbContext.SaveChangesAsync();
            return Obj;
        }

        public async Task<T> DeleteAsync(int Id)
        {
            var Obj = await dbContext.Set<T>().FindAsync(Id);
            dbContext.Set<T>().Remove(Obj);
            await dbContext.SaveChangesAsync();
            return Obj;
        }

        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await dbContext.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int Id)
        {
            var obj = await dbContext.Set<T>().FindAsync(Id);
            return obj;
        }

        public async Task<T> UpdateAsync(T Obj)
        {
            dbContext.Entry(Obj).State = EntityState.Modified;
            await dbContext.SaveChangesAsync();
            return Obj;
        }

        public async Task<Order> GetOrderWithDetails(int Id)
        {
            return await dbContext.Orders.Where(x => x.Id == Id).Include(x => x.OrderDetails).FirstOrDefaultAsync();

        }

    }
}
