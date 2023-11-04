using System;
using System.ComponentModel.DataAnnotations;

namespace ProyectoLaboBackEnd.Models.Post.Dto
{
    public class CreatePostDto
    {
        [Required]
        public int UserId { get; set; }
        [Required]
        [MaxLength(50)]
        public string Title { get; set; } = null!;
        [Required]
        [MaxLength(300)]
        public string MainContent { get; set; } = null!;
        public string? Media { get; set; }
        [Required]
        public int CommunityId { get; set; }

    }
}
