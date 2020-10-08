using F4TestProject.Domain.Models;
using F4TestProject.Domain.Services;
using F4TestProject.Domain.Services.Users;
using F4TestProject.Domain.Services.Users.ServiceModels;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace F4TestProject.API.Seeding
{
    public class DbInitializer
    {
        private readonly IServiceScopeFactory _scopeFactory;

        public DbInitializer(IServiceScopeFactory scopeFactory)
        {
            _scopeFactory = scopeFactory;
        }



        public void SeedData()
        {
            using (var serviceScope = _scopeFactory.CreateScope())
            {
                var us = serviceScope.ServiceProvider.GetService<IUsersService>();

                us.Register(new UserRegisterRequest()
                {
                    Email = "admin@admin.com",
                    FirstName = "admin",
                    LastName = "admin",
                    Password = "admin2020"
                }, Roles.Admin).Wait();
            }
            using (var serviceScope = _scopeFactory.CreateScope())
            {
                var us = serviceScope.ServiceProvider.GetService<IActionItemsService>();

                us.Create(new ActionItem()
                {
                    Title = "Joseph and the Amazing Technicolor Dreamcoat",
                    Description = "Welcome to Hill Valley as the 1985 movie phenomenon is finally transported to the stage by...",
                    Duration = TimeSpan.FromMinutes(125),
                    CountOfSeats = 300,
                    Price = 100,
                    StartTime = new DateTime(2020, 3, 11),
                    ImageLink = @"https://www.londontheatre.co.uk/sites/default/files/styles/image_list/public/api/7899-1599566792-bttfsq080920.jpg?itok=-AuMr94J"

                })
                 .Wait();

                us.Create(new ActionItem()
                {
                    Title = "Back to the Future: The Musical",
                    Description = $@"Joseph and the Amazing Technicolor Dreamcoat is now postponed at the London Palladium to 2021.
                        Released as a concept album in 1969,
                        Joseph and the Amazing Technicolor Dreamcoat has become one of the worlds
                        most iconic musicals,
                        featuring songs that have gone on to become pop and musical theatre standards....",
                    Duration = TimeSpan.FromMinutes(110),
                    CountOfSeats = 280,
                    Price = 95,
                    StartTime = new DateTime(2020, 3, 11, 8, 30, 0),
                    ImageLink = "https://www.londontheatre.co.uk/sites/default/files/styles/image_list/public/api/2048-1569492779-josephsq260919.jpg?itok=hPihxBqY"

                })
                    .Wait();

                us.Create(new ActionItem()
                {
                    Title = "SIX Live at the Lyric",
                    Description = @"DIVORCED, BEHEADED and now LIVE AT THE LYRIC!
                        SIX, ‘the most uplifting piece of new British musical theatre,’ (Evening Standard) is holding court at London’s Lyric Theatre for a strictly
                        limited season.Prepare to Lose Ur Head. ",
                    Duration = TimeSpan.FromMinutes(90),
                    CountOfSeats = 300,
                    Price = 110,
                    StartTime = new DateTime(2020, 5, 3),
                    ImageLink = @"https://www.londontheatre.co.uk/sites/default/files/styles/image_list/public/api/7908-1600269168-sixl20002encore300x300pxls.jpg?itok=NDZenGl7"

                })
                    .Wait();

                us.Create(new ActionItem()
                {
                    Title = "Harry Potter and the Cursed Child",
                    Description = @"Based on an original new story by J.K. Rowling, Jack Thorne and John Tiffany, Harry Potter and the Cursed Child is
                        a new play by Jack Thorne.It is the eighth story in the Harry Potter series and the first official Harry Potter story to be presented on stage.",
                    Duration = TimeSpan.FromMinutes(125),
                    CountOfSeats = 300,
                    Price = 100,
                    StartTime = new DateTime(2020, 3, 11),
                    ImageLink = @"https://www.londontheatre.co.uk/sites/default/files/styles/image_list/public/api/7698-1578475917-hp19q3655encorebuttons500x500.jpg?itok=v2o72QCb"
                })
                    .Wait();
            }

        }
    }
}
