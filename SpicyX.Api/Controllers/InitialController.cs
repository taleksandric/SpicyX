using Microsoft.AspNetCore.Mvc;
using SpicyX.DataAccess;
using SpicyX.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SpicyX.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InitialController : ControllerBase
    {
        private readonly SpicyXContext _context;

        public InitialController(SpicyXContext context)
        {
            _context = context;
        }
        

        // POST api/<InitialController>
        [HttpPost]
        public void Post()
        {
            var types = new List<Domain.Entities.Type>
            {
                new Domain.Entities.Type
                {
                    Name="Pizza"
                },
                new Domain.Entities.Type
                {
                    Name="Pasta"
                },
                new Domain.Entities.Type
                {
                    Name="Salad"
                }
            };
            var meals = new List<Meal>
            {
                new Meal
                {
                    Name="Porketa",
                    Description="Spicy pork noodles, tomato, purple onion, primrose and oriental dressing",
                    Price=8,
                    Type = types.ElementAt(0)

                },
                new Meal
                {
                    Name="Toscana",
                    Description="Cheese, prosciutto, rocket, parmesan",
                    Price=9,
                    Type = types.ElementAt(0)

                },
                new Meal
                {
                    Name="Bresaola",
                    Description="Cheese, cheddar cheese, smoked cheese, bresaola, caramelized onion, baby salad, cream cheese with lemon and almond flakes",
                    Price=7,
                    Type = types.ElementAt(0)

                },
                new Meal
                {
                    Name="Carbonara",
                    Description="Gvancialle bacon, spring onions, garlic, egg yolks, neutral sour cream, parmesan",
                    Price=5,
                    Type = types.ElementAt(1)

                },
                new Meal
                {
                    Name="Pasta Arabiata",
                    Description="Tomato, garlic and basil sauce, slightly spiced, parmesan",
                    Price=6,
                    Type = types.ElementAt(1)

                },
                new Meal
                {
                    Name="Pasta with prawns",
                    Description="Garlic, white wine, tomato sauce, spinach",
                    Price=11,
                    Type = types.ElementAt(1)

                },
                new Meal
                {
                    Name="Caesar salad",
                    Description="Pancetta, capers, chicken, parmesan, iceberg, cherry tomato",
                    Price=7,
                    Type = types.ElementAt(2)

                },
                new Meal
                {
                    Name="Beefsteak salad",
                    Description="Leafy baby vegetables, cherry, grilled zucchini, vegetable and mushroom chips, tapioca and parmesan pastry, honey and thyme topping",
                    Price=13,
                   Type = types.ElementAt(2)

                },
                new Meal
                {
                    Name="Chicken salad",
                    Description="Leafy baby vegetables, cherry, grilled zucchini, vegetable and mushroom chips, tapioca and parmesan pastry, honey and thyme topping and chicken",
                    Price=15,
                    Type = types.ElementAt(2)

                },

            };
            var roles = new List<Role>
            {
                new Role
                {
                    Name = "Admin"
                },
                new Role
                {
                    Name = "User"
                }
            };
            var users = new List<User>
            {
                new User
                {
                    FirstName = "Korisnik",
                    LastName = "Korisnikovic",
                    Email = "korisnik@gmail.com",
                    Password = "korisnik",
                    Address = "Korisnikova Adresa 1",
                    Role = roles.Last(),
                    
                },
                new User
                {
                    FirstName = "Admin",
                    LastName = "Adminic",
                    Email = "admin@gmail.com",
                    Password = "admin",
                    Address = "Adminova adresa 2",
                    Role = roles.First(),
                    
                }
            };
            _context.Types.AddRange(types);
            _context.Meals.AddRange(meals);
            _context.Roles.AddRange(roles);
            _context.Users.AddRange(users);

            _context.SaveChanges();
        }

        
    }
}
