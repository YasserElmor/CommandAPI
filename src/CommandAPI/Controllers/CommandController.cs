using AutoMapper;
using CommandAPI.Data;
using CommandAPI.Dtos;
using CommandAPI.Models;
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
        public async Task<ActionResult<IEnumerable<CommandReadDto>>> GetAllCommandsAsync()
        {
            var commands = await _commandAPIRepo.GetAllCommandsAsync();

            if (commands is null)
                return NotFound();

            return Ok(_mapper.Map<IEnumerable<CommandReadDto>>(commands));
        }
        [HttpGet("{id}", Name = "GetCommandByIdAsync")]
        public async Task<ActionResult<CommandReadDto>> GetCommandByIdAsync(int id)
        {
            var command = await _commandAPIRepo.GetCommandByIdAsync(id);

            if (command is null)
                return NotFound();

            return Ok(_mapper.Map<CommandReadDto>(command));
        }

        [HttpPost]
        public async Task<ActionResult<CommandReadDto>> CreateCommandAsync(CommandCreateDto commandCreateDto)
        {
            var commandModel = _mapper.Map<Command>(commandCreateDto);

            await _commandAPIRepo.CreateCommandAsync(commandModel);
            await _commandAPIRepo.SaveChangesAsync();

            var commandReadDto = _mapper.Map<CommandReadDto>(commandModel);

            return CreatedAtRoute(nameof(GetCommandByIdAsync), new { Id = commandReadDto.Id }, commandReadDto);
        }
    }
}