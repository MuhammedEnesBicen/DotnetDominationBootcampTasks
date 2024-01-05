namespace Task5.Models.DTOs
{
    public class ClientDTO
    {
        public DateTime AddDate { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime BirthDate { get; set; }
        public string Address { get; set; }
        public string EMail { get; set; }

        public int CompanyId { get; set; }
    }
}
