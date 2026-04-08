namespace Core.Interfaces{
public interface IAuthService{
Task RegisterAsync(Core.Entities.AppUser user,string password);
Task LoginAsync(string email,string password);
}
}