using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GamesWeb.Models.DbModel
{
    public class UserModel
    {
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        //[Compare("repassword", ErrorMessage = "You have entered the password wrong.")]
        public string Password { get; set; }
        public string? PfpName { get; set; }
        public string? GameIds { get; set; } 
        public string? MembershipIds { get; set; }
    }
}
