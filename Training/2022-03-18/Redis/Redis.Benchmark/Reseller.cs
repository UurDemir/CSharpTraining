namespace Redis.Benchmark
{
    public class Reseller
    {
        public int ResellerKey { get; set; }
        public string ResellerCode { get; set; }
        public string Name { get; set; }
        public string BusinessType { get; set; }
        public string Phone { get; set; }
        public int EmployeeCount { get; set; }
        public string Address { get; set; }
        public string BankName { get; set; }
        public int OpenedYear { get; set; }

        public string City { get; set; }
        public string Country { get; set; }

        public ResellerOrder[] Orders { get; set; }
    }

    public class ResellerOrder
    {
        public string OrderNumber { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeTitle { get; set; }
        public DateTime? OrderDate { get; set; }
        public DateTime? DueDate { get; set; }
        public DateTime? ShipDate { get; set; }
        public decimal? TotalSalesAmount { get; set; }

        public ResellerOrderProduct[] ResellerOrderProducts { get; set; }
    }

    public class ResellerOrderProduct
    {
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public int? Count { get; set; }
        public decimal? SalesAmount { get; set; }
        public string TrackingNumber { get; set; }
        public string Currency { get; set; }
    }
}
