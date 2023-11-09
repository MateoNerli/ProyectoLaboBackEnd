using System.ComponentModel.DataAnnotations;

namespace ProyectoLaboBackEnd.Models.User.Dto
{
    public class UpdateUserDto
    {
        [MaxLength(30)]
        public string? Name { get; set; } 
        [MaxLength(40)]
        public string? LastName { get; set; } 
        [MaxLength(40)]
        public string? UserName { get; set; }
        [EmailAddress]
        public string? Email{ get; set; } 
        [MaxLength(40)]
        public string? Pfp { get; set; }
        [MaxLength(40)]
        public string? Phone { get; set; }
    }
}
