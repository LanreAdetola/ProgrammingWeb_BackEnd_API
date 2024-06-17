using NomadsNestApp.Models;
using System.Collections.Generic;

namespace NomadsNestApp.DataAccess
{
    public interface IAmenityRepository
    {
        void Insert(Amenity amenity);
        IEnumerable<Amenity> GetAll();
        Amenity GetById(int id);
        void Update(Amenity amenity);
        void Delete(int id);
    }


}
