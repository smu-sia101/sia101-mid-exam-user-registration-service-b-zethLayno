using AutoMapper;
using Exam.UserManager.Models;
using Exam.UserManager.Service;
using Microsoft.AspNetCore.Mvc;

namespace Exam.UserManager.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserQueryService _userQueryService;
        private readonly IUserWriteService _userWriteService;
        private readonly IMapper _mapper;

        public UserController(IUserQueryService userQueryService, IUserWriteService userWriteService, IMapper mapper)
        {
            _userQueryService = userQueryService;
            _userWriteService = userWriteService;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            try
            {
                //***
                //TODO: Item 4: Implement the logic to get user by id
                UserDTO user = new UserDTO(); //must invoke userQueryService
                //***
                UserResourceModel mapped = _mapper.Map<UserResourceModel>(user);
                return Ok(mapped);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                IEnumerable<UserDTO> users = _userQueryService.GetAll();
               
                if(users == null || !users.Any())
                {
                    return NotFound();
                }

                IEnumerable<UserResourceModel> mapped = 
                    _mapper.Map<IEnumerable<UserResourceModel>>(users);

                return Ok(mapped);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Add([FromBody] CreateUserModel user)
        {
            try
            {
                //***
                //TODO: Item 5: Implement the logic to add user
                UserDTO mapped = _mapper.Map<UserDTO>(user);
                string userId = "some ID from the userWriteService";
                //***
                return CreatedAtAction(nameof(Get), new { id = userId }, user);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(string id, [FromBody] UserResourceModel user)
        {
            try
            {
                user.Id = id;
                //***
                //TODO Item 6: Implement the logic to update user
                UserDTO mapped = _mapper.Map<UserDTO>(user);
                bool result = false; //result of update from userWriteService
                //***
                if (result)
                {
                    return NoContent();
                }
                return NotFound();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            try
            {
                //***
                //TODO Item 7: Implement the logic to delete user
                var result = _userWriteService.Delete(id);
                //I need to return 200 or 204 if the user is deleted successfully
                //***
                return NotFound();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
