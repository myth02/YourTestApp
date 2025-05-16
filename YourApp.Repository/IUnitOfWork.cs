using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourApp.DTO;

namespace YourApp.Repository
{
    public interface IUnitOfWork
    {
        IGenericRepository<User> Users { get; }
        Task<int> CompleteAsync();
    }
}
