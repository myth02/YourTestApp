using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourApp.DTO;

namespace YourApp.Services
{
    public interface IPlatformService
    {
        Task<IEnumerable<PlatformDto>> GetAllAsync();
        Task<PlatformDto> GetByIdAsync(int id);
        Task<PlatformDto> CreateAsync(PlatformDto dto);
        Task<bool> UpdateAsync(int id, PlatformDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
