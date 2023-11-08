using System.ComponentModel.DataAnnotations;

namespace ProyectoLaboBackEnd.Models.Community.Dto
{
    public class CommunityDto
    { 
        public int CommunityId { get; set; } 
        public string Name { get; set; } = null!;
        public bool State { get; set; }
    }
}
