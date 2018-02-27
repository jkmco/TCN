using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TCN.Models;
using TCN.Persistence;

namespace TCN.Controllers
{
    public class UsersController : Controller
    {
        private readonly TcnDbContext context;
        public UsersController(TcnDbContext context)
        {
            this.context = context;
        }
        [HttpGet("/api/users")]
        public async Task<IEnumerable<User>> GetUsers()
        {
            return await context.Users.Include(u => u.Transactions).ToListAsync();
        }
    }
}