using AutoMapper;
using CommandAPI.Data;
using CommandAPI.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace CommandAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommandsController : ControllerBase
    {
        private readonly ICommandAPIRepo _commandAPIRepo;
        private readonly IMapper _mapper;

        public CommandsController(ICommandAPIRepo commandAPIRepo, IMapper mapper)
        {
            _commandAPIRepo = commandAPIRepo;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<CommandReadDto>> GetAllCommands()
        {
            var commands = _commandAPIRepo.GetAllCommands();

            if (commands is null)
                return NotFound();

            return Ok(_mapper.Map<IEnumerable<CommandReadDto>>(commands));
        }
        [HttpGet("{id}")]
        public ActionResult<CommandReadDto> GetCommandById(int id)
        {
            var command = _commandAPIRepo.GetCommandById(id);

            if (command is null)
                return NotFound();

            return Ok(_mapper.Map<CommandReadDto>(command));
        }
    }
}