using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourApp.DTO;

namespace YourApp.Services
{
    public interface ICommandService
    {
        Task<IEnumerable<CommandDto>> GetAllAsync();
        Task<CommandDto> GetByIdAsync(int id);
        Task<CommandDto> CreateAsync(CommandDto dto);
        Task<bool> UpdateAsync(int id, CommandDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
