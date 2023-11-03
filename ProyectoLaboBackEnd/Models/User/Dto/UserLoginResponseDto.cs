namespace ProyectoLaboBackEnd.Models.User.Dto
{
    public class UserLoginResponseDto
    {
        public int UserID { get; set; }
        public string Name { get; set; } = null!;
        public string? Email { get; set; }
        public string UserName { get; set; } = null!;
        public List<string> Roles { get; set; } = null!;
    }
}
