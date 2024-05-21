using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;


namespace api.Data
{
    public class DBSeeds
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<ApplicationDBContext>();
                context.Database.EnsureCreated();
                //Ciema
                if (!context.Users.Any())
                {
                    context.Users.AddRange(new List<User>
                    {
                        new User()
                        {
                            UserName = "Dummy Name",
                            Email = "abc@aol.com",
                            PhoneNumber = "+201123195384"
                        },
                        new User
                        {
                            UserName = "Mo'men Maged",
                            Email = "momen@gmail.com",
                            PhoneNumber = "+201123195384"
                        }
                       
                    });
                    context.SaveChanges();  
                }
                // Actor
                // if (!context.Actors.Any())
                // {
                //     context.Actors.AddRange(new List<Actor>()
                //     {
                //         new Actor()
                //         {
                //             FullName = "Actor 1",
                //             Bio = "This is the Bio of the first actor",
                //             ProfilePictureURL = "http://dotnethow.net/images/actors/actor-1.jpeg"
                //         }
                //     });
                //         context.SaveChanges();
                // };
                    context.SaveChanges();
                }    
            }
        }
    }