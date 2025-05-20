using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourApp.Context;
using YourApp.DTO;
using YourApp.Models;

namespace YourApp.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        public IGenericRepository<User> Users { get; }

        private IGenericRepository<Platform> _platforms;
        private IGenericRepository<Command> _commands;


        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            Users = new GenericRepository<User>(context);
        }

        public async Task<int> CompleteAsync() => await _context.SaveChangesAsync();

        public IGenericRepository<Platform> Platforms =>
            _platforms ??= new GenericRepository<Platform>(_context);

        public IGenericRepository<Command> Commands =>
            _commands ??= new GenericRepository<Command>(_context);

        public IGenericRepository<T> Repository<T>() where T : class
        {
            return new GenericRepository<T>(_context);
        }

        public void Dispose()
        {
            _context.Dispose();
        }

    } 
}
