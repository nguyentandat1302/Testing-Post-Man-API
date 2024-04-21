using System.ComponentModel.DataAnnotations;

namespace Testing_Post_Man_API.Models
{
    public class Users
    {

        [Key]
        public int Id { get; set; } 
        public string? FirstName { get; set; }
        public string? LastName { get; set;}

        public string? EmailAddress { get; set; }
    }
}
