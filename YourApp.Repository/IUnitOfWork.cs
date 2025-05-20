using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourApp.DTO;
using YourApp.Models;

namespace YourApp.Repository
{
    public interface IUnitOfWork
    {
        IGenericRepository<User> Users { get; }


        IGenericRepository<Platform> Platforms { get; }
        IGenericRepository<Command> Commands { get; }

        IGenericRepository<T> Repository<T>() where T : class;

        Task<int> CompleteAsync();

        
    }
}
