using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourApp.DTO;
using YourApp.Context;

namespace YourApp.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        public IGenericRepository<User> Users { get; }
    

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            Users = new GenericRepository<User>(context);
        }

        public async Task<int> CompleteAsync() => await _context.SaveChangesAsync();

    } 
}
