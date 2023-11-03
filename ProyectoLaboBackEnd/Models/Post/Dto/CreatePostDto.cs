using System;
using System.ComponentModel.DataAnnotations;

namespace ProyectoLaboBackEnd.Models.Post.Dto
{
    public class CreatePostDto
    {
        public int UserId { get; set; }
        public DateTime DateTime { get; set; }
        public string Title { get; set; } = null!;
        public string MainContent { get; set; } = null!;
        public string? Media { get; set; }
        public int CommunityId { get; set; }

    }
}
