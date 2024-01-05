namespace Task5.Models.DTOs
{
    public class ReservationDTO
    {
        public DateTime AddDate { get; set; }
        public DateTime ReservationDate { get; set; }
        public DateTime ReservationEndDate { get; set; }

        public int RoomId { get; set; }
        public int ClientId { get; set; }
    }
}
