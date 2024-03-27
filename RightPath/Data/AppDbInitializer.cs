using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.UI.Services;
using RightPath.Models;
using RightPath.Repository;
using System.ComponentModel.DataAnnotations;

namespace RightPath.Data
{
    public class AppDbinitializer
    {
        public static async Task SeedAsync(IApplicationBuilder applicationBuilder)
        {

            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {

                var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();

                context.Database.EnsureCreated();

                if (!context.Lectures.Any())
                {

                    context.Lectures.AddRange(new List<Lecture>()
                    {
                       new Lecture()
                        {
                            Name = "Юли Тонкин",
                            Description = "Юли е предприемач, инвеститор, катализатор за промяна, стратег и автор.\r\n\r\nСъздател е на единствената по рода си Менторска Академия в България, която обхваща всички сфери на живота и всяка година служи на стотици българи да постигат и живеят целите си в личен и финансов план!",
                            ProfileImage = "yuli-tonkin.jpg"
                        },
                        new Lecture()
                        {
                            Name = "Боян Москов",
                            Description = "Боян Москов е собственик на дигитална агенция InteractiveOrb, софтуер за създаване на продажбени фунии - ConvertBuilder, академия за онлайн маркетинг - Masterclass.bg и 2 собствени онлайн магазина.\r\n\r\nСъс своята агенция за дигитален маркетинг с екип от 10 човека работят с десетки онлайн бизнеси в България и чужбина, някои от които са едни от най-големите брандове - Зора, Спорт Депо, Фитнеси Пулс, Адрес и Имотека - недвижими имоти и други. Рекламният бюджет, който управляват, е над 1 000 000 лв.",
                            ProfileImage = "boyan-moskov.jpg"

                        },
                        new Lecture()
                        {
                            Name = "Проф. Красимир Петров",
                            Description = "Проф. Красимир Петров има магистърска степен от Университета в Делауеър и докторска степен от Държавния икономически университет в Охайо (1999). През 2000-2004 г. е работил в Sterling Commerce, дъщерно дружество на SBC Communications. Започва да преподава през 2005 г. като редовен асистент в Американския университет в България, като преподава макроикономика, пари и банкиране, международни финанси със специализирани курсове по управление на риска, макроикономическо инвестиране и алтернативни подходи за инвестиране като цикличен анализ на инвестициите, технически анализ и поведенчески анализ.",
                            ProfileImage = "prof-krasimir-petrov.jpg"
                        },
                        new Lecture()
                        {
                            Name = "Светлин Наков",
                            Description = "Светлин Наков има 20+ години технически опит като софтуерен инженер, ръководител на проекти, консултант, обучител и дигитален предприемач с богат технически опит (Уеб разработка, информационни системи, бази данни, софтуерно инженерство, криптография, блокчейн, C#, Java, JS, PHP , Python). Светлин Наков е редовен лектор на стотици конференции, семинари, курсове и други обучения и има докторска степен по компютърни науки. Автор е на 15 книги за компютърно програмиране и софтуерни технологии, живее в София, България и е създател, обучител и вдъхновител в СофтУни.",
                            ProfileImage = "svetlin-nakov.jpg"
                        },
                        new Lecture()
                        {
                            Name = "Давид Бонев",
                            Description = "Давид Бонев е Главен финансов директор на международния проект за здравеопазване, базиран на блокчейн технологията – CURES Token, както и един от създателите на единствения по рода си за българския пазар крипто ексчейндж – BoneX. Основните му интереси са свързани с глобализацията, интернационализацията и децентрализацията.",
                            ProfileImage = "david-bonev.jpg"
                        }
                    }) ;

                    context.SaveChanges();
                }

                if (!context.Courses.Any())
                {

                    context.Courses.AddRange(new List<Course>()
                    {
                            new Course()
                            {
                                Title = "Курс за Full Stack Developer",
                                Description = "Ще научите как да станете Full Stack Developer от основите!",
                                Duration = 12.30,
                                Logo = "full-stack.png",
                                LectureId = 4
                            },
                            new Course()
                            {
                                Title = "Курс за Основи на Блокчейн Технологиите",
                                Description = "Този курс ще обхване основите на блокчейн технологиите и техните приложения.",
                                Duration = 10.00,
                                Logo = "blockchain.jpg",
                             LectureId = 3
                            },
                            new Course()
                            {
                                Title = "Курс за Стратегии и Дигитален Маркетинг",
                                Description = "Научете ефективни стратегии за дигитален маркетинг, за да развиете онлайн присъствие и достиг.",
                                Duration = 8.00,
                                Logo = "digital-marketing.jpg",
                                LectureId = 2
                            },
                            new Course()
                            {
                                Title = "Курс за Криптовалути и Децентрализирана Финансова Система",
                                Description = "Изследвайте света на криптовалутите и децентрализираната финансова система с индустриални експерти.",
                                Duration = 14.00,
                                Logo = "cripto.jpg",
                                LectureId = 5
                            },
                            new Course()
                            {
                                Title = "Менторски Курс за Личностно Развитие",
                                Description = "Открийте потенциала си и постигнете целите си в живота и финансово планиране с помощта на Менторската Академия на Юли Тонкин.",
                                Duration = 9.00,
                                Logo = "personal-develop.jpg",
                                LectureId = 1
                            }
                    });

                    context.SaveChanges();
                }

                if (!context.Cities.Any())
                {

                    context.Cities.AddRange(new List<City>()
                    {
                       new City()
                       {
                          Name = "София",
                          DisplayOrder = 1
                       },
                       new City()
                       {
                          Name = "Пловдив",
                          DisplayOrder = 2
                       },
                       new City()
                       {
                          Name = "Варна",
                          DisplayOrder = 3
                       },
                       new City()
                       {
                          Name = "Бургас",
                          DisplayOrder = 4
                       },
                       new City()
                       {
                          Name = "Русе",
                          DisplayOrder = 5
                       },
                    });

                    context.SaveChanges();
                }

                if (!context.Webminars.Any())
                {
                    context.Webminars.AddRange(new List<Webminar>()
                    {
                        new Webminar()
                        {
                            Title = "Уебминар: Въведение в Блокчейн Технологиите",
                            Description = "Този уебминар ще ви запознае с основите на блокчейн технологиите.",
                            StartDate = new DateTime(2024, 11, 15),
                            CityId = 1,
                            Logo = "blck-chain.jpg",
                            LectureId = 3 
                        },
                        new Webminar()
                        {
                            Title = "Уебминар: Ефективни Дигитални Маркетинг Стратегии",
                            Description = "Научете се как да разработите и приложите ефективни стратегии за дигитален маркетинг.",
                            StartDate = new DateTime(2022, 10, 20),
                            CityId = 1,
                            Logo = "marketing.jpg", 
                            LectureId = 2 
                        },
                        new Webminar()
                        {
                            Title = "Уебминар: Бъдещето на Финансовите Технологии",
                            Description = "Изследвайте перспективите и възможностите пред финансовите технологии с водещи експерти.",
                            StartDate = new DateTime(2023, 9, 18),
                            CityId = 1,
                            Logo = "finance.jpg", 
                            LectureId = 5 
                        },
                        new Webminar()
                        {
                            Title = "Уебминар: Изграждане на Личен и Финансов успех",
                            Description = "Открийте ключовите стратегии и практики за постигане на личен и финансов успех с Юли Тонкин.",
                            StartDate = new DateTime(2024, 8, 25),
                            CityId = 1,
                            Logo = "self-confidence.jpg", 
                            LectureId = 1 
                        },
                        new Webminar()
                        {
                            Title = "Уебминар: Бъдещето на Изкуствената Интелигентност",
                            Description = "Присъединете се към уебминара, където ще разгледаме перспективите и предизвикателствата пред бъдещето на изкуствената интелигентност.",
                            StartDate = new DateTime(2024, 04, 10),
                            CityId = 1,
                            Logo = "ai.jpg", 
                            LectureId = 4
                        }
                    });

                    context.SaveChanges();
                }
            }

            using (var scope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                var roles = new[] { StaticDetail.Role_Customer, StaticDetail.Role_Admin, StaticDetail.Role_Lecture };

                foreach (var role in roles)
                {
                    if (!await roleManager.RoleExistsAsync(role))
                    {
                        await roleManager.CreateAsync(new IdentityRole(role));
                    }
                }


                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();

                string userEmail = "user@gmail.com";
                string userPassword = "123456";
                string userEGN = "7589346578";
                string userPhoneNum = "0889723131";
                string userFirstName = "User";
                string userLastName = "UserLastName";

                if (await userManager.FindByEmailAsync(userEmail) == null)
                {
                    var user = new ApplicationUser
                    {
                        FirstName = userFirstName,
                        LastName = userLastName,
                        UserName = userEmail,
                        Email = userEmail,
                        EGN = userEGN,
                        PhoneNumber = userPhoneNum,
                    };

                    var result = await userManager.CreateAsync(user, userPassword);

                    if (result.Succeeded)
                    {
                        await userManager.AddToRoleAsync(user, StaticDetail.Role_Customer);
                    }
                }

                string adminEmail = "admin@gmail.com";
                string adminPassword = "123456";
                string adminEGN = "081295412";
                string adminPhoneNum = "08820784322";
                string adminFirstName = "Admin";
                string adminLastName = "AdminLastName";

                if (await userManager.FindByEmailAsync(adminEmail) == null)
                {
                    var admin = new ApplicationUser
                    {
                        FirstName = adminFirstName,
                        LastName = adminLastName,
                        UserName = adminEmail,
                        Email = adminEmail,
                        EGN = adminEGN,
                        PhoneNumber = adminPhoneNum,
                    };

                    var result = await userManager.CreateAsync(admin, adminPassword);

                    if (result.Succeeded)
                    {
                        await userManager.AddToRoleAsync(admin, StaticDetail.Role_Admin);
                    }
                }

            }
        }
    }

} 
        
