using System;
using NomadsNestApp.Models;

namespace NomadsNestApp.DataAccess
{
	public interface ICampingSpotRepository
	{
        void Insert(CampingSpot campingSpot);
        IEnumerable<CampingSpot> GetAll();
        CampingSpot GetById(int id);
        void Update(CampingSpot campingSpot);
        void Delete(int id);


        IEnumerable<CampingSpot> GetByUserId(int userId);

    }
}

