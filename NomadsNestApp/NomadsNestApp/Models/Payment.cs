using System;
using NomadsNestApp.Models;


namespace NomadsNestApp.Models
{
	public class Payment
	{
        public int Id { get; set; } 
        public int BookingId { get; set; } 
        public decimal Amount { get; set; } 
        public string Currency { get; set; } = "";
        public string PaymentMethod { get; set; } = "";
        public string Status { get; set; } = "";
        public DateTime Timestamp { get; set; } 

        // Relationships
        public Booking Booking { get; set; } = new Booking(); // Many-to-one relationship with Booking
    }

}

