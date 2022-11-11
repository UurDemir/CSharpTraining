using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elastic.Terminal;

public class Product
{
    public double? base_price { get; set; }
    public int? discount_percentage { get; set; }
    public int? quantity { get; set; }
    public string manufacturer { get; set; }
    public int? tax_amount { get; set; }
    public int? product_id { get; set; }
    public string category { get; set; }
    public string sku { get; set; }
    public double? taxless_price { get; set; }
    public double? unit_discount_amount { get; set; }
    public double? min_price { get; set; }
    public string _id { get; set; }
    public double? discount_amount { get; set; }
    public DateTime created_on { get; set; }
    public string product_name { get; set; }
    public double? price { get; set; }
    public double? taxful_price { get; set; }
    public double? base_unit_price { get; set; }
}

public class Location
{
    public double? lon { get; set; }
    public double? lat { get; set; }
}

public class Geoip
{
    public string country_iso_code { get; set; }
    public Location location { get; set; }
    public string region_name { get; set; }
    public string continent_name { get; set; }
    public string city_name { get; set; }
}

public class Event
{
    public string dataset { get; set; }
}

public class Order
{
    public List<string> category { get; set; }
    public string currency { get; set; }
    public string customer_first_name { get; set; }
    public string customer_full_name { get; set; }
    public string customer_gender { get; set; }
    public int? customer_id { get; set; }
    public string customer_last_name { get; set; }
    public string customer_phone { get; set; }
    public string day_of_week { get; set; }
    public int? day_of_week_i { get; set; }
    public string email { get; set; }
    public List<string> manufacturer { get; set; }
    public DateTime order_date { get; set; }
    public int? order_id { get; set; }
    public List<Product> products { get; set; }
    public List<string> sku { get; set; }
    public double? taxful_total_price { get; set; }
    public double? taxless_total_price { get; set; }
    public int? total_quantity { get; set; }
    public int? total_unique_products { get; set; }
    public string type { get; set; }
    public string user { get; set; }
    public Geoip geoip { get; set; }
    public Event @event { get; set; }
}