using CommandAPI.Data;
using CommandAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace CommandAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommandsController : ControllerBase
    {
        private readonly ICommandAPIRepo _commandAPIRepo;

        public CommandsController(ICommandAPIRepo commandAPIRepo)
        {
            _commandAPIRepo = commandAPIRepo;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Command>> GetAllCommands()
        {
            var commands = _commandAPIRepo.GetAllCommands();

            if (commands is null)
                return NotFound();

            return Ok(commands);
        }
        [HttpGet("{id}")]
        public ActionResult<Command> GetCommandById(int id)
        {
            var command = _commandAPIRepo.GetCommandById(id);

            if (command is null)
                return NotFound();

            return Ok(command);
        }
    }
}