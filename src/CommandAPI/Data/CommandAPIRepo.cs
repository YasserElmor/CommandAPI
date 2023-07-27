using CommandAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CommandAPI.Data
{
    public class CommandAPIRepo : ICommandAPIRepo
    {
        private readonly CommandContext _context;

        public CommandAPIRepo(CommandContext context)
        {
            _context = context;
        }
        public async Task CreateCommandAsync(Command cmd)
        {
            await _context.CommandItems.AddAsync(cmd);
        }

        public async Task DeleteCommandAsync(Command cmd)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Command>> GetAllCommandsAsync()
        {
            return await _context.CommandItems.ToListAsync();
        }

        public async Task<Command> GetCommandByIdAsync(int id)
        {
            return await _context.CommandItems.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) >= 0;
        }

        public async Task UpdateCommandAsync(Command cmd)
        {
            throw new NotImplementedException();
        }
    }
}