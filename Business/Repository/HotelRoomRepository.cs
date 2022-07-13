using AutoMapper;
using Business.Repository.IRepository;
using DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Business.Repository
{
    public class HotelRoomRepository : IHotelRoomRepository
    {

        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;

        public HotelRoomRepository(ApplicationDbContext db, IMapper mapper)
        {
            _mapper = mapper;
            _db = db;
        }

        public async Task<HotelRoomDto> CreateHotelRoom(HotelRoomDto hotelRoomDTO)
        {
            HotelRoom hotelRoom = _mapper.Map<HotelRoomDto, HotelRoom>(hotelRoomDTO);
            hotelRoom.CreatedDate = DateTime.Now;
            hotelRoom.CreatedBy = "";
            var addedHotelRoom = await _db.HotelRooms.AddAsync(hotelRoom);
            await _db.SaveChangesAsync();

            return _mapper.Map<HotelRoom, HotelRoomDto>(addedHotelRoom.Entity);
        }

        public async Task<HotelRoomDto> UpdateHotelRoom(int roomId, HotelRoomDto hotelRoomDTO)
        {
            try
            {

                if (roomId == hotelRoomDTO.Id)
                {
                    HotelRoom roomDetails = await _db.HotelRooms.FindAsync(roomId);
                    HotelRoom room = _mapper.Map<HotelRoomDto, HotelRoom>(hotelRoomDTO, roomDetails);
                    room.UpdatedBy = "";
                    room.UpdatedDate = DateTime.Now;
                    var updatedRoom = _db.HotelRooms.Update(room);
                    await _db.SaveChangesAsync();
                    return _mapper.Map<HotelRoom, HotelRoomDto>(updatedRoom.Entity);
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<HotelRoomDto> GetHotelRoom(int roomId)
        {

            try
            {
                HotelRoomDto hotelRoom = _mapper.Map<HotelRoom, HotelRoomDto>
                    (await _db.HotelRooms.FirstOrDefaultAsync(item => item.Id == roomId));

                return hotelRoom;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<int> DeleteHotelRoom(int roomId)
        {
            var roomDetails = await _db.HotelRooms.FindAsync(roomId);
            if (roomDetails != null)
            {
                _db.HotelRooms.Remove(roomDetails);
                return await _db.SaveChangesAsync();
            }

            return 0;
        }

        public async Task<IEnumerable<HotelRoomDto>> GetAllHotelRooms()
        {
            try
            {
                IEnumerable<HotelRoomDto> hotelRoomDtos =
                    _mapper.Map<IEnumerable<HotelRoom>, IEnumerable<HotelRoomDto>>(_db.HotelRooms);
                return hotelRoomDtos;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        // If Room Name is unique, return null, else returns the room object.
        public async Task<HotelRoomDto> DuplicateRoomNameCheck(string name)
        {
            try
            {
                HotelRoomDto hotelRoom =
                    _mapper.Map<HotelRoom, HotelRoomDto>(
                        await _db.HotelRooms.FirstOrDefaultAsync(item =>
                            item.Name.ToLower() == name.ToLower()));

                return hotelRoom;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
