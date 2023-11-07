using ProyectoLaboBackEnd.Models.User;
using System.ComponentModel.DataAnnotations;

namespace ProyectoLaboBackEnd.Models.Comment.Dto
{
    public class UpdateCommentsDto
    {
        public string MainContent { get; set; }
        public string? Media { get; set; }
    }
}