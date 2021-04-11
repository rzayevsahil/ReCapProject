using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        IPaymentService _paymentService;

        public PaymentsController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }


        [HttpPost("add")]
        public IActionResult Add(Payment payment)
        {
            var result = _paymentService.Add(payment);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPut("update")]
        public IActionResult Update(Payment payment)
        {
            var result = _paymentService.Update(payment);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(Payment payment)
        {
            var result = _paymentService.Delete(payment);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _paymentService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _paymentService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbycustomerid")]
        public IActionResult GetByCustomerId(int customerId)
        {
            var result = _paymentService.GetByCustomerId(customerId);
            if (!result.Success)
            {
                return BadRequest(result);
            } 
            return Ok(result);
        }

        [HttpGet("getbycardnumber")]
        public IActionResult GetByCardNumber(string cardNumber)
        {
            var result = _paymentService.GetByCardNumber(cardNumber);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("verifycard")]
        public IActionResult VerifyCard(Payment card)
        {
            var result = _paymentService.VerifyCard(card);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        //[HttpPost("iscardexist")]
        //public IActionResult IsCardExist(Payment payment)
        //{
        //    var result = _paymentService.IsCardExist(payment);
        //    if (result.Success)
        //    {
        //        return Ok(result);
        //    }
        //    return Ok(result);
        //}
    }
}
