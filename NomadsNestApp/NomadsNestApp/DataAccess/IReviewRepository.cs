using System;
using NomadsNestApp.Models;

namespace NomadsNestApp.DataAccess
{
	public interface IReviewRepository
	{
		void Insert(Review review);
		IEnumerable<Review> GetAll();
		Review GetById(int id);
		void Update(Review review);
		void Delete(int id);
	}
}

