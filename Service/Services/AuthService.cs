using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
namespace Service.Services{
public class AuthService:IAuthService{
private readonly UserManager _userManager;
private readonly RoleManager> _roleManager;
private readonly IConfiguration _config;
public AuthService(UserManager um,RoleManager> rm,IConfiguration cfg){_userManager=um;_roleManager=rm;_config=cfg;}
public async Task RegisterAsync(AppUser user,string password){
var r=await _userManager.CreateAsync(user,password);
if(!r.Succeeded)throw new Exception(string.Join(", ",r.Errors.Select(e=>e.Description)));
if(!await _roleManager.RoleExistsAsync("User"))await _roleManager.CreateAsync(new IdentityRole("User"));
await _userManager.AddToRoleAsync(user,"User");
return "Kayit Basarili";}
public async Task LoginAsync(string email,string password){
var user=await _userManager.FindByEmailAsync(email);
if(user==null)return "Bulunamadi";
if(!await _userManager.CheckPasswordAsync(user,password))return "Hatali";
return GenerateToken(user);}
private string GenerateToken(AppUser user){
var key=new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
var creds=new SigningCredentials(key,SecurityAlgorithms.HmacSha256);
var claims=new[]{new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),new Claim(ClaimTypes.Email,user.Email)};
var token=new JwtSecurityToken(issuer:_config["Jwt:Issuer"],audience:_config["Jwt:Audience"],claims:claims,expires:DateTime.Now.AddHours(3),signingCredentials:creds);
return new JwtSecurityTokenHandler().WriteToken(token);}
}
}