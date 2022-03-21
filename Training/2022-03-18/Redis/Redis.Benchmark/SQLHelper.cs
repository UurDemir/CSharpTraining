using AdventureWork.Models;

using Microsoft.EntityFrameworkCore;

namespace Redis.Benchmark
{
    public static class SQLHelper
    {
        public static int TotalCount = 10;
        public static Reseller? GetReseller(int resellerKey)
        {
            using AdventureWorksDW2017Context context = new(CommonHelper.Configuration);

            Reseller? reseller = context.DimResellers
               .AsNoTracking()
               .Where(reseller => reseller.ResellerKey == resellerKey)
               .Select(reseller => new Reseller
               {
                   ResellerKey = reseller.ResellerKey,
                   Address = reseller.AddressLine1 + " " + reseller.AddressLine2,
                   BankName = reseller.BankName,
                   BusinessType = reseller.BusinessType,
                   City = reseller.GeographyKeyNavigation.City,
                   Country = reseller.GeographyKeyNavigation.EnglishCountryRegionName,
                   EmployeeCount = reseller.NumberEmployees.Value,
                   Name = reseller.ResellerName,
                   OpenedYear = reseller.YearOpened.Value,
                   ResellerCode = reseller.ResellerAlternateKey
               }).FirstOrDefault();

            var orders = context.FactResellerSales
                .AsNoTracking()
                .Where(reseller => reseller.ResellerKey == resellerKey)
                .Select(sale => new FactResellerSale
                {
                    ResellerKey = sale.ResellerKey,
                    SalesOrderNumber = sale.SalesOrderNumber,
                    DueDate = sale.DueDate,
                    OrderDate = sale.OrderDate,
                    EmployeeKeyNavigation = new()
                    {
                        FirstName = sale.EmployeeKeyNavigation.FirstName,
                        LastName = sale.EmployeeKeyNavigation.LastName,
                        MiddleName = sale.EmployeeKeyNavigation.MiddleName,
                        Title = sale.EmployeeKeyNavigation.Title
                    },
                    ShipDate = sale.ShipDate,
                    SalesAmount = sale.SalesAmount,
                    OrderQuantity = sale.OrderQuantity,
                    CurrencyKeyNavigation = new()
                    {
                        CurrencyAlternateKey = sale.CurrencyKeyNavigation.CurrencyAlternateKey
                    },
                    ProductKeyNavigation = new()
                    {
                        ProductAlternateKey = sale.ProductKeyNavigation.ProductAlternateKey,
                        EnglishProductName = sale.ProductKeyNavigation.EnglishProductName,
                    },
                    CarrierTrackingNumber = sale.CarrierTrackingNumber
                })
                .ToList();

            var resellerOrders = orders.Where(og => og.ResellerKey == reseller.ResellerKey).ToArray();

            reseller.Orders = resellerOrders.GroupBy(order => order.SalesOrderNumber)
                .Select(MapOrder).ToArray();


            return reseller;
        }

        public static List<Reseller> GetResellers()
        {
            using AdventureWorksDW2017Context context = new(CommonHelper.Configuration);

            IQueryable<Reseller> queryable = context.DimResellers
                .AsNoTracking()
                .Select(reseller => new Reseller
                {
                    ResellerKey = reseller.ResellerKey,
                    Address = reseller.AddressLine1 + " " + reseller.AddressLine2,
                    BankName = reseller.BankName,
                    BusinessType = reseller.BusinessType,
                    City = reseller.GeographyKeyNavigation.City,
                    Country = reseller.GeographyKeyNavigation.EnglishCountryRegionName,
                    EmployeeCount = reseller.NumberEmployees.Value,
                    Name = reseller.ResellerName,
                    OpenedYear = reseller.YearOpened.Value,
                    ResellerCode = reseller.ResellerAlternateKey
                }).Take(TotalCount);
            List<Reseller> resellers = queryable.ToList();

            int[] resellerKeys = resellers.Select(reseller => reseller.ResellerKey).ToArray();

            IQueryable<FactResellerSale> factResellerSales = context.FactResellerSales
                .AsNoTracking()
                .Where(sale => resellerKeys.Contains(sale.ResellerKey))
                .Select(sale => new FactResellerSale
                {
                    ResellerKey = sale.ResellerKey,
                    SalesOrderNumber = sale.SalesOrderNumber,
                    DueDate = sale.DueDate,
                    OrderDate = sale.OrderDate,
                    EmployeeKeyNavigation = new()
                    {
                        FirstName = sale.EmployeeKeyNavigation.FirstName,
                        LastName = sale.EmployeeKeyNavigation.LastName,
                        MiddleName = sale.EmployeeKeyNavigation.MiddleName,
                        Title = sale.EmployeeKeyNavigation.Title
                    },
                    ShipDate = sale.ShipDate,
                    SalesAmount = sale.SalesAmount,
                    OrderQuantity = sale.OrderQuantity,
                    CurrencyKeyNavigation = new()
                    {
                        CurrencyAlternateKey = sale.CurrencyKeyNavigation.CurrencyAlternateKey
                    },
                    ProductKeyNavigation = new()
                    {
                        ProductAlternateKey = sale.ProductKeyNavigation.ProductAlternateKey,
                        EnglishProductName = sale.ProductKeyNavigation.EnglishProductName
                    },
                    CarrierTrackingNumber = sale.CarrierTrackingNumber
                });
            var orders = factResellerSales
                .ToList();

            foreach (Reseller reseller in resellers)
            {
                var resellerOrders = orders.Where(og => og.ResellerKey == reseller.ResellerKey);

                reseller.Orders = resellerOrders.GroupBy(order => order.SalesOrderNumber)
                    .Select(MapOrder).ToArray();
            }

            return resellers;
        }

        public static ResellerOrder MapOrder(IGrouping<string, FactResellerSale> orderG)
        {
            var firstItem = orderG.First();
            return new()
            {
                DueDate = firstItem.DueDate,
                EmployeeName = firstItem.EmployeeKeyNavigation.FirstName + " " +
                               firstItem.EmployeeKeyNavigation.MiddleName + " " +
                               firstItem.EmployeeKeyNavigation.LastName,
                EmployeeTitle = firstItem.EmployeeKeyNavigation.Title,
                OrderDate = firstItem.OrderDate,
                OrderNumber = firstItem.SalesOrderNumber,
                ShipDate = firstItem.ShipDate,
                TotalSalesAmount = orderG.Sum(order => order.SalesAmount),
                ResellerOrderProducts = orderG.Select(order => new ResellerOrderProduct
                {
                    Count = order.OrderQuantity,
                    SalesAmount = order.SalesAmount,
                    Currency = order.CurrencyKeyNavigation.CurrencyAlternateKey,
                    ProductCode = order.ProductKeyNavigation.ProductAlternateKey,
                    ProductName = order.ProductKeyNavigation.EnglishProductName,
                    TrackingNumber = order.CarrierTrackingNumber
                }).ToArray()
            };
        }
    }
}