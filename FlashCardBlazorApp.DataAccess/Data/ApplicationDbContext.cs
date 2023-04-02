using Duende.IdentityServer.EntityFramework.Options;
using FlashCardBlazorApp.Models.Models;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace FlashCardBlazorApp.DataAccess.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<UserOptions> UserOptions { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Vocab> Vocabs { get; set; }
        public DbSet<VocabProgress> VocabProgresses { get; set; }
    }
}