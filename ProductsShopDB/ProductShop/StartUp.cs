using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ProductShop.Data;
using ProductShop.DTOs.Import;
using ProductShop.Models;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Diagnostics.Metrics;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main()
        {
            using ProductShopContext dbContext = new ProductShopContext();
            dbContext.Database.Migrate();

            //string jsonString = File.ReadAllText("../../../Datasets/categories-products.json");
            string result = GetUsersWithProducts(dbContext);
            Console.WriteLine(result);
        }


        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            string result = string.Empty ;
            ImportUserDto[]? userDtos = JsonConvert.DeserializeObject<ImportUserDto[]>(inputJson);
           
            if (userDtos!=null)
            {
                ICollection<User> usersToImport = new List<User>();

                foreach (ImportUserDto userDto in userDtos)
                {
                    if (!IsValid(userDto))
                    {
                        continue;
                    }
                    int? userAge = null;
                    if (userDto.Age!=null)
                    {
                       
                        bool isAgeValid = int.TryParse(userDto.Age, out int parsedAge);
                        if (!isAgeValid)
                        {
                            continue;
                        }
                        userAge = parsedAge;
                    }
                    User currentUser = new User()
                    {
                        FirstName = userDto.FirstName,
                        LastName = userDto.LastName,
                        Age = userAge
                    };
                    usersToImport.Add(currentUser);
                    
                }

                context.Users.AddRange(usersToImport);
                context.SaveChanges();
                result = $"Successfully imported {usersToImport.Count}";
            }
            return result;
        }

        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            string result = string.Empty;
            ImportProductsDto[]? productsDtos = JsonConvert.DeserializeObject<ImportProductsDto[]>(inputJson);
            if (productsDtos!=null)
            {
                ICollection<Product> productsToImport = new List<Product>();
                foreach (ImportProductsDto productDto in productsDtos)
                {
                    if (!IsValid(productDto))
                        continue;

                    bool isPriceValid = decimal.TryParse(productDto.Price, out decimal price);
                    if (!isPriceValid) continue;
                    bool isSellerValid = int.TryParse(productDto.SellerId, out int sellerId);
                    if (!isSellerValid) continue;

                    int? buyerId = null;
                    if (productDto.BuyerId != null)
                    {
                        bool isBuyerValid = int.TryParse(productDto.BuyerId, out int parsedBuyerId);
                        if (!isBuyerValid) continue;

                        buyerId = parsedBuyerId;

                    }
                    Product currentProduct = new Product()
                    {
                        Name=productDto.Name,
                        Price = price,
                        SellerId = sellerId,
                        BuyerId = buyerId
                    };
                    productsToImport.Add(currentProduct);


                }
                context.Products.AddRange(productsToImport);
                context.SaveChanges();
                result = $"Successfully imported {productsToImport.Count}";
            }
            return result ; 
        }
        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            string result = string.Empty;
            ImportCategoriesDto[]? categoriesDtos = JsonConvert.DeserializeObject<ImportCategoriesDto[]>(inputJson);
            if (categoriesDtos != null)
            {
                ICollection<Category> categoriesToImport = new List<Category>();
                foreach (ImportCategoriesDto categoryDto in categoriesDtos)
                {
                    if (!IsValid(categoryDto))
                        continue;
                    Category currentCategory = new Category()
                    {
                        Name = categoryDto.Name!
                    };
                    categoriesToImport.Add(currentCategory);
                }
                context.Categories.AddRange(categoriesToImport);
                context.SaveChanges();
                result = $"Successfully imported {categoriesToImport.Count}";
            }
            return result ; 

        }

        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            string result = string.Empty ;
            ImportCategoriesProductsDto[]? categoryProductsDtos = JsonConvert.DeserializeObject<ImportCategoriesProductsDto[]>(inputJson);
            if (categoryProductsDtos != null)
            {
                ICollection<CategoryProduct> categoriesProductsToImport = new List<CategoryProduct>();
                foreach (ImportCategoriesProductsDto categoryProductDto in categoryProductsDtos)
                {
                    if (!IsValid(categoryProductDto))
                        continue;
                    bool isCategoryIdValid = int.TryParse(categoryProductDto.CategoryId, out int categoryId);
                        if (!isCategoryIdValid )
                        continue;
                    bool isProductIdValid = int.TryParse(categoryProductDto.ProductId, out int productId);
                        if (!isProductIdValid )
                        continue;
                    CategoryProduct categoryProduct = new CategoryProduct()
                    {
                        CategoryId = categoryId,
                        ProductId = productId
                    };

                    categoriesProductsToImport.Add(categoryProduct);

                        
                    
                }
                context.CategoriesProducts.AddRange(categoriesProductsToImport);
                context.SaveChanges();
                result = $"Successfully imported {categoriesProductsToImport.Count}";
            }
            return result;
        }

        public static string GetProductsInRange(ProductShopContext context)
        {
            var products = context.Products
                .Where(p=>p.Price>=500&&p.Price<=1000)
                .OrderBy(p => p.Price)
                .Select(p => new
                {
                    name = p.Name,
                    price = p.Price,
                    seller = p.Seller.FirstName + " " + p.Seller.LastName
                })
                .ToArray();
            DefaultContractResolver contractResolver = new DefaultContractResolver()
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            };
            string jsonResult = JsonConvert.SerializeObject(products, Formatting.Indented, new JsonSerializerSettings
            {
                ContractResolver = contractResolver
            });

            return jsonResult;
        }

        public static bool IsValid(object dto)
        {
            var validateContext = new ValidationContext(dto);
            var validationResults = new List<ValidationResult>();
            bool isValid = Validator.TryValidateObject(dto, validateContext, validationResults, true);

            return isValid;
        }


        public static string GetSoldProducts(ProductShopContext context)
        {
            var users = context.Users
                .Where(u=>u.ProductsSold.Any(b=>b.BuyerId.HasValue))
                .OrderBy(u=>u.LastName)
                .ThenBy(u=>u.FirstName)
                .Select(u=> new
                {
                    u.FirstName,
                    u.LastName,
                    SoldProducts = u.ProductsSold.Where(p=>p.BuyerId.HasValue)
                    .Select(p=> new
                    {
                        p.Name,
                        p.Price,
                        BuyerFirstName=p.Buyer.FirstName,
                        BuyerLastName =p.Buyer.LastName
                    }).ToArray()
                })
                .ToArray();
            DefaultContractResolver contractResolver = new DefaultContractResolver()
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            };
            string jsonResult = JsonConvert.SerializeObject(users, Formatting.Indented, new JsonSerializerSettings
            {
                ContractResolver = contractResolver
            });
            return jsonResult;
        }


        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categories = context.Categories
            .OrderByDescending(c=>c.CategoriesProducts.Count())
            .Select(c=> new
            {
                Category = c.Name,
                ProductsCount = c.CategoriesProducts.Count(),
                AveragePrice = c.CategoriesProducts.Average(p=>p.Product.Price).ToString("f2"),
                TotalRevenue = c.CategoriesProducts.Sum(p=>p.Product.Price).ToString("f2")
            }).ToArray();

            DefaultContractResolver contractResolver = new DefaultContractResolver()
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            };
            string jsonResult = JsonConvert.SerializeObject(categories, Formatting.Indented, new JsonSerializerSettings
            {
                ContractResolver = contractResolver
            });
            return jsonResult;
        }


        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var usersWithSoldProducts = context.Users
            .Where(u => u.ProductsSold.Any(p => p.BuyerId.HasValue))
            .Select(u => new
            {
                u.FirstName,
                u.LastName,
                u.Age,
                SoldProducts = new
                {
                    Count = u.ProductsSold.Count(p => p.BuyerId.HasValue),
                    Products = u.ProductsSold.Where(p => p.BuyerId.HasValue).Select(p => new
                    {
                        p.Name,
                        p.Price
                    }).ToArray()
                }
            }).ToArray().OrderByDescending(u => u.SoldProducts.Count).ToArray();

            var serializeObject = new
            {
                UsersCount = usersWithSoldProducts.Length,
                Users = usersWithSoldProducts
            };

            DefaultContractResolver contractResolver = new DefaultContractResolver()
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            };
            string jsonResult = JsonConvert.SerializeObject(serializeObject, Formatting.Indented, new JsonSerializerSettings
            {
                ContractResolver = contractResolver,
                NullValueHandling = NullValueHandling.Ignore
            });
            return jsonResult;
        }


    }
}