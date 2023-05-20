using FlashCardBlazorApp.Models.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.Text.RegularExpressions;

namespace FlashCardBlazorApp.DataAccess.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
    {
        public DbSet<UserFlashCardOptions> UserFlashCardOptions { get; set; }
        public DbSet<Vocab> Vocabs { get; set; }
        public DbSet<VocabProgress> VocabProgresses { get; set; }


        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override async void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            List<Vocab> vocabs = new List<Vocab>();

            //modelBuilder.Entity<VocabProgress>()
            //    .HasOne(vp => vp.ApplicationUser)
            //    .WithMany(au => au.VocabProgresses)
            //    .HasForeignKey(vp => vp.ApplicationUserId);

            //modelBuilder.Entity<UserFlashCardOptions>()
            //    .HasOne(uo => uo.ApplicationUser)
            //    .WithOne(au => au.UserFlashCardOptions)
            //    .HasForeignKey<UserFlashCardOptions>(uo => uo.ApplicationUserId);

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

            modelBuilder.Entity<ApplicationUser>().Navigation(e => e.VocabProgresses).AutoInclude();
        }
    }
}