﻿using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CreditCardsController : ControllerBase
	{
		ICreditCardService _creditCardService;

		public CreditCardsController(ICreditCardService creditCardService)
		{
			_creditCardService = creditCardService;
		}

		[HttpPost("add")]
		public IActionResult Add(CreditCard creditCard)
		{
			var result = _creditCardService.Add(creditCard);
			if (result.Success)
			{
				return Ok(result);
			}
			return BadRequest(result);
		}

		[HttpPost("delete")]
		public IActionResult Delete(CreditCard creditCard)
		{
			var result = _creditCardService.Delete(creditCard);
			if (result.Success)
			{
				return Ok(result);
			}
			return BadRequest(result);
		}

		[HttpGet("getbycustomerid")]
		public IActionResult GetByCustomerId(int customerId)
		{
			var result = _creditCardService.GetByCustomerId(customerId);
			if (result.Success)
			{
				return Ok(result);
			}
			return BadRequest(result);
		}
	}
}
