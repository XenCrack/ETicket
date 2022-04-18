using ETicket.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ETicket.Data
{
    public class ApplicationDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();
                context.Database.EnsureCreated();

                if (!context.Cinemas.Any())
                {
                    var cinemaList = new List<Cinema>() {
                        new Cinema() {
                            Name = "A Sineması",
                            Description = "a sineması hakkında",
                            Logo = "https://www.pazarlamasyon.com/wp-content/uploads/2019/03/Netflix-Sinema-Salonu.jpg"
                        },
                        new Cinema() {
                            Name = "B Sineması",
                            Description = "b sineması hakkında",
                            Logo = "https://www.pazarlamasyon.com/wp-content/uploads/2019/03/Netflix-Sinema-Salonu.jpg"
                        },
                        new Cinema() {
                            Name = "C Sineması",
                            Description = "c sineması hakkında",
                            Logo = "https://www.pazarlamasyon.com/wp-content/uploads/2019/03/Netflix-Sinema-Salonu.jpg"
                        },
                        new Cinema() {
                            Name = "D Sineması",
                            Description = "d sineması hakkında",
                            Logo = "https://www.pazarlamasyon.com/wp-content/uploads/2019/03/Netflix-Sinema-Salonu.jpg"
                        }
                    };

                    context.Cinemas.AddRange(cinemaList);

                    context.SaveChanges();
                }

                if (!context.Producters.Any())
                {
                    var prodcuterList = new List<Producter>()
                    {

                        new Producter() {
                            FullName = "yapımcı 1",
                            Bio = "yapımcı 1 biyografi"
                        },
                        new Producter() {
                            FullName = "yapımcı 2",
                            Bio = "yapımcı 2 biyografi"
                        },
                        new Producter() {
                            FullName = "yapımcı 3",
                            Bio = "yapımcı 3 biyografi"
                        },

                    };

                    context.Producters.AddRange(prodcuterList);

                    context.SaveChanges();
                }

                if (!context.MovieTypes.Any())
                {
                    var movieTypes = new List<MovieType>()
                    {
                        new MovieType
                        {
                            Name = "Aksiyon"
                        },
                        new MovieType
                        {
                            Name = "Drama"
                        },
                        new MovieType
                        {
                            Name = "Animasyon"
                        },
                    };

                    context.MovieTypes.AddRange(movieTypes);
                    context.SaveChanges();
                }

                if (!context.Movies.Any())
                {
                    List<Movie> movieList = new()
                    {
                        new Movie()
                        {
                            Name = "film 1",
                            Description = "açıklama 1",
                            Price = 39.90,
                            StartDate = System.DateTime.Now.AddDays(-20),
                            EndDate = System.DateTime.Now.AddDays(20),
                            CinemaId = 1,
                            ProducterId = 1,
                            MovieTypeId = 1,
                            ImageUrl = "https://muhendisbilir.com/wp-content/uploads/2017/07/1024774_oad41-1.jpg"
                        },
                        new Movie()
                        {
                            Name = "film 2",
                            Description = "açıklama 2",
                            Price = 29.90,
                            StartDate = System.DateTime.Now.AddDays(-20),
                            EndDate = System.DateTime.Now.AddDays(20),
                            CinemaId = 2,
                            ProducterId = 2,
                            MovieTypeId = 2,
                            ImageUrl = "https://muhendisbilir.com/wp-content/uploads/2017/07/1024774_oad41-1.jpg"
                        },
                        new Movie()
                        {
                            Name = "film 3",
                            Description = "açıklama 3",
                            Price = 59.90,
                            StartDate = System.DateTime.Now.AddDays(-20),
                            EndDate = System.DateTime.Now.AddDays(20),
                            CinemaId = 3,
                            ProducterId = 3,
                            MovieTypeId = 3,
                            ImageUrl = "https://muhendisbilir.com/wp-content/uploads/2017/07/1024774_oad41-1.jpg"
                        },
                    };

                    context.Movies.AddRange(movieList);
                    context.SaveChanges();
                }
            }
        }

        public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                //Roles
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                if (!await roleManager.RoleExistsAsync("Admin"))
                    await roleManager.CreateAsync(new IdentityRole("Admin"));

                if (!await roleManager.RoleExistsAsync("User"))
                    await roleManager.CreateAsync(new IdentityRole("User"));

                //Users
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                
                var adminUserEmail = "admin@eticket.com";
                var adminUser = await userManager.FindByEmailAsync(adminUserEmail);

                if (adminUser == null)
                {
                    var newAdminUser = new ApplicationUser
                    {
                        Name = "admin",
                        Surname = "admin",
                        Email = adminUserEmail,
                        EmailConfirmed = true,
                        BirthDate = Convert.ToDateTime("01.01.2000"),
                        PhoneNumberConfirmed = true,
                        TwoFactorEnabled = false,
                        LockoutEnabled = false,
                        UserName = "admin",
                        Discriminator = string.Empty
                    };

                    var result = await userManager.CreateAsync(newAdminUser, "123QWEasdz.");
                    await userManager.AddToRoleAsync(newAdminUser, "admin");
                }


                var userEmail = "user@eticket.com";
                var user = await userManager.FindByEmailAsync(userEmail);

                if (user == null)
                {
                    var newUser = new ApplicationUser
                    {
                        Name = "user",
                        Surname = "user",
                        Email = userEmail,
                        EmailConfirmed = true,
                        BirthDate = Convert.ToDateTime("01.01.2000"),
                        PhoneNumberConfirmed = true,
                        TwoFactorEnabled = false,
                        LockoutEnabled = false,
                        UserName = "user",
                        Discriminator = string.Empty
                    };

                    await userManager.CreateAsync(newUser, "123QWEasdz.");
                    await userManager.AddToRoleAsync(newUser, "user");
                }

            }
        }
    }
}
