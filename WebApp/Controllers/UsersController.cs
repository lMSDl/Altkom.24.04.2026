using Microsoft.AspNetCore.Mvc;
using Models;
using WebApp.Services;

namespace WebApp.Controllers;

[ApiController]
[Route("[controller]")]
public class UsersController(IUserService userService) : ControllerBase
{
    [HttpGet]
    public IActionResult GetAll() => Ok(userService.GetAll());

    [HttpGet("{id:int}")]
    public IActionResult GetById(int id)
    {
        var user = userService.GetById(id);
        return user is null ? NotFound() : Ok(user);
    }

    [HttpPost]
    public IActionResult Create([FromBody] UserDto request)
    {
        var user = userService.Create(request);
        return Created($"/users/{user.Id}", user);
    }

    [HttpPut("{id:int}")]
    public IActionResult Update(int id, [FromBody] UserDto request)
    {
        var user = userService.Update(id, request);
        return user is null ? NotFound() : Ok(user);
    }

    [HttpDelete("{id:int}")]
    public IActionResult Delete(int id)
    {
        var deleted = userService.Delete(id);
        return deleted ? NoContent() : NotFound();
    }
}
