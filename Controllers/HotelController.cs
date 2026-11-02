using Microsoft.AspNetCore.Mvc;
using Core.Models;

namespace Core.Controllers;

[ApiController]
[Route("[controller]")]
public class HotelController : ControllerBase
{
    // סוגי חדרים הקיימים במלון
    private static readonly string[] HotelRooms =
    [
        "big-room", "for-family", "swita", "VIP"
    ];

    private static List<Hotel>? arr;
    
    public HotelController()
    {
        // הגדרת חדרים במלון עם תאריך כניסה, תאריך יציאה וסוג החדר. והכנסתם לתוך רשימה
        arr = Enumerable.Range(1, 5).Select(index => new Hotel
        {
            DateEnter = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            // לבדוק מה עם זה DateExit = DateEnter.AddDays(3),
            HotelRooms = HotelRooms[Random.Shared.Next(HotelRooms.Length)]
        }).ToList();
    }

    // get
    [HttpGet]
        public IEnumerable<Hotel> Get()
        {
            return arr;
        }

    [HttpGet("{id}")]
        public ActionResult<Hotel> Get(int id)
        {
            var hotel = HotelService.Get(id);
            if (hotel == null)
                return NotFound();
            return hotel;
        }

    // בפונקציה הזאת המשתמש מקבל את המחיר ללילה בהתאם לחדר שבו הוא שוהה
    // (כאשר כל חדר במערך עולה 100 ש"ח כפול המיקום שלו במערך)             
    [HttpGet("{PriceForNight}")]
        public int Get(int priceForNight, string hRoom)
        {
            for (int i = 0; i < HotelRooms.Length; i++)
            {
                if (HotelRooms[i] == hRoom)
                {
                    priceForNight *= (i + 1);
                }
            }
            return priceForNight;
        }

    // post
    [HttpPost]
        public IActionResult create(Hotel hotel)
        {
            HotelService.Add(hotel);
            return CreatedAtAction(nameof(Create), new {id=hotel.Id}, hotel);
        }

    // put
    [HttpPut("{id}")]
        public IActionResult Update(int id, Hotel hotel)
        {   
            if (id != hotel.Id)
                return BadRequest();

            var existingHotel = HotelService.Get(id);
            if (existingHotel == null)
                return  NotFound();
            
            HotelService.Update(id, hotel);
            return NoContent();
        }

    // delete
    [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var Hotel = HotelService.Get(id);
            if (Hotel is null)
                return NotFound();

            HotelService.Delete(id);
            return Content(HotelService.Count.ToString());
        }
}
