namespace Task2.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float UnitPrice { get; set; }
        public Category Category { get; set; }

        public Product(int id,string name, float unitPrice,Category category)
        {
            Id = id;
            Name = name;
            UnitPrice = unitPrice;
            Category = category;
        }
    }
}
