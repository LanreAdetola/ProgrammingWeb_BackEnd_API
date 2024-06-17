using LiteDB;
using NomadsNestApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NomadsNestApp.DataAccess
{
    public class AmenityRepository : IAmenityRepository
    {
        

    
        LiteDatabase db = new LiteDatabase(@"data.db");
        private const string _AMENITYS = "Amenitys";

        

        public void Insert(Amenity amenity)
        {
            db.GetCollection<Amenity>(_AMENITYS).Insert(amenity);
        }

        public IEnumerable<Amenity> GetAll()
        {
            return db.GetCollection<Amenity>(_AMENITYS).FindAll();
        }

        public Amenity GetById(int id)
        {
            return db.GetCollection<Amenity>(_AMENITYS).FindById(id);
        }

        public void Update(Amenity amenity)
        {
            db.GetCollection<Amenity>(_AMENITYS).Update(amenity);
        }

        public void Delete(int id)
        {
            db.GetCollection<Amenity>(_AMENITYS).Delete(id);
        }

    }
}
