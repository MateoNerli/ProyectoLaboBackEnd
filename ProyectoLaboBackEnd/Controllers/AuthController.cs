﻿using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProyectoLaboBackEnd.Enums;
using ProyectoLaboBackEnd.Models.Auth;
using ProyectoLaboBackEnd.Models.Auth.Dto;
using ProyectoLaboBackEnd.Models.Role;
using ProyectoLaboBackEnd.Models.Role.Dto;
using ProyectoLaboBackEnd.Models.User;
using ProyectoLaboBackEnd.Models.User.Dto;
using ProyectoLaboBackEnd.Services;

    //maneja la autenticación y la autorización de usuarios

namespace ProyectoLaboBackEnd.Controllers
{
    [Route("api/auth")]
   /* [Authorize]  */  //esto significa que el usuario debe iniciar sesión antes de poder acceder a estas acciones
    [ApiController]
    public class AuthController : ControllerBase
    {
        //Inyeccion de dependencias
        private readonly UserService _userService;
        private readonly IEncoderService _encoderService;
        private readonly AuthService _authService;
        private readonly RoleService _roleService;

        public AuthController(UserService userService, IEncoderService encoderService, AuthService authService, RoleService roleService, IMapper mapper)
        {
            _userService = userService;
            _encoderService = encoderService;
            _authService = authService;
            _roleService = roleService;
        }

        [HttpPost("login")]    //se verifican las credenciales, y  si son validas se genera token 
        [AllowAnonymous]    //Permite el acceso a esta acción sin autenticación
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<LoginResponseDto>> Login([FromBody] Login login)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                if (login.Email == null && login.UserName == null)
                {
                    ModelState.AddModelError("Error", "Credentials are incorrect");
                    return BadRequest(ModelState);
                }

                var user = await _userService.GetByUsernameOrEmail(login.UserName, login.Email);

                if (user == null || !_encoderService.Verify(login.Password, user.Password))
                {
                    ModelState.AddModelError("Error", "Credentials are incorrect");
                    return BadRequest(ModelState);
                }

                var userResponse = new UserLoginResponseDto
                {
                    UserID = user.UserId,
                    Name = user.Name,
                    UserName = user.UserName,
                    Email = user.Email,
                    Roles = user.Roles.Select(p => p.Name).ToList()
                };

                string token = _authService.GenerateJwtToken(user);

                return Ok(new LoginResponseDto { Token = token, User = userResponse });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost("register")]    //Registamos un usuario se verifica que no exista
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<UserDto>> Register([FromBody] CreateUserDto register)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var user = await _userService.GetByUsernameOrEmail(register.UserName, register.Email);

                if (user != null)
                {
                    ModelState.AddModelError("Error", "User already exists");
                    return BadRequest(ModelState);
                }

                var userCreated = await _userService.Create(register);

                var defaultRole = await _roleService.GetRoleByName("User");

                await _userService.UpdateUserRolesById(userCreated.UserId, new List<Role> { defaultRole });

                return Created("RegisterUser", userCreated);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
         
        [HttpPut("roles/user/{id}")]    //  para cambiar los roles de un usuario
        //[Authorize(Roles = ROLES.ADMIN)]    //requiere que el usuario esté autenticado y tenga el rol "ADMIN"
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<User>> Put(int id, [FromBody] UpdateUserRolesDto updateUserRolesDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var roles = await _roleService.GetRolesByIds(updateUserRolesDto.RoleIds);
                var userUpdated = await _userService.UpdateUserRolesById(id, roles);
                return Ok(userUpdated);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
