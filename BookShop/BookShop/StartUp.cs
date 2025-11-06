namespace BookShop
{
    using BookShop.Models;
    using BookShop.Models.Enums;
    using Data;
    using Initializer;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.ValueGeneration.Internal;
    using System.Globalization;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            using var db = new BookShopContext();
            //DbInitializer.ResetDatabase(db);

            //int count = int.Parse(Console.ReadLine());
            //Console.WriteLine(GetBooksByAgeRestriction(db, input));
            RemoveBooks(db);
        }


        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {



            var books = context.Books.Where(b => b.EditionType == EditionType.Gold).OrderBy(b => b.Title).Select(b => b.Title).ToArray();
            return string.Join(Environment.NewLine, books);
        }

        public static string GetGoldenBooks(BookShopContext context)
        {
            bool isParsed = Enum.TryParse<EditionType>("Gold", false, out EditionType editionType);
            var books = context.Books.Where(b => b.EditionType == editionType && b.Copies < 5000).OrderBy(b => b.BookId).Select(b => b.Title).ToArray();
            return string.Join(Environment.NewLine, books);
        }

        public static string GetBooksByPrice(BookShopContext context)
        {
            StringBuilder sb = new StringBuilder();
            var books = context.Books
                .Where(b => b.Price > 40)
                .Select(b => new
                {
                    Title = b.Title,
                    Price = b.Price
                })
                .OrderByDescending(b => b.Price)
                .ToArray();
            foreach (var book in books)
            {
                sb.AppendLine($"{book.Title} - ${book.Price:f2}");
            }

            return sb.ToString().Trim();
        }

        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            var books = context.Books
                .Where(b => b.ReleaseDate.Value.Year != year).OrderBy(b => b.BookId).Select(b => b.Title).ToArray();
            return String.Join(Environment.NewLine, books);
        }

        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            string[] categories = input.ToLower().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            var books = context.Books
                .Where(b => b.BookCategories.Any(bc => categories.Contains(bc.Category.Name.ToLower())))
                .OrderBy(b => b.Title)
                .Select(b => b.Title);
            return String.Join(Environment.NewLine, books);

        }

        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            bool isParsed = DateTime.TryParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime releaseDate);
            if (!isParsed) return String.Empty;
            StringBuilder sb = new StringBuilder();
            var books = context.Books
                .Where(b => b.ReleaseDate < releaseDate)
                .OrderByDescending(b => b.ReleaseDate)
                .Select(b => new
                {
                    Title = b.Title,
                    Edition = b.EditionType,
                    Price = b.Price
                }).ToArray();
            foreach (var book in books)
            {
                sb.AppendLine($"{book.Title} - {book.Edition} - ${book.Price:f2}");
            }
            return sb.ToString().Trim();

        }

        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            var authors = context.Authors
                .Where(a=>a.FirstName.EndsWith(input.ToLower()))
                .OrderBy(a=>a.FirstName)
                .ThenBy(a=> a.LastName)
                .Select(a=> a.FirstName+" "+a.LastName).ToArray();
            return String.Join(Environment.NewLine, authors);
        }

        public static string GetBookTitlesContaining(BookShopContext context, string input)

        {
            var books = context.Books
               .Where(b => b.Title.ToLower().Contains(input.ToLower()))
               .OrderBy(b => b.Title)
               .Select(b => b.Title).ToArray();
            return String.Join(Environment.NewLine, books);
        }

        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            StringBuilder sb = new StringBuilder();
            var books = context.Books.
                Where(b=>b.Author.LastName.ToLower().StartsWith(input.ToLower()))
                .OrderBy(b=>b.BookId)
                .Select(b=> new
                {
                    Title = b.Title,
                    AuthorName = b.Author.FirstName + " " + b.Author.LastName
                })
                .ToArray();
            foreach (var book in books)
            {
                sb.AppendLine($"{book.Title} ({book.AuthorName})");
            }
            return sb.ToString().Trim();
        }

        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            return context.Books.
                Where(b => b.Title.Length > lengthCheck).Count();
        }

        public static string CountCopiesByAuthor(BookShopContext context)
        {
            StringBuilder sb = new StringBuilder();
            var authorCount = context.Authors
                .OrderByDescending(a=>a.Books.Sum (b=>b.Copies))
                .Select(a => new
                {
                    AuthorName = a.FirstName +" "+a.LastName,
                    AuthorCopies = a.Books.Sum (b=>b.Copies)
                }).ToArray();
            foreach (var author in authorCount)
                sb.AppendLine($"{author.AuthorName} - {author.AuthorCopies}");

            return sb.ToString().Trim();

        }
        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            StringBuilder sb = new StringBuilder();
            var categoryIncome = context.Categories
                .Select(c => new
                {
                    CategoryName= c.Name,
                    CategoryIncome = c.CategoryBooks.Select (b=>b.Book.Copies*b.Book.Price).Sum()
                                                                
                }).ToArray();
            categoryIncome= categoryIncome.OrderByDescending(c=>c.CategoryIncome).ToArray();
            foreach (var category in categoryIncome)
            {
                sb.AppendLine($"{category.CategoryName} ${category.CategoryIncome:f2}");
            }
            return sb.ToString().Trim();
        }

        public static string GetMostRecentBooks(BookShopContext context)
        {
            StringBuilder sb = new StringBuilder();
            var topBooksByCategories = context.Categories.OrderBy(c=>c.Name)
                .Select(c => new
                {
                    CategoryName = c.Name,
                    Books = c.CategoryBooks.OrderByDescending(b=>b.Book.ReleaseDate)
                    .Select( b=> new
                    {
                        BookTitle = b.Book.Title,
                        Year = b.Book.ReleaseDate
                    }).ToArray()

                }).ToArray();

            foreach (var topBook in topBooksByCategories)
            {
                sb.AppendLine($"--{topBook.CategoryName}");
                var books = topBook.Books.Take(3);
                foreach (var book in books) 
                {
                 
                    sb.AppendLine($"{book.BookTitle} ({book.Year.Value.Year})");
                }
            }

            return sb.ToString().Trim();
        }

        public static void IncreasePrices(BookShopContext context)
        {
            IQueryable<Book> booksToModify = context.Books.Where(b => b.ReleaseDate.HasValue && b.ReleaseDate.Value.Year < 2010);
            foreach (var book in booksToModify)
            {
                book.Price += 5;
            }
            context.SaveChanges();
        }

        public static int RemoveBooks(BookShopContext context)
        {
            var booksToRemove = context.Books
                .Where(b => b.Copies < 4200).ToArray();
            int count = 0;
            foreach (var book in booksToRemove)
            {
                
                context.Books.Remove(book);
                count++;

            }
            context.SaveChanges();
            return count;

        }
    }
}


