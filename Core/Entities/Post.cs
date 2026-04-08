namespace Core.Entities{
public class Post{
public int Id{get;set;}
public string Content{get;set;}
public DateTime CreatedAt{get;set;}=DateTime.UtcNow;
public int AppUserId{get;set;}
public AppUser AppUser{get;set;}
}
}