using System.Collections.Generic;
using Commander.Models;

namespace Commander.Data
{
	public class MockCommanderRepo : ICommanderRepo
	{
		public IEnumerable<Command> GetAllCommand()
		{
			var commands = new List<Command>
			{
				new Command{Id=0, HowTo="Boil an egg",Line="Boil water", Platform="Kettle  Pan"},
				new Command{Id=1, HowTo="Make Coffee",Line="Boil Water, Pour Coffee", Platform="Kettle  Pan"},
				new Command{Id=2, HowTo="Cut Bread",Line="Get a knife", Platform="Kettle  Pan"},
				new Command{Id=3, HowTo="Make Pizza",Line="Buy Cheese", Platform="Kettle  Pan"},
			};
			return commands;
		}

		public Command GetCommandById(int id)
		{
			return new Command{Id=0, HowTo="Boil an egg", Platform="Kettle  Pan"};
		}
	}
}