using System.Collections.Generic;
using Commander.Models;

namespace Commander.Data
{
	public interface ICommanderRepo
	{
		IEnumerable<Command> GetAllCommand(); 
		Command GetCommandById(int id);
	}
}