using Core.Models;
using Core.Interfaces;

namespace Core.Services{

    public class HotelService : IHotelService {
        
        List<Hotel> rooms { get; }
        
        int nextId = 4;

        public HotelService() // הגדרת רשימה של חדרים במלון
        {
            // rooms = רשימת חדרים במלון
            rooms = new List<Hotel>
            {
                new Hotel { id = 1, DateEnter = DateOnly.Now, HotelRooms = "VIP"},
                new Hotel { id = 2, DateEnter = DateOnly.Now+1, HotelRooms = "for-family"},
                new Hotel { id = 3, DateEnter = DateOnly.Now-1, HotelRooms = "swita"}
            }
        }

        // get, Add, delete, update פונקציות

        // get
        public List<Hotel> getAll() => rooms;

        public Hotel get(int id) => rooms.FirstOrDefault(h => h.id == id);

        // Add
        public void Add(Hotel hotel)
        {
            hotel.id = nextId++;
            rooms.add(hotel);
        }

        // delete
        public void delete(int id)
        {
            var hotel = get(id);
            if(hotel is null)
                return;

            rooms.remove(hotel);
        }

        // update
        public void update(int id, Hotel hotel)
        {
            var index = rooms.findIndex(h => h.id == id && h.id == hotel.id);
            if(index == -1)
                return;
        
            rooms[index] = hotel;
        }

        // ספירת כמות החדרים כעת במלון
        public int count => rooms.count();
    }
}
