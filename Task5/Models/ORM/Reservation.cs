namespace Task5.Models.ORM
{
    public class Reservation:BaseModel
    {
        public DateTime ReservationDate { get; set; }
        public DateTime ReservationEndDate { get; set; }

        public int RoomId { get; set; }
        public Room Room { get; set; }

        public int ClientId { get; set; }
        public Client Client { get; set; }

    }
}
