using System;
using System.ComponentModel.DataAnnotations;

namespace ProyectoLaboBackEnd.Models.Community.Dto
{
    public class CreateComunityDto
    {
        public string Name { get; set; }
        public bool State { get; set; }
    }
}
