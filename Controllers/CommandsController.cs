using System.Collections.Generic;
using AutoMapper;
using Commander.Data;
using Commander.Dtos;
using Commander.Models;
using Microsoft.AspNetCore.Mvc;

namespace Commander.Controllers
{
	[Route("api/command")]
	[ApiController]
	public class CommanderController : ControllerBase
	{
		private readonly ICommanderRepo _repository;
		private readonly IMapper _mapper;

		public CommanderController(ICommanderRepo repository, IMapper mapper)
		{
			_repository = repository;
			_mapper = mapper;
		}
		
		[HttpGet]
		public ActionResult <IEnumerable<CommandReadDto>> GetAllCommands()
		{
			var commandItems = _repository.GetAllCommand();
			return Ok(_mapper.Map<IEnumerable<CommandReadDto>>(commandItems));
		}

		[HttpGet("{id}", Name = "GetCommandById")]
		public ActionResult <CommandReadDto> GetCommandById(int id)
		{
			var command = _repository.GetCommandById(id);
			if(command != null)
			{
				return Ok(_mapper.Map<CommandReadDto>(command));
			}
			else
			{
				return NotFound();
			}

		}

		// post api/command
		[HttpPost]
		public ActionResult<CommandReadDto> CreateCommand(CommandCreateDto commandCreateDto)
		{
			var commandModel = _mapper.Map<Command>(commandCreateDto);
			_repository.CreatCommand(commandModel);
			_repository.SaveChanges();
			var commandReadDto = _mapper.Map<CommandReadDto>(commandModel);
			return CreatedAtRoute(nameof(GetCommandById), new {Id = commandModel.Id}, commandReadDto);
		}

		// put api/command
		[HttpPut("{id}")]
		public ActionResult<CommandUpdateDto> UpdateCommand(int id, CommandUpdateDto commandUpdateDto)
		{
			var commandModelFromRepo = _repository.GetCommandById(id);
			if(commandModelFromRepo == null)
			{
				return NotFound();
			}

			_mapper.Map(commandUpdateDto, commandModelFromRepo);
			_repository.UpdateCommand(commandModelFromRepo);
			_repository.SaveChanges();

			return NoContent();
		}
	}

}