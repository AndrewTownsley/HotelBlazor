using System.ComponentModel.DataAnnotations;

namespace DataAccess.Data
{
    public class HotelRoom
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Occupancy { get; set; }
        [Required]
        public double BaseRate { get; set; }

        public string? Details { get; set; }

        public string? RoomArea { get; set; }

        public string? CreatedBy { get; set; }

        public DateTime? CreatedDate { get; set; } = DateTime.Now;

        public string? UpdatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }

    }
}
