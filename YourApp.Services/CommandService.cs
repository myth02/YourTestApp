using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourApp.DTO;
using YourApp.Repository;
using YourApp.Models;

namespace YourApp.Services
{
    public class CommandService : ICommandService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGenericRepository<Command> _commandRepo;

        public CommandService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _commandRepo = _unitOfWork.Repository<Command>();
        }

        public async Task<IEnumerable<CommandDto>> GetAllAsync()
        {
            var commands = await _commandRepo.GetAllAsync();
            return commands.Select(c => new CommandDto { Id = c.Id, Instruction = c.Instruction, PlatformId = c.PlatformId });
        }

        public async Task<CommandDto> GetByIdAsync(int id)
        {
            var command = await _commandRepo.GetByIdAsync(id);
            return command == null ? null : new CommandDto { Id = command.Id, Instruction = command.Instruction, PlatformId = command.PlatformId };
        }

        public async Task<CommandDto> CreateAsync(CommandDto dto)
        {
            var command = new Command { Instruction = dto.Instruction, PlatformId = dto.PlatformId };
            await _commandRepo.AddAsync(command);
            await _unitOfWork.CompleteAsync();
            dto.Id = command.Id;
            return dto;
        }

        public async Task<bool> UpdateAsync(int id, CommandDto dto)
        {
            var command = await _commandRepo.GetByIdAsync(id);
            if (command == null) return false;

            command.Instruction = dto.Instruction;
            command.PlatformId = dto.PlatformId;
            _commandRepo.Update(command);
            await _unitOfWork.CompleteAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var command = await _commandRepo.GetByIdAsync(id);
            if (command == null) return false;

            _commandRepo.Delete(command);
            await _unitOfWork.CompleteAsync();
            return true;
        }
    }
}
