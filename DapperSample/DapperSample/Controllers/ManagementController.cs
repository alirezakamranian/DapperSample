using Dapper;
using DapperSample.DataAccess;
using DapperSample.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DapperSample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManagementController(IDataContext context) : ControllerBase
    {
        private readonly IDataContext _context = context;

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _context.Db
                .QueryAsync<User>("SELECT * FROM Users;");

            return Ok(users);
        }

        [HttpGet("search")]
        public async Task<IActionResult> GetAllUsers(string chars)
        {
            var users = await _context.Db
                .QueryAsync<User>($"SELECT * FROM Users WHERE Name LIKE '%{chars}%';");

            return Ok(users);
        }
    }
}
