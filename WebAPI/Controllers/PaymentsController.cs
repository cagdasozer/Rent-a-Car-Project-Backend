﻿using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PaymentsController : ControllerBase
	{
		IPaymentService _paymentService;

		public PaymentsController(IPaymentService paymentService	)
		{
			_paymentService = paymentService;
		}

		[HttpPost("add")]
		public IActionResult Add(Payment payment)
		{
			var result = _paymentService.Pay(payment);
			if (result.Success)
			{
				return Ok(result);
			}
			return BadRequest(result);
		}
	}
}
