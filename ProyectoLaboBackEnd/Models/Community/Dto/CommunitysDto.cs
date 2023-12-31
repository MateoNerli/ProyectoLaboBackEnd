﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProyectoLaboBackEnd.Models.Community.Dto
{
    public class CommunitysDto
    {
        public string Name { get; set; } = null!;
        public bool State { get; set; }

        public List<CommunitysDto> Communities { get; set; } = new List<CommunitysDto>();
    }
}
