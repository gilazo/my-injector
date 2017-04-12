using MyInjector.Web.Models;

namespace MyInjector.Web.Services
{
    public interface ILookupUsers
    {
        UserViewModel GetUser();
    }
}