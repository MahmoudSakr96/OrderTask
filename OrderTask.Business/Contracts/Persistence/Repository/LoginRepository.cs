using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OlderTask.Domain.Entities;
using OlderTask.Infrastructure;
using OrderTask.Business.Contracts.Persistence.IRepository;

namespace OrderTask.Business.Contracts.Persistence.Repository
{
    public class LoginRepository : ILoginRepository
    {
        private readonly GlobalAppdbContext _context;

        public LoginRepository(GlobalAppdbContext context)
        {
            _context = context;
        }
        public ApplicationUser AuthenticateUser(string username, string passcode)
        {
            var succeeded = _context.ApplicationUsers.FirstOrDefault(authUser => authUser.Email == username && authUser.PasswordHash == passcode);
            return succeeded;
        }

        public IEnumerable<ApplicationUser> getuser()
        {
            return _context.ApplicationUsers.ToList();
        }
    }
}
