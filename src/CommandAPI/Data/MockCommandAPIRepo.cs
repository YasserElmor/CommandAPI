using CommandAPI.Models;

namespace CommandAPI.Data
{
    public class MockCommandAPIRepo : ICommandAPIRepo
    {
        public async Task<IEnumerable<Command>> GetAllCommandsAsync()
        {

            var commands = new List<Command>
            {
                new Command{
                    Id = 0,
                    HowTo = "Generate a Migration",
                    CommandLine = "dotnet ef migrations add <Name of Migration>",
                    Platform = ".NET Core EF"
                },
                new Command{
                    Id = 1,
                    HowTo = "Run Migrations",
                    CommandLine = "dotnet ef database update",
                    Platform = ".NET Core EF"
                },
                new Command{
                    Id = 2,
                    HowTo = "List Active Migrations",
                    CommandLine = "dotnet ef migrations list",
                    Platform = ".NET Core EF"
                }
            };

            return commands;
        }

        public async Task<Command> GetCommandByIdAsync(int id)
        {
            var command = new Command
            {
                Id = 0,
                HowTo = "Generate a Migration",
                CommandLine = "dotnet ef migrations add <Name of Migration>",
                Platform = ".NET Core EF"
            };

            return command;
        }

        public async Task<bool> SaveChangesAsync()
        {
            throw new NotImplementedException();
        }

        public void UpdateCommand(Command cmd)
        {
            throw new NotImplementedException();
        }

        public async Task CreateCommandAsync(Command cmd)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteCommandAsync(Command cmd)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateCommandAsync(Command cmd)
        {
            throw new NotImplementedException();
        }
    }
}