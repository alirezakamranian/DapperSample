using Microsoft.AspNetCore.Mvc.Infrastructure;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DapperSample.Models.Entities
{
    public class Author
    {
        [Key]
        public int  Id { get; set; }
        public string PublicName { get; set; }
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }
        public  List<AuthorArticles> AuthorArticles { get; set; }
    }
}
