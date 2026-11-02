using Core.Models;

namespace Core.Interfaces; // לבדוק אם אפשר לשים בסוף השורה נקודה ופסיק או שצריך להיות בסוף השורה סוגריים מסולסלים

public interface IHotel
{
    // List<Hotel> GetAll(); ? IEnumerable האם לכתוב ככה - כמו שהמורה כתבה או לכתוב עם

    IEnumerable<Hotel> Get();

    Hotel Get(int id);

    void Add(Hotel hotel);

    void Update(int id, Hotel hotel);
    
    void Delete(int id);

    int Count { get; }
}

// אינטרפייס שמגדיר את כל הפונקציות שיתבצעו על התוכנית