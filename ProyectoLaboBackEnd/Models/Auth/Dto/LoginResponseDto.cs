﻿using ProyectoLaboBackEnd.Models.User.Dto;

namespace ProyectoLaboBackEnd.Models.Auth.Dto
{
    public class LoginResponseDto
    {
        public string Token { get; set; } = null!;
        public UserLoginResponseDto User { get; set; } = null!;
    }
}
