using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata;
using cldv6211TheRideYouRent.Models;

namespace cldv6211TheRideYouRent.Services
{
    public class AccountServiceImpl : AccountService
    {
        private List<Account> accounts;

        public AccountServiceImpl()
        {
            accounts = new List<Account>
            {
                new Account
                {
                    UserName = "bud@therideyourent.com",
                    Password = "I101",
                    FullName = "Bud Barnes"
                },

                new Account
                {
                    UserName = "tracy@therideyourent.com",
                    Password = "I102",
                    FullName = "Tracy Reeves"
                },

                new Account
                {
                    UserName = "sandra@therideyourent.com",
                    Password = "I103",
                    FullName = "Sandra Goodwin"
                },
                new Account
                {
                    UserName = "shannon@therideyourent.com",
                    Password = "I104",
                    FullName = "Shannon Burke"
                },

                new Account
                {
                    UserName = "Admin",
                    Password = "Admin1",
                    FullName = "Admin"
                }
            };
        }

        public Account Login(string username, string password)
        {
            return accounts.SingleOrDefault(a => a.UserName == username && a.Password == password);
            //return accounts.FirstOrDefault(a => a.UserName == username && a.Password == password);

        }
    }
}
