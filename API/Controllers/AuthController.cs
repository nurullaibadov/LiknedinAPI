using Core.DTOs;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
namespace API.Controllers{
[Route("api/[controller]")][ApiController]
public class AuthController:ControllerBase{
private readonly IAuthService _authService;
public AuthController(IAuthService a)=>_authService=a;
[HttpPost("register")]
public async Task Register([FromBody]RegisterDto dto){
var user=new AppUser{FirstName=dto.FirstName,LastName=dto.LastName,Email=dto.Email,UserName=dto.Email};
var res=await _authService.RegisterAsync(user,dto.Password);
return Ok(new{message=res});}
[HttpPost("login")]
public async Task Login([FromBody]LoginDto dto){
var token=await _authService.LoginAsync(dto.Email,dto.Password);
if(token.Contains("Hatali")||token.Contains("Bulunamadi"))return Unauthorized(new{message=token});
return Ok(new{token=token});}
}
}