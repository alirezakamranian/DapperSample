using System.ComponentModel.DataAnnotations;

namespace DapperSample.Models.Entities
{
    public class Article
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public List<AuthorArticles> ArticleAuthors { get; set; }
    }
}
