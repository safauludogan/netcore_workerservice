using DataAccess.Models;

namespace Service.Idenfit.Login.Abstract
{
    public interface IAuthanticationService
    {
        public Task<Token> Login();
    }
}
