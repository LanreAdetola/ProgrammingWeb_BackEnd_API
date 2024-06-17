using Microsoft.AspNetCore.Mvc;
using NomadsNestApp.DataAccess;
using NomadsNestApp.Models;
using System;
using System.Collections.Generic;

namespace NomadsNestApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentRepository _paymentRepository;

        public PaymentController(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }

        // GET: api/Payment
        [HttpGet]
        public IActionResult Get()
        {
            var payments = _paymentRepository.GetAll();
            return Ok(payments);
        }

        // GET: api/Payment/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var payment = _paymentRepository.GetById(id);
            if (payment == null)
            {
                return NotFound();
            }
            return Ok(payment);
        }

        // POST: api/Payment
        [HttpPost]
        public IActionResult Post([FromBody] Payment payment)
        {
            _paymentRepository.Insert(payment);
            return CreatedAtAction(nameof(Get), new { id = payment.Id }, payment);
        }

        // PUT: api/Payment/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Payment payment)
        {
            if (id != payment.Id)
            {
                return BadRequest();
            }

            _paymentRepository.Update(payment);
            return NoContent();
        }

        // DELETE: api/Payment/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existingPayment = _paymentRepository.GetById(id);
            if (existingPayment == null)
            {
                return NotFound();
            }

            _paymentRepository.Delete(id);
            return NoContent();
        }
    }
}
