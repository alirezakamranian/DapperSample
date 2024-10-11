using Dapper;
using DapperSample.DataAccess;
using DapperSample.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Numerics;
using System.Xml.Linq;

namespace DapperSample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManagementController(IDataContext context) : ControllerBase
    {
        private readonly IDataContext _context = context;


        [HttpGet("searchusers")]
        public async Task<IActionResult> SearchInUsers(string chars)
        {
            var users = await _context.Db
                .QueryAsync<User>($"SELECT * FROM Users WHERE Name LIKE '%{chars}%';");

            return Ok(users);
        }

        [HttpGet("authorscount")]
        public async Task<IActionResult> GetAuthorsCount()
        {
            var parameters = new { IsAuthor = true };
            var users = await _context.Db
                .QueryAsync($"SELECT Count(Id) As AuthorsCount FROM Users WHERE IsAuthor = @IsAuthor", parameters);

            return Ok(users);
        }

        [HttpGet("usersarticles")]
        public async Task<IActionResult> GetUsersArticlesCount(int minimumNumber = 0)
        {
            var parameters = new { MinimumNumber = minimumNumber };

            var articlesCount = await _context.Db
                .QueryAsync($"SELECT COUNT(AuthorArticles.ArticleId) AS ArticleCount,AuthorId FROM AuthorArticles,Authors GROUP BY AuthorId HAVING COUNT(AuthorArticles.ArticleId) >= @MinimumNumber",parameters);

            return Ok(articlesCount);
        }

        [HttpGet("authordetail")]
        public async Task<IActionResult> GetUsersArticlesCount(string authorId )
        {
            var parameters = new { AuthorId = authorId };

            var articlesCount = await _context.Db
                .QueryAsync($"SELECT Authors.*,Users.Name,Users.Phone FROM Users INNER JOIN Authors ON Authors.UserId = Users.Id WHERE Authors.Id = @AuthorId;", parameters);

            return Ok(articlesCount);
        }
    }
}
