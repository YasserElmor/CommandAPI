using CommandAPI.Models;

namespace CommandAPI.Data
{
    public interface ICommandAPIRepo
    {
        Task<bool> SaveChangesAsync();
        Task<IEnumerable<Command>> GetAllCommandsAsync();
        Task<Command> GetCommandByIdAsync(int id);

        Task CreateCommandAsync(Command cmd);
        Task UpdateCommandAsync(Command cmd);
        Task DeleteCommandAsync(Command cmd);
    }
}