using AutoMapper;
using CarDealer.Data;
using CarDealer.DTOs.Import;
using CarDealer.Models;
using Microsoft.EntityFrameworkCore.Query;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;
using System.Xml.Linq;


namespace CarDealer
{
    public class StartUp
    {
        public static void Main()
        {
            CarDealerContext dbContext = new CarDealerContext();
            //dbContext.Database.EnsureDeleted();
            // dbContext.Database.EnsureCreated();
            //string jsonStringSuppliers = File.ReadAllText("../../../Datasets/suppliers.json");
            //string result = ImportSuppliers(dbContext, jsonStringSuppliers);
            //string jsonStringParts = File.ReadAllText("../../../Datasets/parts.json");
            //  result = ImportParts(dbContext, jsonStringParts);
            // string jsonStringCars = File.ReadAllText("../../../Datasets/cars.json");
            // result = ImportCars(dbContext, jsonStringCars);
            //string jsonStringCustomers = File.ReadAllText("../../../Datasets/customers.json");
            //string result = ImportCustomers(dbContext, jsonStringCustomers);
            //string jsonString = File.ReadAllText("../../../Datasets/sales.json");
            //string result = ImportSales(dbContext, jsonString);

            string result = GetSalesWithAppliedDiscount(dbContext);
            Console.WriteLine(result);
            
        }

        public static bool isValid(object dto)
        {
            var validateContext = new ValidationContext(dto);
            var validationResults = new List<ValidationResult>();
            bool isValid =Validator.TryValidateObject(dto,validateContext, validationResults,true);
            return isValid;
        }
        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            string result = string.Empty;
            ImportSuppliersDto[]? suppliersDtos = JsonConvert.DeserializeObject<ImportSuppliersDto[]>(inputJson);
            if (suppliersDtos != null)
            {
                ICollection<Supplier> suppliersToImport = new List<Supplier>();
                foreach(ImportSuppliersDto supplierDto in suppliersDtos)
                {
                    if (!isValid(supplierDto))
                        continue;

                    bool isImporterValid = bool.TryParse(supplierDto.isImporter, out bool isImporterParsed);
                    if (!isImporterValid)
                        continue;
                    Supplier currentSupplier = new Supplier
                    {
                        Name = supplierDto.Name,
                        IsImporter = isImporterParsed
                    };
                    suppliersToImport.Add(currentSupplier);
                }
                context.Suppliers.AddRange(suppliersToImport);
                context.SaveChanges();
                result = $"Successfully imported {suppliersToImport.Count}.";
            }
            return result;
                
        }

        public static string ImportParts(CarDealerContext context, string inputJson)
        {
            string result = string.Empty;
            ImportPartsDto[]? partsDtos = JsonConvert.DeserializeObject<ImportPartsDto[]>(inputJson);
            if (partsDtos != null)
            {
                ICollection<Part> partsToImport = new List<Part>();
                ICollection<int> validSuppliers = context.Suppliers.Select(s => s.Id).ToArray();
                foreach (ImportPartsDto partDto in partsDtos)
                {
                    if (!isValid(partDto))
                        continue;

                    bool isPriceCorrect = decimal.TryParse(partDto.Price, out decimal parsedPrice);
                    bool isQuantityCorrect = int.TryParse(partDto.Quantity, out int parsedQuantity);
                    bool isSupplierIdCorrect = int.TryParse(partDto.SupplierId, out int parsedSupplierId);
                    if (!isPriceCorrect || !isQuantityCorrect || !isSupplierIdCorrect||!validSuppliers.Contains(parsedSupplierId))
                        continue;

                    Part currentPart = new Part()
                    {
                        Name = partDto.Name,
                        Price = parsedPrice,
                        Quantity = parsedQuantity,
                        SupplierId = parsedSupplierId
                    };
                    partsToImport.Add(currentPart);

                }
                
                context.Parts.AddRange(partsToImport);
                context.SaveChanges();
                result = $"Successfully imported {partsToImport.Count}.";
            }
            return result;
        }

        public static string ImportCars(CarDealerContext context, string inputJson)
        {
            string result = string.Empty;
            ImportCarsDto[]? carsDtos = JsonConvert.DeserializeObject<ImportCarsDto[]>(inputJson);
            if (carsDtos != null)
            {
                ICollection<Car> carsToImport = new HashSet<Car>();
                ICollection<PartCar> partCarToImport = new HashSet<PartCar>();
                foreach (ImportCarsDto carDto in carsDtos)
                {
                    if (!isValid(carDto))
                        continue;
                                      
                    
                    Car currentCar = new Car
                    {
                        Make = carDto.Make,
                        Model = carDto.Model,
                        TraveledDistance = carDto.TraveledDistance

                    };
                    carsToImport.Add(currentCar);
                    if (carDto.PartsId != null)
                    {
                        foreach (int partId in carDto.PartsId.Distinct())
                        {

                            partCarToImport.Add(new PartCar
                            {
                                //PartId = partId,
                                PartId = partId,
                                Car = currentCar
                            });
                        }
                    }
                    

                }
                context.Cars.AddRange(carsToImport);
                context.PartsCars.AddRange(partCarToImport);
                context.SaveChanges();
                result = $"Successfully imported {carsToImport.Count}.";
            }
            
            return result;
        }

        public static string ImportCustomers(CarDealerContext context, string inputJson)
        {
            string result = string.Empty ;
            ImportCustomersDto[]? customersDtos= JsonConvert.DeserializeObject<ImportCustomersDto[]>(inputJson) ;
            if (customersDtos != null)
            {
                ICollection<Customer> customersToImport = new List<Customer>();
                foreach (ImportCustomersDto customerDto in customersDtos)
                {
                    if (!isValid(customerDto))
                        continue;
                    bool isYoungDriverCorrect = bool.TryParse(customerDto.IsYoungDriver, out bool parsedIsYoungDriver);
                    bool isBirthDayCorrect = DateTime.TryParse(customerDto.BirthDate, out DateTime parsedBirthDay);
                    if (!isYoungDriverCorrect || !isBirthDayCorrect)
                        continue;

                    Customer currentCustomer = new Customer
                    {
                        Name = customerDto.Name,
                        BirthDate = parsedBirthDay,
                        IsYoungDriver = parsedIsYoungDriver
                    };
                    customersToImport.Add(currentCustomer);
                }
                context.Customers.AddRange(customersToImport);
                context.SaveChanges();
                result = $"Successfully imported {customersToImport.Count}.";

            }

            return result ;
        }

        public static string ImportSales(CarDealerContext context, string inputJson)
        {
            string result = string.Empty;
            ImportSalesDto[]? salesDtos = JsonConvert.DeserializeObject<ImportSalesDto[]>(inputJson) ;
            if(salesDtos != null)
            {
                ICollection<Sale> salesToImport = new List<Sale>();
                foreach (ImportSalesDto salesDto in salesDtos)
                {
                    if(!isValid(salesDto))
                        continue;
                    bool isCarIdCorrect = int.TryParse(salesDto.CarId, out int parsedCarId);
                    bool isCustomerIdCorrect = int.TryParse(salesDto.CustomerId, out int parsedCustomerId);
                    bool isDiscountCorrect = decimal.TryParse(salesDto.Discount, out decimal parsedDiscount);
                    if (!isCarIdCorrect || !isCustomerIdCorrect||!isDiscountCorrect)
                        continue;
                    Sale currentSale = new Sale
                    {
                        CarId = parsedCarId,
                        CustomerId = parsedCustomerId,
                        Discount = parsedDiscount
                    };
                    salesToImport.Add(currentSale);
                }
                context.Sales.AddRange(salesToImport);
                context.SaveChanges();
                result = $"Successfully imported {salesToImport.Count}.";
            }

            return result;

        }


        public static string GetOrderedCustomers(CarDealerContext context)
        {
            var customers = context.Customers.
                Select(c => new
                {
                    Name = c.Name,
                    BirthDate = c.BirthDate,
                    IsYoungDriver = c.IsYoungDriver

                })
                .OrderBy(c => c.BirthDate)
                .ThenBy(c => c.IsYoungDriver)
                .ToArray()
                .Select(c=> new
                 {
                Name = c.Name,
                BirthDate = c.BirthDate.ToString("dd/MM/yyyy"),
                IsYoungDriver = c.IsYoungDriver
                 })
                .ToArray();
            DefaultContractResolver contractResolver = new DefaultContractResolver()
            {
                NamingStrategy = new DefaultNamingStrategy()
            };
            string jsonResult = JsonConvert.SerializeObject(customers, Formatting.Indented, new JsonSerializerSettings
            {
                ContractResolver = contractResolver
            });
            return jsonResult;
        }

        public static string GetCarsFromMakeToyota(CarDealerContext context)
        {
            var cars = context.Cars
                .Where(c=>c.Make== "Toyota")
                .Select(c=> new
                {
                    Id = c.Id,
                    Make = c.Make,
                    Model = c.Model,
                    TraveledDistance = c.TraveledDistance
                })
                .OrderBy (c => c.Model)
                .ThenByDescending(c => c.TraveledDistance)
                .ToArray();

            DefaultContractResolver contractResolver = new DefaultContractResolver()
            {
                NamingStrategy = new DefaultNamingStrategy()
            };
            string jsonResult = JsonConvert.SerializeObject(cars, Formatting.Indented, new JsonSerializerSettings
            {
                ContractResolver = contractResolver
            });
            return jsonResult;
        }

        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var suppliers = context.Suppliers
            .Where(s=>s.IsImporter == false)
            .Select(s=> new
            {
                Id = s.Id,
                Name = s.Name,
                PartsCount = s.Parts.Count
            }).ToArray();

            DefaultContractResolver contractResolver = new DefaultContractResolver()
            {
                NamingStrategy = new DefaultNamingStrategy()
            };
            string jsonResult = JsonConvert.SerializeObject(suppliers, Formatting.Indented, new JsonSerializerSettings
            {
                ContractResolver = contractResolver
            });
            return jsonResult;
        }

        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var cars = context.Cars
            .Select(c=> new
            {
                car= new
                {
                    c.Make,
                    c.Model,
                    c.TraveledDistance,
                },
                parts =c.PartsCars.ToArray()
                    .Select(pc => new
                    {
                        Name = pc.Part.Name,
                        Price = pc.Part.Price.ToString("f2")
                    }).ToArray()
            }).ToArray();

            

            DefaultContractResolver contractResolver = new DefaultContractResolver()
            {
                NamingStrategy = new DefaultNamingStrategy()
            };
            string jsonResult = JsonConvert.SerializeObject(cars, Formatting.Indented, new JsonSerializerSettings
            {
                ContractResolver = contractResolver
            });
            return jsonResult;
        }

        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var customers = context.Customers
                .Where(c => c.Sales.Any())
                .Select(c => new
                {
                    fullName = c.Name,
                    boughtCars = c.Sales.Count,
                    spentMoney = c.Sales.
                                    SelectMany(s => s.Car.PartsCars).Sum(p => p.Part.Price)

                }).ToArray().OrderByDescending(c=>c.spentMoney).ThenByDescending(c=>c.boughtCars);

            DefaultContractResolver contractResolver = new DefaultContractResolver()
            {
                NamingStrategy = new DefaultNamingStrategy()
            };
            string jsonResult = JsonConvert.SerializeObject(customers, Formatting.Indented, new JsonSerializerSettings
            {
                ContractResolver = contractResolver
            });
            return jsonResult;
        }


        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var sales = context.Sales.Take(10)
                .Select(s => new
                {
                    car = new
                    {
                        Make = s.Car.Make,
                        Model = s.Car.Model,
                        TraveledDistance = s.Car.TraveledDistance
                    },
                    customerName = s.Customer.Name,
                    discount = s.Discount.ToString("F2"),
                    price = s.Car.PartsCars.Select(c => c.Part.Price).Sum().ToString("F2"),
                    priceWithDiscount = (s.Car.PartsCars.Select(c => c.Part.Price).Sum()*((100-s.Discount)/100)).ToString("f2")
                });


            DefaultContractResolver contractResolver = new DefaultContractResolver()
            {
                NamingStrategy = new DefaultNamingStrategy()
            };
            string jsonResult = JsonConvert.SerializeObject(sales, Formatting.Indented, new JsonSerializerSettings
            {
                ContractResolver = contractResolver
            });
            return jsonResult;
        }
    }
}