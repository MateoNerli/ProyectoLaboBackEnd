using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProyectoLaboBackEnd.Services;
using ProyectoLaboBackEnd.Enums;
using ProyectoLaboBackEnd.Models.Community.Dto;
using ProyectoLaboBackEnd.Models.Community;

namespace ProyectoLaboBackEnd.Controllers
{
    [Route("api/community")]
    [Authorize]
    [ApiController]
    public class CommunityController : ControllerBase
    {
        private readonly CommunityService _communityService;
        private readonly UserService _userService;

        public CommunityController(CommunityService communityService, UserService userService)
        {
            _communityService = communityService;
            _userService = userService;
        }

        [HttpGet]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<CommunitysDto>>> Get()
        {
            return Ok(await _communityService.GetAll());
        }


        [HttpGet("{id:int}")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<CommunityDto>> Get(int id)
        {
            try
            {
                return Ok(await _communityService.GetById(id));
            }
            catch
            {
                return NotFound(new { message = $"No community with Id = {id}" });
            }
        }

        [HttpPost]
        [Authorize(Roles = ROLES.ADMIN)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<CommunityDto>> Post([FromBody] CreateCommunityDto createPostDto)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); 
            }

            var newCommunity = new Community
            {
                Name = createPostDto.Name,
                State = createPostDto.State
            };

            var createdCommunity = await _communityService.Create(createPostDto);

            return Created("CreateCommunity", createdCommunity);
        }

        [HttpPut("{id:int}")]
        //[Authorize(Roles = $"{ROLES.ADMIN}, {ROLES.MOD}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<CommunityDto>> Put(int id, [FromBody] UpdateCommunityDto updatePostDto)
        {
            try
            {
                var postUpdated = await _communityService.UpdateById(id, updatePostDto);
                return Ok(postUpdated);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = ROLES.ADMIN)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await _communityService.DeleteById(id);
                // Se puede retornar un No content (204)
                return Ok(new
                {
                    message = $"Post with Id = {id} was deleted"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}