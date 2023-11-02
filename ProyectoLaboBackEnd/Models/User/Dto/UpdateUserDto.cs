using System.ComponentModel.DataAnnotations;

namespace ProyectoLaboBackEnd.Models.User.Dto
{
    public class UpdateUserDto
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Pfp { get; set; }
        public DateTime BirthDate { get; set; }
        public string? Phone { get; set; }
    }
}
