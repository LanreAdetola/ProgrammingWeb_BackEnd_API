using System;
using NomadsNestApp.Models;



namespace NomadsNestApp.DataAccess
{
	public interface ILocationRepository
	{
        void Insert(Location location);
        IEnumerable<Location> GetAll();
        Location GetById(int id);
        void Update(Location location);
        void Delete(int id);
    }
}

