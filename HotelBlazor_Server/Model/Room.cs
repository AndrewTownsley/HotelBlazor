namespace HotelBlazor_Server.Model
{
    public class Room
    {
        public int Id { get; set; }

        public string RoomName { get; set; }

        public double Price { get; set; }

        public bool IsBooked{ get; set; }

        public List<RoomProp> RoomProps { get; set; }

    }
}
