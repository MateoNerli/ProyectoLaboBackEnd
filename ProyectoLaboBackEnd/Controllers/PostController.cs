using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProyectoLaboBackEnd.Enums;
using ProyectoLaboBackEnd.Models.Post;
using ProyectoLaboBackEnd.Models.Post.Dto;
using ProyectoLaboBackEnd.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProyectoLaboBackEnd.Controllers
{
    [Route("api/posts")]
    [Authorize]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly PostService _postService;
        private readonly UserService _userService;
        public PostController(PostService postService, UserService userService)
        {
            _postService = postService;
            _userService = userService;
        }

        [HttpGet]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<PostsDto>>> Get()
        {
            return Ok(await _postService.GetAll());
        }

        [HttpGet("{id:int}")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<PostDto>> Get(int id)
        {
            try
            {
                return Ok(await _postService.GetById(id));
            }
            catch
            {
                return NotFound(new { message = $"No post with Id = {id}" });
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<PostDto>> Post([FromBody] CreatePostDto createPostDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                await _userService.GetById(createPostDto.UserId);
            }
            catch
            {
                ModelState.AddModelError("UserId", "User does not exist");
                return BadRequest(ModelState);
            }

            var postToCreate = MapCreatePostDtoToPost(createPostDto); 
            var postCreated = await _postService.Create(postToCreate);

            return Created("CreatePost", postCreated);
        }

        private Post MapCreatePostDtoToPost(CreatePostDto createPostDto)
        {
            throw new NotImplementedException();
        }

        [HttpPut("{id:int}")]
        [Authorize(Roles = $"{ROLES.ADMIN}, {ROLES.MOD}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<PostDto>> Put(int id, [FromBody] Post updatePostDto)
        {
            try
            {
                var postUpdated = await _postService.UpdateById(id, updatePostDto);
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
                await _postService.DeleteById(id);
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
