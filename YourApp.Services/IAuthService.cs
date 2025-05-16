using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourApp.DTO;

namespace YourApp.Services
{
    public interface IAuthService
    {
        Task<string> RegisterAsync(User user, string password);

        Task<string> LoginAsync(string username, string password);
    }
}
