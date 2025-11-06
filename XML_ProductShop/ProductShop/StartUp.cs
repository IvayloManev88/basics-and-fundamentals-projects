
using ProductShop.Data;
using ProductShop.DTOs.Export;
using ProductShop.DTOs.Import;
using ProductShop.Models;
using ProductShop.Utilities;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Text;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main()
        {
            ProductShopContext dbContext = new ProductShopContext();
            //dbContext.Database.EnsureDeleted();
            //dbContext.Database.EnsureCreated();
            // string usersFilePath = File.ReadAllText("../../../Datasets/users.xml");
            //string result = ImportUsers(dbContext, usersFilePath);

            // string productsFilePath = File.ReadAllText("../../../Datasets/products.xml");
            //  string result = ImportProducts(dbContext, productsFilePath);

            //string categoriesFilePath = File.ReadAllText("../../../Datasets/categories.xml");
            //string result = ImportCategories(dbContext, categoriesFilePath);

            //string categoriesProductsFilePath = File.ReadAllText("../../../Datasets/categories-products.xml");
            //string result = ImportCategoryProducts(dbContext, categoriesProductsFilePath);
            string result = GetUsersWithProducts(dbContext);
            Console.WriteLine(result);
        }


        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            string result = string.Empty;
            ImportUserDto[] userDtos = XmlHelper.Deserialize<ImportUserDto[]>(inputXml, "Users");
            if (userDtos != null)
            {
                ICollection<User> usersToImport = new List<User>();
                foreach (ImportUserDto userDto in  userDtos)
                {
                    if (!IsValid(userDto))
                        continue;
                    int? userAge = null;
                    if (userDto.Age!=null)
                    {
                        bool isAgeValid=int.TryParse(userDto.Age, out int parsedAge);
                        if (!isAgeValid)
                            continue;
                        userAge= parsedAge;

                    }
                    User currentUser = new User
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
        public static string ImportProducts(ProductShopContext context, string inputXml)
        {
            string result = string.Empty;
            ImportProductDto[] productDtos = XmlHelper.Deserialize<ImportProductDto[]>(inputXml, "Products");
            if (productDtos != null)
            {
                ICollection<Product> productsToImport = new List<Product>();
                foreach(ImportProductDto productDto in productDtos)
                {
                    if (!IsValid(productDto))
                        continue;
                    bool isPriceValid = decimal.TryParse(productDto.Price, out decimal parsedPrice);
                    if (!isPriceValid)
                        continue;
                    int? buyerId = null;
                    if (productDto.BuyerId != null)
                    {
                        bool isBuyerValid = int.TryParse(productDto.BuyerId, out int parsedBuyerId);
                        if (!isBuyerValid)
                            continue ;
                        buyerId = parsedBuyerId;
                    }
                    bool isSellerValid = int.TryParse(productDto.SellerId, out int parsedSellerId);
                    if (!isSellerValid)
                        continue;
                    Product currentProduct = new Product
                    {
                        Name = productDto.Name,
                        Price = parsedPrice,
                        BuyerId = buyerId,
                        SellerId = parsedSellerId
                    };
                    productsToImport.Add(currentProduct);
                }
                context.Products.AddRange(productsToImport);
                context.SaveChanges();
                result = $"Successfully imported {productsToImport.Count}";
            }

            return result;
        }

        public static string ImportCategories(ProductShopContext context, string inputXml)
        {
            string result = string.Empty;
            ImportCategoriesDto[] categoryDtos = XmlHelper.Deserialize<ImportCategoriesDto[]>(inputXml, "Categories");
            if (categoryDtos!=null)
            {
                ICollection<Category> importCategories = new List<Category>();
                foreach (ImportCategoriesDto categoryDto in categoryDtos)
                {
                    if (!IsValid(categoryDto))
                        continue ;
                    Category currentCategory = new Category
                    {
                        Name = categoryDto.Name,
                    };
                    importCategories.Add(currentCategory);

                }
                context.Categories.AddRange(importCategories);
                context.SaveChanges();
                result = $"Successfully imported {importCategories.Count}";
            }

            return result;
        }

        public static string ImportCategoryProducts(ProductShopContext context, string inputXml)
        {
            string result= string.Empty;
            ImportCategoryProductDto[] categoryProductDtos = XmlHelper.Deserialize<ImportCategoryProductDto[]>(inputXml, "CategoryProducts");
            if (categoryProductDtos!=null)
            {
                ICollection<CategoryProduct> importCategoryProduct = new List<CategoryProduct>();
                IEnumerable<int> currentCategoriesIds = context.Categories.Select(c=>c.Id).ToArray();
                IEnumerable<int> currentProductsIds = context.Products.Select(c => c.Id).ToArray();
                foreach (ImportCategoryProductDto categoryProductDto in categoryProductDtos)
                {
                    if (!IsValid(categoryProductDto))
                        continue;
                    bool isCategoryIdValid = int.TryParse(categoryProductDto.CategoryId, out int parsedCategoryId);
                    bool isProductIdValid = int.TryParse(categoryProductDto.ProductId, out int parsedProductId);
                    if (!isCategoryIdValid || !isProductIdValid || !currentCategoriesIds.Contains(parsedCategoryId) || !currentProductsIds.Contains(parsedProductId))
                        continue;
                    CategoryProduct currentCategoryProduct = new CategoryProduct
                    {
                        CategoryId = parsedCategoryId,
                        ProductId = parsedProductId,
                    };
                    importCategoryProduct.Add(currentCategoryProduct);
                }
                context.CategoryProducts.AddRange(importCategoryProduct);
                context.SaveChanges();
                result = $"Successfully imported {importCategoryProduct.Count}";
            }

            return result;
        }

        public static bool IsValid(object dto)
        {
            var validateContext = new ValidationContext(dto);
            var validationResults = new List<ValidationResult>();
            bool isValid = Validator.TryValidateObject(dto, validateContext, validationResults, true);
            return isValid;
        }


        public static string GetProductsInRange(ProductShopContext context)
        {
            ExportProductsInRange[] products = context.Products.Where(p => p.Price >= 500 && p.Price <= 1000).OrderBy(p => p.Price).Take(10)
                .Select(p => new ExportProductsInRange
                {
                    Name = p.Name,
                    Price = p.Price.ToString("0.##", CultureInfo.InvariantCulture),
                    BuyerName = p.Buyer==null
                    ? " "
                    : string.Join(" ",p.Buyer.FirstName ,p.Buyer.LastName)
                }).ToArray();

            string result = XmlHelper.Serialize(products, "Products");
            return result;
        }


        /* public static string GetSoldProducts(ProductShopContext context)
         {
             ExportUserSoldItemsDto[] users = context.Users.Where(p => p.ProductsSold.Any()).OrderBy(p => p.LastName).ThenBy(p => p.FirstName)
                .Select(u => new ExportUserSoldItemsDto
                {
                     FirstName = u.FirstName,
                     LastName = u.LastName,
                     SoldProducts = u.ProductsSold.Select(p => new ExportSoldProductsDto
                     {
                         Name = p.Name,
                         Price = p.Price.ToString("0.##", CultureInfo.InvariantCulture)
                     }).ToArray()
                 }).Take(5).ToArray();

             string result = XmlHelper.Serialize(users, "Users");
             return result;
        }
         */

        public static string  GetCategoriesByProductsCount(ProductShopContext context)
        {
            ExportCategoriesDto[] categories = context.Categories
            .Select(c=> new ExportCategoriesDto
            {
                Name = c.Name,
                Count = c.CategoryProducts.Count().ToString("0", CultureInfo.InvariantCulture),
                AveragePrice = c.CategoryProducts.Average(cp=>cp.Product.Price).ToString(),
                TotalRevenue = c.CategoryProducts.Sum(cp => cp.Product.Price).ToString()

            }).ToArray().OrderByDescending(c => int.Parse(c.Count)).ThenBy(c => decimal.Parse(c.TotalRevenue)).ToArray();   

            string result = XmlHelper.Serialize(categories, "Categories");
            return result;
        }

        public static string GetUsersWithProducts(ProductShopContext context)
        {
            ExportUsersWithProductsDto[] users = context.Users.Where(p => p.ProductsSold.Any()).OrderByDescending(u => u.ProductsSold.Count()).Take(10)
                .Select(u => new ExportUsersWithProductsDto
                {
                        FirstName = u.FirstName,
                        LastName = u.LastName,
                        Age = u.Age.HasValue ? u.Age.Value.ToString() : null,
                        SoldProducts =  new ExportSoldProductsArray
                        {
                            Count = u.ProductsSold.Count().ToString(),
                            Products = u.ProductsSold.OrderByDescending(p => p.Price).Select(s => new ExportSoldProductsDto
                            {
                                Name = s.Name,
                                Price = s.Price.ToString()
                            }).ToArray()
                        }                
                }).ToArray();

            ExportUserDto rootDto = new ExportUserDto
            {
                Count = context.Users.Count(u => u.ProductsSold.Any()).ToString(),
                Users = users
            };
            string result = XmlHelper.Serialize(rootDto, "Users");
            return result;
        }
    }
}