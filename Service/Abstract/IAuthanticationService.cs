using DataAccess.Models;

namespace Service.Abstract
{
	public interface IAuthanticationService
	{
		public Task<Token> Login();
	}
}
