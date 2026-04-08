using FluentValidation;
namespace Core.DTOs{
public class RegisterDto{
public string FirstName{get;set;}
public string LastName{get;set;}
public string Email{get;set;}
public string Password{get;set;}
}
public class RegisterDtoValidator:AbstractValidator{
public RegisterDtoValidator(){
RuleFor(x=>x.Email).EmailAddress().NotEmpty();
RuleFor(x=>x.Password).MinimumLength(6).NotEmpty();
}
}
}