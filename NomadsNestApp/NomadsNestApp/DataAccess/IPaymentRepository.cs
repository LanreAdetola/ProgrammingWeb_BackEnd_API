using System;
using NomadsNestApp.Models;

namespace NomadsNestApp.DataAccess
{
	public interface IPaymentRepository
	{
        void Insert(Payment payment);
        IEnumerable<Payment> GetAll();
        Payment GetById(int id);
        void Update(Payment payment);
        void Delete(int id);
    }
}

