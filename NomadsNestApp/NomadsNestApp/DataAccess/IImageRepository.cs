using System;
using NomadsNestApp.Models;

namespace NomadsNestApp.DataAccess
{
	public interface IImageRepository
	{
		void Insert(Image image);
		IEnumerable<Image> GetAll();
		Image GetById(int id);
		void Update(Image image);
		void Delete(int id);

	}
}

