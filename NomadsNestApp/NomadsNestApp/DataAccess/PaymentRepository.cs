﻿using LiteDB;
using NomadsNestApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NomadsNestApp.DataAccess
{
    public class PaymentRepository : IPaymentRepository
    {


        LiteDatabase db = new LiteDatabase(@"data.db");
        private const string _PAYMENTS = "Payments";

        public void Insert(Payment payment)
        {
            db.GetCollection<Payment>(_PAYMENTS).Insert(payment);
        }

        public IEnumerable<Payment> GetAll()
        {
            return db.GetCollection<Payment>(_PAYMENTS).FindAll();
        }

        public Payment GetById(int id)
        {
            return db.GetCollection<Payment>(_PAYMENTS).FindById(id);
        }

        public void Update(Payment payment)
        {
            db.GetCollection<Payment>(_PAYMENTS).Update(payment);
        }

        public void Delete(int id)
        {
            db.GetCollection<Payment>(_PAYMENTS).Delete(id);
        }

    }
}
