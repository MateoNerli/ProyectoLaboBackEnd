using ProyectoLaboBackEnd.Models.User;
using System.ComponentModel.DataAnnotations;

namespace ProyectoLaboBackEnd.Models.Community.Dto
{
    public class UpdateComunityDto
    {
        public string Name { get; set; } = null!;
        public bool State { get; set; }
    }
}