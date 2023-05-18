using FlashCardBlazorApp.DataAccess.Data;
using FlashCardBlazorApp.DataAccess.Services.UnitOfWorkService;
using FlashCardBlazorApp.Models.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using System.Text.RegularExpressions;

namespace FlashCardBlazorApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllersWithViews();
            builder.Services.AddRazorPages();

            // Add services to the container.
            var connectionString = builder.Configuration.GetConnectionString("LocalConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));

            // Identity Services
            builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            builder.Services.AddIdentityServer()
                .AddApiAuthorization<ApplicationUser, ApplicationDbContext>();

            builder.Services.AddAuthentication()
                .AddIdentityServerJwt();

            var dir = new DirectoryInfo(Environment.CurrentDirectory).Parent.FullName;
            var csvLines = System.IO.File.ReadAllLines(dir + @"\Shared\japanese.csv");
            string pattern = @",(?=(?:[^']*'[^']*')*(?![^']*'))"; // ignores commas inside single quotes and double

            for (int i = 1; i < csvLines.Length; i++)
            {
                string[] wordDetails = Regex.Split(csvLines[i], pattern);

                var vocab = new Vocab
                {
                    ID = i + 1,

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
            }

            // UnitOfWork
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
                app.UseWebAssemblyDebugging();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseBlazorFrameworkFiles();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseIdentityServer();
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapRazorPages();
            app.MapControllers();
            app.MapFallbackToFile("index.html");

            app.Run();
        }
    }
}