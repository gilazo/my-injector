using MyInjector.Web.Models;

namespace MyInjector.Web.Services
{
    public class UserRetriever : ILookupUsers
    {
        public UserViewModel GetUser()
        {
            return new UserViewModel
            {
                FirstName = "Jon",
                LastName = "Doe",
                Email = "jon.doe@test.com"
            };
        }
    }
}