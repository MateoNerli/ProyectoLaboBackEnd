using System;
using System.ComponentModel.DataAnnotations;

namespace ProyectoLaboBackEnd.Models.Community.Dto
{
    public class CreateComunityDto
    {
        public string Name { get; set; } = null!;
        public bool State { get; set; }
    }
}
