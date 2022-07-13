using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class HotelRoomDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name cannot be blank")]
        public string Name { get; set; }
        [Required]
        [Range(1, 6, ErrorMessage = "Please Enter Occupancy value between 1 and 6")]
        public int Occupancy { get; set; }

        [Range(1, 3000, ErrorMessage = "Price must be within $1 and $3000.")]
        [Required]
        public double BaseRate { get; set; }

        public string Details { get; set; }

        public string RoomArea { get; set; }
    }
}
