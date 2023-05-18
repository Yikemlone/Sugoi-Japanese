using Duende.IdentityServer.EntityFramework.Options;
using FlashCardBlazorApp.Models.Models;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Reflection.Metadata;
using System.Text.RegularExpressions;

namespace FlashCardBlazorApp.DataAccess.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<UserOptions> UserOptions { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Vocab> Vocabs { get; set; }
        public DbSet<VocabProgress> VocabProgresses { get; set; }


        public ApplicationDbContext(DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            List<Vocab> vocabs = new List<Vocab>();
            List<Role> roles = new List<Role>();

            var dir = new DirectoryInfo(Environment.CurrentDirectory).Parent.FullName;
            var csvLines = System.IO.File.ReadAllLines(dir + @"\Shared\japanese.csv");
            string pattern = @",(?=(?:[^']*'[^']*')*(?![^']*'))"; // ignores commas inside single quotes

            for (int i = 1; i < csvLines.Length; i++)
            {
                string[] wordDetails = Regex.Split(csvLines[i], pattern);

                var vocab = new Vocab {
                    ID = i+1,

                    JLPT = wordDetails[0],

                    VocabExpression = wordDetails[1],
                    VocabKana = wordDetails[2],
                    VocabMeaning = wordDetails[3],
                    VocabSounds = wordDetails[4],
                    VocabPos = wordDetails[5],

                    SentenceExpression = wordDetails[6],
                    SentenceKana = wordDetails[7],
                    SentenceMeaning = wordDetails[8],
                    SentenceSound = wordDetails[9],

                    VocabFurigana = wordDetails[10],
                    SentenceFurigana = wordDetails[11]
                };

                vocabs.Add(vocab);
            }

            modelBuilder.Entity<Vocab>().HasData(vocabs);
        }

    }
}