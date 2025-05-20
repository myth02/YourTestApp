using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourApp.DTO;
using YourApp.Models;
using YourApp.Repository;

namespace YourApp.Services
{
    public class PlatformService : IPlatformService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGenericRepository<Platform> _platformRepo;

        public PlatformService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _platformRepo = _unitOfWork.Repository<Platform>();
        }

        public async Task<IEnumerable<PlatformDto>> GetAllAsync()
        {
            var platforms = await _platformRepo.GetAllAsync();
            return platforms.Select(p => new PlatformDto { Id = p.Id, Name = p.Name });
        }

        public async Task<PlatformDto> GetByIdAsync(int id)
        {
            var platform = await _platformRepo.GetByIdAsync(id);
            return platform == null ? null : new PlatformDto { Id = platform.Id, Name = platform.Name };
        }

        public async Task<PlatformDto> CreateAsync(PlatformDto dto)
        {
            var platform = new Platform { Name = dto.Name };
            await _platformRepo.AddAsync(platform);
            await _unitOfWork.CompleteAsync();
            dto.Id = platform.Id;
            return dto;
        }

        public async Task<bool> UpdateAsync(int id, PlatformDto dto)
        {
            var platform = await _platformRepo.GetByIdAsync(id);
            if (platform == null) return false;

            platform.Name = dto.Name;
            _platformRepo.Update(platform);
            await _unitOfWork.CompleteAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var platform = await _platformRepo.GetByIdAsync(id);
            if (platform == null) return false;

            _platformRepo.Delete(platform);
            await _unitOfWork.CompleteAsync();
            return true;
        }
    }
}
