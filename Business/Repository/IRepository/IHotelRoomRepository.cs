using Models;

namespace Business.Repository.IRepository
{
    public interface IHotelRoomRepository
    {
        public Task<HotelRoomDto> CreateHotelRoom(HotelRoomDto hotelRoomDTO);
        public Task<HotelRoomDto> UpdateHotelRoom(int roomId, HotelRoomDto hotelRoomDTO);
        public Task<HotelRoomDto> GetHotelRoom(int roomId);
        public Task<int> DeleteHotelRoom(int roomId);
        public Task<IEnumerable<HotelRoomDto>> GetAllHotelRooms();
        public Task<HotelRoomDto> DuplicateRoomNameCheck(string name);
    }
}
