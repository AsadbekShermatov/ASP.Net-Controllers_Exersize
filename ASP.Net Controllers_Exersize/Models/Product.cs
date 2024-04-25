namespace ASP.Net_Controllers_Exersize.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public Category Category { get; set; }
    }
}

