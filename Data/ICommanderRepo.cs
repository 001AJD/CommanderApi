using System.Collections.Generic;
using Commander.Models;

namespace Commander.Data
{
	public interface ICommanderRepo
	{
		IEnumerable<Command> GetAppCommand(); 
		Command GetCommandById(int id);
	}
}