using System.ComponentModel.DataAnnotations;

namespace DapperSample.Models.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public bool IsAuthor { get; set; }
        public Author Author { get; set; }
    }
}
