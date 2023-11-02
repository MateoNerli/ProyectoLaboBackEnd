using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProyectoLaboBackEnd.Models.Community.Dto
{
    public class CommunityDto
    {
        public int CommunityId { get; set; }
        public string Name { get; set; }
        public bool State { get; set; }
    }
}
