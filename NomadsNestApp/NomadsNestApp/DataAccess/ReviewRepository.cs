using LiteDB;
using NomadsNestApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NomadsNestApp.DataAccess
{
    public class ReviewRepository : IReviewRepository
    {
        LiteDatabase db = new LiteDatabase(@"data.db");
        private const string _REVIEWS = "Reviews";



        public void Insert(Review review)
        {
            db.GetCollection<Review>(_REVIEWS).Insert(review);
        }

        public IEnumerable<Review> GetAll()
        {
            return db.GetCollection<Review>(_REVIEWS).FindAll();
        }

        public Review GetById(int id)
        {
            return db.GetCollection<Review>(_REVIEWS).FindById(id);
        }

        public void Update(Review review)
        {
            db.GetCollection<Review>(_REVIEWS).Update(review);
        }

        public void Delete(int id)
        {
            db.GetCollection<Review>(_REVIEWS).Delete(id);
        }

        // Add more methods for querying, updating, and deleting reviews as needed
    }
}
