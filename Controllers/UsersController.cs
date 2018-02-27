using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TCN.Controllers.Resources;
using TCN.Models;
using TCN.Persistence;

namespace TCN.Controllers
{
    public class UsersController : Controller
    {
        private readonly TcnDbContext context;
        private readonly IMapper mapper;
        public UsersController(TcnDbContext context, IMapper mapper)
        {
            this.mapper = mapper;
            this.context = context;
        }
        [HttpGet("/api/users")]
        public async Task<IEnumerable<UserResource>> GetUsers()
        {
            var users = await context.Users.Include(u => u.Transactions).ToListAsync();
            return mapper.Map<List<User>, List<UserResource>>(users);
        }
    }
}