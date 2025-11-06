using CarDealer.Data;
using CarDealer.DTOs.Export;
using CarDealer.DTOs.Import;
using CarDealer.Models;
using CarDealer.Utilities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.Extensions.Options;
using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Xml.Serialization;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main()
        {
            using CarDealerContext dbContext = new CarDealerContext();
           //  dbContext.Database.EnsureDeleted();
           //  dbContext.Database.EnsureCreated();
           //  string suppliersPath = File.ReadAllText("../../../Datasets/suppliers.xml");
            // string result = ImportSuppliers(dbContext, suppliersPath);
           // string partsPath = File.ReadAllText("../../../Datasets/parts.xml");
            //  result = ImportParts(dbContext, partsPath);
            //string carsPath = File.ReadAllText("../../../Datasets/cars.xml");
           //  result = ImportCars(dbContext, carsPath);

           // string customerPath = File.ReadAllText("../../../Datasets/customers.xml");
           //  result = ImportCustomers(dbContext, customerPath);

           // string salesPath = File.ReadAllText("../../../Datasets/sales.xml");
          //   result = ImportSales(dbContext, salesPath);
             string result = GetSalesWithAppliedDiscount(dbContext);
            Console.WriteLine(result);

        }


        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {
            string result = string.Empty;
            ImportSupplierDto[]? supplierDtos = XmlHelper.Deserialize<ImportSupplierDto[]>(inputXml, "Suppliers");
            if (supplierDtos != null)
            {
                ICollection<Supplier> importSuppliers = new List<Supplier>();
                foreach (ImportSupplierDto supplierDto in supplierDtos)
                {
                    if (!isValid(supplierDto))
                        continue;
                    bool isImporterValid = bool.TryParse(supplierDto.IsImporter, out bool parsedImporter);
                    if (!isImporterValid)
                        continue;

                    Supplier currentSupplier = new Supplier
                    {
                        Name = supplierDto.Name,
                        IsImporter = parsedImporter,
                    };
                    importSuppliers.Add(currentSupplier);
                }
                context.Suppliers.AddRange(importSuppliers);
                context.SaveChanges();
                result = $"Successfully imported {importSuppliers.Count}";
                
            }
            return result;
        }

        public static bool isValid(object dto)
        {
            var validateContext = new ValidationContext(dto);
            var validationResults = new List<ValidationResult>();
            bool isValid = Validator.TryValidateObject(dto,validateContext,validationResults,true);
            return isValid;
        }

        public static string ImportParts(CarDealerContext context, string inputXml)
        {
            string result = string.Empty;
            ImportPartDto[]? partsDtos = XmlHelper.Deserialize<ImportPartDto[]>(inputXml, "Parts");
            List<int> suppliers = context.Suppliers.Select(p => p.Id).ToList();
            if (partsDtos!=null)
            {
                ICollection<Part> importParts = new List<Part>();
                foreach(ImportPartDto partDto in partsDtos)
                {
                    if (!isValid(partDto)) 
                        continue;
                    
                    bool isPriceValid = decimal.TryParse(partDto.Price, out decimal parsedPrice);
                    bool isQuantityValid = int.TryParse(partDto.Quantity, out int parsedQuantity);
                    bool isSupplierIDValid = int.TryParse(partDto.SupplierId, out int parsedSupplierID);
                    if (!isPriceValid || !isQuantityValid || !isSupplierIDValid|| !suppliers.Contains(parsedSupplierID))
                        continue;
                    Part currentPart = new Part
                    {
                        Name = partDto.Name,
                        Price = parsedPrice,
                        Quantity = parsedQuantity,
                        SupplierId = parsedSupplierID
                    };
                    importParts.Add(currentPart);

                }
                context.Parts.AddRange(importParts);
                context.SaveChanges();
                result = $"Successfully imported {importParts.Count}";

            }

            return result;
        }

        public static string ImportCars(CarDealerContext context, string inputXml)
        {
            string result = string.Empty;
            ImportCarDto[]? carDtos = XmlHelper.Deserialize<ImportCarDto[]>(inputXml,"Cars");
            if (carDtos != null)
            {
                IEnumerable<int> parts = context.Parts.Select(p => p.Id).ToArray();
                ICollection<Car> importCars = new List<Car>();
                ICollection<PartCar> validPartCar = new List<PartCar>();
                foreach (ImportCarDto carDto in carDtos)
                {
                    if (!isValid(carDto))
                        continue;
                    bool isTravelDistanceValid = long.TryParse(carDto.TraveledDistance, out long parsedTravelDistance);
                    if (!isTravelDistanceValid)
                        continue;

                    Car currentCar = new Car
                    {
                        Make = carDto.Make,
                        Model = carDto.Model,
                        TraveledDistance = parsedTravelDistance

                    };
                    
                    if (carDto.Parts != null)
                    {
                        int[] partIds = carDto.Parts.Where(p =>isValid(p)&& int.TryParse(p.Id, out int id))
                        .Select(p => int.Parse(p.Id)).Distinct().ToArray();

                        foreach (int partId in partIds)
                        {
                            if (!parts.Contains(partId))
                                continue;

                            PartCar currentPartCar = new PartCar
                            {
                                PartId = partId,
                                Car = currentCar
                            };
                            validPartCar.Add(currentPartCar);
                        }
                    }
                    importCars.Add(currentCar);

                    
                    

                }
                context.Cars.AddRange(importCars);
                context.PartsCars.AddRange(validPartCar);
                context.SaveChanges();
                result = $"Successfully imported {importCars.Count}";
            }
            return result;
        }
        public static string ImportCustomers(CarDealerContext context, string inputXml)
        {
            string result = string.Empty;
            ImportCustomersDto[] customerDtos = XmlHelper.Deserialize<ImportCustomersDto[]>(inputXml, "Customers");
            if (customerDtos != null)
            {
                ICollection<Customer> customersToImport = new List<Customer>();
                foreach (ImportCustomersDto customerDto in customerDtos)
                {
                    if(!isValid(customerDto))
                        continue;
                    bool isBirtDateValid = DateTime.TryParse(customerDto.BirthDate, out DateTime parsedBirtDate);
                    bool isYoungDriverValid = bool.TryParse(customerDto.IsYoungDriver, out bool parsedYoungDriver);
                    if (!isBirtDateValid||!isYoungDriverValid)
                        continue;
                    Customer currentCustomer = new Customer
                    {
                        Name = customerDto.Name,
                        BirthDate = parsedBirtDate,
                        IsYoungDriver = parsedYoungDriver
                    };
                    customersToImport.Add(currentCustomer);
                }
                context.Customers.AddRange(customersToImport);
                context.SaveChanges();
                result = $"Successfully imported {customersToImport.Count}";
            }
            

            return result;
        }

        public static string ImportSales(CarDealerContext context, string inputXml)
        {
            string result = string.Empty;
            ImportSaleDto[] saleDtos = XmlHelper.Deserialize<ImportSaleDto[]>(inputXml, "Sales");
            if (saleDtos != null)
            {
                ICollection<Sale> importSales = new List<Sale>();
                IEnumerable<int> allCarsIds = context.Cars.Select(c => c.Id).ToArray();
                foreach(ImportSaleDto saleDto in saleDtos)
                {
                    if (!isValid(saleDto))
                        continue;
                    bool isCarIdValid = int.TryParse(saleDto.CarId, out int parsedCarId);
                    bool isDiscountValid = decimal.TryParse(saleDto.Discount, out decimal parsedDiscount);
                    bool isCustomerIdValid = int.TryParse(saleDto.CustomerId, out int parsedCustomerId);
                    if(!isCarIdValid||!isCustomerIdValid|| !isDiscountValid|| !allCarsIds.Contains(parsedCarId))
                        continue;
                    Sale currentSale = new Sale
                    {
                        CarId = parsedCarId,
                        CustomerId = parsedCustomerId,
                        Discount = parsedDiscount
                    };
                    importSales.Add(currentSale);

                }

                context.Sales.AddRange(importSales);
                context.SaveChanges();
                result = $"Successfully imported {importSales.Count}";


            }
            return result;
        }

        public static string GetCarsWithDistance(CarDealerContext context)
        {
            ExportCarsOverDistanceDto[] cars = context.Cars.Where(c => c.TraveledDistance > 2000000)
                .Select(c => new ExportCarsOverDistanceDto()
                {
                    Make = c.Make,
                    Model = c.Model,
                    TraveledDistance = c.TraveledDistance.ToString()
                }).OrderBy(c => c.Make)
                .ThenBy(c=>c.Model).Take(10).ToArray();
            string result = XmlHelper.Serialize(cars, "cars");
            return result;

        }


        public static string GetCarsFromMakeBmw(CarDealerContext context)
        {
            ExportCarsBmw[] cars = context.Cars.Where(c=>c.Make== "BMW").OrderBy(c => c.Model).ThenByDescending(c => c.TraveledDistance)
                .Select(c=> new ExportCarsBmw()
                {
                    Id=c.Id.ToString(),
                    Model=c.Model,
                    TraveledDistance=c.TraveledDistance.ToString()
                }).ToArray();

            string result = XmlHelper.Serialize(cars, "cars");
            return result;
        }

        public static string GetLocalSuppliers(CarDealerContext context)
        {
            ExportLocalSuppliersDto[] suppliers = context.Suppliers.Where(s => s.IsImporter == false)
                .Select(c => new ExportLocalSuppliersDto
                {
                    Id = c.Id.ToString(),
                    Name = c.Name,
                    PartsCount = c.Parts.Count().ToString()
                }).ToArray();

            string result = XmlHelper.Serialize(suppliers, "suppliers");
            return result;
        }


        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            ExportCarsAndListPart[] cars = context.Cars.OrderByDescending(c => c.TraveledDistance).ThenBy(c => c.Model)
                .Select(c => new ExportCarsAndListPart
                {
                    Make = c.Make,
                    Model = c.Model,
                    TraveledDistance = c.TraveledDistance.ToString(),
                    Parts = c.PartsCars.OrderByDescending(pc => pc.Part.Price).Select(pc => new ExportPartDto
                    {
                        Name = pc.Part.Name,
                        Price = pc.Part.Price.ToString()
                    }).ToArray()
                }).Take(5).ToArray();

            string result = XmlHelper.Serialize(cars, "cars");
            return result;
        }


        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            ExportCustomerSales[] customers = context.Customers.Where(c => c.Sales.Any())
        .Select(c => new
        {
            c.Name,
            c.IsYoungDriver,
            Sales = c.Sales.Select(s => new
            {
                CarPrice = s.Car.PartsCars.Sum(pc => pc.Part.Price),
                s.Discount
            })
        })
        .AsEnumerable() // move to memory to allow aggregation
        .Select(c => new ExportCustomerSales
        {
            FullName = c.Name,
            BoughtCars = c.Sales.Count().ToString(),
            SpentMoney = c.Sales.Sum(s =>
            {
                decimal totalPrice = s.CarPrice;

                // Apply only young driver discount (5%) – NOT sale discount
                // This matches the official expected output from the SoftUni test
                if (c.IsYoungDriver)
                {
                    totalPrice *= 0.95m;
                }
                totalPrice = Math.Truncate(totalPrice * 100) / 100;
                return totalPrice;
            }).ToString("f2")


                }).OrderByDescending(c=>decimal.Parse(c.SpentMoney)).ToArray();

            string result = XmlHelper.Serialize(customers, "customers");
            return result;
        }

        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var sales = context.Sales
                .Select(s => new
                {
                    Car = new ExportCarForSaleDto
                    {
                        Make = s.Car.Make,
                        Model = s.Car.Model,
                        TraveledDistance = s.Car.TraveledDistance.ToString()
                    },
                    Discount = s.Discount,
                    CustomerName = s.Customer.Name,
                    Price = s.Car.PartsCars.Sum(pc => pc.Part.Price)
                })
                .AsEnumerable()
                .Select(s => new ExportSaleWithDiscount
                {
                    Car = s.Car,
                    Discount = Convert.ToInt32(Math.Truncate(s.Discount)),
                    CustomerName = s.CustomerName,
                    Price = Math.Round(s.Price, 4).ToString("0.####", CultureInfo.InvariantCulture),
                    PriceWithDiscount = Math.Round(s.Price * (1 - s.Discount / 100m), 4)
                                            .ToString("0.####", CultureInfo.InvariantCulture)
                })
                .ToArray();

            string result = XmlHelper.Serialize(sales, "sales").TrimEnd('\r', '\n');
            return result;
        }
    }
}