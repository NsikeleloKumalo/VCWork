using cldv6211TheRideYouRent.Models;

namespace cldv6211TheRideYouRent.Services
{
    public interface AccountService
    {
        public Account Login(string username, string password);
    }
}
