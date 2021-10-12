using Domain.Entites;
using EfDataAccess;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstallationController : ControllerBase
    {
        private readonly ShoeStoreContext _context;

        public InstallationController(ShoeStoreContext context)
        {
            _context = context;
        }

        // POST api/<InstallationController>
        [HttpPost]
        public IActionResult Post()
        {
            var brand = new List<Brand>
            {
                new Brand
                {
                    Name = "Ciciban",
                    Logo = "ciciban.jpg"
                },
                new Brand
                {
                    Name = "Filip"
                    ,
                    Logo = "filip.jpg"
                }
                ,new Brand
                {
                    Name = "Chicco",
                    Logo = "chicco.jpg"
                },
                new Brand
                {
                    Name = "Nike",
                    Logo = "nike.jpg"
                },
                new Brand
                {
                    Name = "Adidas",
                    Logo = "adidas.jpg"
                }
            };
            var seasons = new List<Season>
            {
                new Season
                {
                    Name = "Prolece"
                },
                new Season
                {
                    Name = "Leto"
                },
                new Season
                {
                    Name = "Jesen"
                },
                new Season
                {
                    Name = "Zima"
                }
            };
            var groups = new List<Group> { new Group
                {
                    Name = "Admin"
                },
                new Group
                {
                    Name = "Moderator"
                },
                new Group
                {
                    Name = "Korisnik"
                }
            };
            var genders = new List<Gender>
            {
                new Gender
                {
                    Name = "Dečaci"
                },
                new Gender
                {
                    Name = "Devojčice"
                }
            };
            var categories = new List<Category>
            {
                new Category
                {
                    Name = "Cipele"
                },
                new Category
                {
                    Name = "Patike"
                }
            };
            var colors = new List<Color>
            {
                new Color
                {
                    Name = "Plava"
                },
                new Color
                {
                    Name = "Crvena"
                },
                new Color
                {
                    Name = "Roze"
                },
                new Color
                {
                    Name = "Siva"
                }
            };

            var user = new List<User>
            {
                new User
                {
                    FirstName = "Nikola",
                    LastName = "Jockovic",
                    PhoneNumber = "066333222",
                    Email = "nikola.jockovic.23.18@ict.edu.rs",
                    Password = "5624c771a8e2e0c12fb764264e91b321fafaf81178de928864f843bdf194e155", // sifra1,
                    IsActive = true,
                    IsDeleted = false,
                    DeletedAt = null,
                    ModifiedAt = null
                },
                new User
                {
                    FirstName = "Pera",
                    LastName = "Peric",
                    PhoneNumber = "066222333",
                    Email = "pera.peric@ict.edu.rs",
                    Password = "5624c771a8e2e0c12fb764264e91b321fafaf81178de928864f843bdf194e155", // sifra1,
                    IsActive = true,
                    IsDeleted = false,
                    DeletedAt = null,
                    ModifiedAt = null
                },
                new User
                {
                    FirstName = "Mika",
                    LastName = "Mikic",
                    PhoneNumber = "066111333",
                    Email = "mika.mikic@ict.edu.rs",
                    Password = "5624c771a8e2e0c12fb764264e91b321fafaf81178de928864f843bdf194e155", // sifra1,
                    IsActive = true,
                    IsDeleted = false,
                    DeletedAt = null,
                    ModifiedAt = null
                }
            };
            var userGroup = new List<UserGroup>
            {
                new UserGroup
                {
                    Group = groups[0],
                    User = user[0]
                },
                new UserGroup
                {
                    Group = groups[1],
                    User = user[0]
                },
                new UserGroup
                {
                    Group = groups[2],
                    User = user[0]
                },
                new UserGroup
                {
                    Group = groups[1],
                    User = user[1]
                },
                new UserGroup
                {
                    Group = groups[0],
                    User = user[1]
                },
                new UserGroup
                {
                    Group = groups[2],
                    User = user[1]
                },
                new UserGroup
                {
                    Group = groups[2],
                    User = user[2]
                }
            };
            var sizes = new List<Size>()
            {
                new Size
                {
                    Value = 20
                },
                new Size
                {
                    Value = 21
                },
                new Size
                {
                    Value = 22
                },
                new Size
                {
                    Value = 23
                },
                new Size
                {
                    Value = 24
                },
                new Size
                {
                    Value = 25
                },
                new Size
                {
                    Value = 26
                },
                new Size
                {
                    Value = 27
                },
                new Size
                {
                    Value = 28
                },
                new Size
                {
                    Value = 29
                },
                new Size
                {
                    Value = 30
                }
            };
            var product = new List<Product>
            {
                new Product
                {
                    Category  = categories[0],
                    Brand = brand[0],
                    Color = colors[0],
                    Gender = genders[0],
                    Season = seasons[2],
                    Description = "Visok kvalitet, pristupacna cena, plave cipele za decaka..",
                    Image = "3232131_blueshoesCiciban.jpg",
                    IsActive = true,
                    IsDeleted = false,
                    DeletedAt = null,
                    ModifiedAt = null
                },
                new Product
                {
                    Category  = categories[0],
                    Brand = brand[1],
                    Color = colors[0],
                    Gender = genders[0],
                    Season = seasons[3],
                    Description = "Visok kvalitet, pristupacna cena, plave cipele za decaka..",
                    Image = "3322131_blueshoesCicibanWinter.jpg",
                    IsActive = true,
                    IsDeleted = false,
                    DeletedAt = null,
                    ModifiedAt = null
                },
                new Product
                {
                    Category  = categories[0],
                    Brand = brand[1],
                    Color = colors[3],
                    Gender = genders[0],
                    Season = seasons[3],
                    Description = "Visok kvalitet, pristupacna cena, sive cipele za decaka..",
                    Image = "3322131_greyshoesFilipS.jpg",
                    IsActive = true,
                    IsDeleted = false,
                    DeletedAt = null,
                    ModifiedAt = null
                },
                new Product
                {
                    Category  = categories[1],
                    Brand = brand[4],
                    Color = colors[2],
                    Gender = genders[1],
                    Season = seasons[1],
                    Description = "Visok kvalitet, pristupacna cena, patike za devojcicu..",
                    Image = "3322131_adidas.jpg",
                    IsActive = true,
                    IsDeleted = false,
                    DeletedAt = null,
                    ModifiedAt = null
                }
            };
            var price = new List<Price>
            {
                new Price
                {
                    Product = product[0],
                    Value = 3400
                },
                new Price
                {
                    Product = product[1],
                    Value = 3200
                },
                new Price
                {
                    Product = product[2],
                    Value = 2799
                },
                new Price
                {
                    Product = product[3],
                    Value = 3999
                }
            };
            var productSizes = new List<ProductSize>
            {
                new ProductSize
                {
                    Product = product[0],
                    Size = sizes[0],
                    Quantity = 20
                },
                new ProductSize
                {
                    Product = product[0],
                    Size = sizes[1],
                    Quantity = 20
                },
                new ProductSize
                {
                    Product = product[0],
                    Size = sizes[2],
                    Quantity = 20
                },
                new ProductSize
                {
                    Product = product[0],
                    Size = sizes[3],
                    Quantity = 20
                },
                new ProductSize
                {
                    Product = product[0],
                    Size = sizes[4],
                    Quantity = 20
                },
                new ProductSize
                {
                    Product = product[1],
                    Size = sizes.First(),
                    Quantity = 20
                },
                new ProductSize
                {
                    Product = product[1],
                    Size = sizes[1],
                    Quantity = 20
                },
                new ProductSize
                {
                    Product = product[1],
                    Size = sizes[3],
                    Quantity = 20
                },
                new ProductSize
                {
                    Product = product[1],
                    Size = sizes[4],
                    Quantity = 20
                },
                new ProductSize
                {
                    Product = product[2],
                    Size = sizes.First(),
                    Quantity = 20
                },
                new ProductSize
                {
                    Product = product[2],
                    Size = sizes[1],
                    Quantity = 20
                },
                new ProductSize
                {
                    Product = product[2],
                    Size = sizes[2],
                    Quantity = 20
                },
                new ProductSize
                {
                    Product = product[2],
                    Size = sizes[5],
                    Quantity = 20
                },
                new ProductSize
                {
                    Product = product[2],
                    Size = sizes[6],
                    Quantity = 20
                },
                new ProductSize
                {
                    Product = product[2],
                    Size = sizes[8],
                    Quantity = 20
                },
                new ProductSize
                {
                    Product = product[3],
                    Size = sizes.First(),
                    Quantity = 20
                },
                new ProductSize
                {
                    Product = product[3],
                    Size = sizes[3],
                    Quantity = 20
                },
                new ProductSize
                {
                    Product = product[3],
                    Size = sizes[4],
                    Quantity = 20
                },
                new ProductSize
                {
                    Product = product[3],
                    Size = sizes[5],
                    Quantity = 20
                }
            };
            var comments = new List<Comment>
            {
                new Comment
                {
                    User = user[2],
                    Product = product[0],
                    Text = "Sve pohvale za cipele, svaka preporuka"
                },
                new Comment
                {
                    User = user[2],
                    Product = product[1],
                    Text = "Cipele su ok, ali ne vrede te pare."
                },
                new Comment
                {
                    User = user[2],
                    Product = product[3],
                    Text = "Nista specijalno.."
                }
            };
            var rating = new List<Rating>
            {
                new Rating
                {
                    User = user[2],
                    Product = product[0],
                    Value = 5
                },
                new Rating
                {
                    User = user[2],
                    Product = product[1],
                    Value = 4
                },
                new Rating
                {
                    User = user[2],
                    Product = product[3],
                    Value = 2
                }
            };

            _context.Brands.AddRange(brand);
            _context.Seasons.AddRange(seasons);
            _context.Groups.AddRange(groups);
            _context.Genders.AddRange(genders);
            _context.Categories.AddRange(categories);
            _context.Colors.AddRange(colors);
            for (int i = 1; i <= 100; i++)
            {
                    _context.AddRange(new UserUseCase
                    {
                        Group = groups[0],
                        UseCaseId = i
                    });  
            }
            for(int i = 101; i <= 200; i++)
            {
                _context.UserUseCases.AddRange(new UserUseCase
                {
                    Group = groups[1],
                    UseCaseId = i
                });
            }
            for(int i = 201; i<= 420; i++)
            {
                    _context.UserUseCases.AddRange(new UserUseCase
                    {
                        Group = groups[2],
                        UseCaseId = i
                    });
            }
            _context.Users.AddRange(user);
            _context.UserGroups.AddRange(userGroup);
            _context.Sizes.AddRange(sizes);
            _context.Products.AddRange(product);
            _context.Prices.AddRange(price);
            _context.ProductSizes.AddRange(productSizes);
            _context.Comments.AddRange(comments);
            _context.Ratings.AddRange(rating);
            try
            {
                _context.SaveChanges();
                return StatusCode(201);
            }
            catch (Exception)
            {

                return StatusCode(500);
            }

        }


    }
}
