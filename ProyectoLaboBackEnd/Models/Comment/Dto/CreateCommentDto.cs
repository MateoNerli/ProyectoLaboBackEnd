using System;
using System.ComponentModel.DataAnnotations;

namespace ProyectoLaboBackEnd.Models.Comment.Dto
{
    public class CreateCommentsDto
    {
        public int PostId { get; set; }
        public int UserId { get; set; }
        public string? MainContent { get; set; }
        public string? Media { get; set; }
    }
}
