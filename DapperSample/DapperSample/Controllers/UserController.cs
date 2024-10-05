using Dapper;
using DapperSample.DataAccess;
using DapperSample.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Numerics;
using System.Xml.Linq;

namespace DapperSample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController(IDataContext context) : ControllerBase
    {
        private readonly IDataContext _context = context;

        [HttpPost]
        public async Task<IActionResult> CreateUser([Required] string name, [Required] string phone)
        {
            var parameters = new { Name = name, Phone = phone, IsAuthor = false };

            await _context.Db
                .ExecuteAsync("INSERT INTO Users (Name, Phone,IsAuthor) VALUES (@Name, @Phone , @IsAuthor);", parameters);

            return Ok("Done.");
        }

        [HttpPut]
        public async Task<IActionResult> AddToAuthors([Required] string userId)
        {
            var parameters = new { IsAuthor = true, userId = userId };

            await _context.Db
                .ExecuteAsync("UPDATE Users SET IsAuthor = @IsAuthor WHERE Id = @userId",parameters);

            return Ok("Done.");
        }
    }
}
