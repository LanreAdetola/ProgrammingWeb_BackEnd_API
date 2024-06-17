using NomadsNestApp.Models;

namespace NomadsNestApp.DataAccess
{
    public interface IBookingRepository
    {
        void Insert(Booking booking);
        IEnumerable<Booking> GetAll();
        Booking GetById(int id);
        void Update(Booking booking);
        void Delete(int id);
        
    }
}
