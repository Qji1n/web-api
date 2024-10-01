using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApi.MinimalApi.Domain;
using WebApi.MinimalApi.Models;

namespace WebApi.MinimalApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController : Controller
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    // Чтобы ASP.NET положил что-то в userRepository требуется конфигурация
    public UsersController(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    [HttpGet("{userId}")]
    [Produces("application/json", "application/xml")]
    public ActionResult<UserDto> GetUserById([FromRoute] Guid userId)
    {
        var user = _userRepository.FindById(userId);

        if (user == null)
        {
            return NotFound();
        }
        var userDto = _mapper.Map<UserDto>(user);
        //{ 
        //    //Id = user.Id,
        //    //Login = user.Login,
        //    //FullName = $"{user.LastName} {user.FirstName}",
        //    //GamesPlayed = user.GamesPlayed,
        //    //CurrentGameId = user.CurrentGameId
        //};
        return Ok(userDto);
        throw new NotImplementedException();
    }

    [HttpPost]
    public IActionResult CreateUser([FromBody] object user)
    {
        throw new NotImplementedException();
    }
}