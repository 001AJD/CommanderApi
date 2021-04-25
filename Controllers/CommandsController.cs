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

		[HttpGet("{id}")]
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
	}

}