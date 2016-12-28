using CarService.Core.DataAccessLayer.Repositories.Interfaces;
using CarService.Core.Entities;

namespace CarService.Core.BusinessLogicLayer
{
    public class UserBusinessLogic : BaseBusinessLogic<IUserRepository, User>, IUserBusinessLogic
    {
        /// <summary>
        /// Business Logic to work with app users
        /// </summary>
        public UserBusinessLogic(IUserRepository repository) : base(repository)
        {
        }
    }
}