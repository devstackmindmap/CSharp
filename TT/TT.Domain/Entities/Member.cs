using System.ComponentModel.DataAnnotations;

namespace TT.Domain.Entities
{
    public class Member
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
 