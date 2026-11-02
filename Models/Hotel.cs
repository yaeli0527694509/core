namespace Core.Models;

public class Hotel
{
    public int Id { get; set; }

    public DateOnly DateEnter { get; set; }

    public DateOnly DateExit { get; set; }

    public static int PriceForNight = 100; // Example price per night

    // ?האם את הפונקציה הזו צריך להגדיר פה או באינטרפייס שממש את כל הפונקציות
    public int TotalPrice => (DateExit.DayNumber - DateEnter.DayNumber) * PriceForNight;
   
    public string? HotelRooms { get; set; }
}
// מאפייני החדרים במלון