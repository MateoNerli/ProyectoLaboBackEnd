using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProyectoLaboBackEnd.Services;
using ProyectoLaboBackEnd.Models.Comment.Dto;
using ProyectoLaboBackEnd.Enums;

namespace ProyectoLaboBackEnd.Controllers
{
    [Route("api/comment")]
    [Authorize]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly CommentService _commentService;
        private readonly UserService _userService;

        public CommentController(CommentService commentService, UserService userService)
        {
            _commentService = commentService;
            _userService = userService;
        }

        [HttpGet]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<CommentsDto>>> Get()
        {
            return Ok(await _commentService.GetAll());
        }

        [HttpGet("{id:int}/comments")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<List<CommentDto>>>GetCommentsForPost(int id)
        {
            try
            {
                var comments = await _commentService.GetCommentsForPost(id);

                if (comments == null || comments.Count == 0)
                {
                    return NotFound(new { message = $"No comments for post with Id = {id}" });
                }

                return Ok(comments);
            }
            catch
            {
                return NotFound(new { message = $"No post with Id = {id}" });
            }
        }


        [HttpGet("{id:int}")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<CommentDto>> Get(int id)
        {
            try
            {
                return Ok(await _commentService.GetById(id));
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
        public async Task<ActionResult<CommentDto>> Post([FromBody] CreateCommentsDto createPostDto)
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
            var postCreated = await _commentService.Create(createPostDto);
            return Created("CreatePost", postCreated);
        }

        [HttpPut("{id:int}")]
        //[Authorize(Roles = $"{ROLES.ADMIN}, {ROLES.MOD}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<CommentDto>> Put(int id, [FromBody] UpdateCommentsDto updatePostDto)
        {
            try
            {
                var postUpdated = await _commentService.UpdateById(id, updatePostDto);
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
                await _commentService.DeleteById(id);
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