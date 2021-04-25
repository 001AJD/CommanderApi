using System.Collections.Generic;
using Commander.Data;
using Commander.Models;
using Microsoft.AspNetCore.Mvc;

namespace Commander.Controllers
{
	[Route("api/command")]
	[ApiController]
	public class CommanderController : ControllerBase
	{
		private readonly ICommanderRepo _repository;
		public CommanderController(ICommanderRepo repository)
		{
			_repository = repository;
		}
		
		[HttpGet]
		public ActionResult <IEnumerable<Command>> GetAllCommands()
		{
			var commandItems = _repository.GetAllCommand();
			return Ok(commandItems);
		}

		[HttpGet("{id}")]
		public ActionResult <Command> GetCommandById(int id)
		{
			var command = _repository.GetCommandById(id);

			return Ok(command);

		}
	}

}