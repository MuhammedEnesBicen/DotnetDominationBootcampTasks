namespace Task4.Models
{
    public class WebUser :BaseModel
    {
        public string Email { get; set; }
        public string Adress { get; set; }
        public string Phone { get; set; }

        public List<Order> Orders { get; set; }
    }
}
