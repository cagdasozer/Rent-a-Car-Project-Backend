﻿using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class FindeksScoresController : ControllerBase
	{
		IFindeksScoreService _findeksScoreService;

		public FindeksScoresController(IFindeksScoreService findeksScoreService)
		{
			_findeksScoreService = findeksScoreService;
		}

		[HttpPost("add")]
		public IActionResult Add(FindeksScore findeksScore)
		{
			var result = _findeksScoreService.Add(findeksScore);
			if (result.Success)
			{
				return Ok(result);
			}
			return BadRequest(result);
		}

		[HttpPost("update")]
		public IActionResult Update(FindeksScore findeksScore)
		{
			var result = _findeksScoreService.Update(findeksScore);
			if (result.Success)
			{
				return Ok(result);
			}
			return BadRequest(result);
		}

		[HttpPost("delete")]
		public IActionResult Delete(FindeksScore findeksScore)
		{
			var result = _findeksScoreService.Delete(findeksScore);
			if (result.Success)
			{
				return Ok(result);
			}
			return BadRequest(result);
		}

		[HttpGet("getbycustomerid")]
		public IActionResult GetByCustomerId(int customerId)
		{
			var result = _findeksScoreService.GetByCustomerId(customerId);
			if (result.Success)
			{
				return Ok(result);
			}
			return BadRequest(result);
		}
	}
}
