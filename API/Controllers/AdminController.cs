using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace API.Controllers{
[Route("api/[controller]")][ApiController][Authorize]
public class AdminController:ControllerBase{
[HttpGet("users")]
public IActionResult Get()=>Ok(new{message="Admin Panel"});
}
}