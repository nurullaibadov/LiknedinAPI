using Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
namespace Infrastructure.Data{
public class AppDbContext:IdentityDbContext,int>{
public AppDbContext(DbContextOptions options):base(options){}
public DbSet Posts{get;set;}
protected override void OnModelCreating(ModelBuilder builder){
base.OnModelCreating(builder);
builder.Entity().HasOne(p=>p.AppUser).WithMany(u=>u.Posts).HasForeignKey(p=>p.AppUserId).OnDelete(DeleteBehavior.Cascade);
}
}
}