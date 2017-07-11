using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication.Models
{
 
    public class CustomIdentityUser : IdentityUser
    {
        public string JobTitle { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime? CreateDate { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime? ModifyDate { get; set; }
        public string ModifyBy { get; set; }
        public string NameIdentifier { get; set; }

       
    }
    public class ApplicationUser : CustomIdentityUser
    {
        public virtual ICollection<Comment> Comments { get; set; }

        public virtual ICollection<MyTask> MyTasks { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);

            userIdentity.AddClaim(new Claim("WebApplication.Models.RegisterViewModel.NameIdentifier", NameIdentifier));
            userIdentity.AddClaim(new Claim("WebApplication.Models.RegisterViewModel.Email", Email));

            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<MyTask> MyTasks { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public ApplicationDbContext()
            : base("TaskManagementDbContext", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}