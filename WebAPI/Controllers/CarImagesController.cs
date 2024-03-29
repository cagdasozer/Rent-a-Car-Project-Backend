﻿using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Runtime.ConstrainedExecution;


namespace WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CarImagesController : ControllerBase
	{
		ICarImageService _carImageService;

		public CarImagesController(ICarImageService carImageService)
		{
			_carImageService = carImageService;
		}

		[HttpPost("add")]
		public IActionResult Add([FromForm(Name = ("Image"))] IFormFile file, [FromForm] CarImage carImage)
		{
			var result = _carImageService.Add(file, carImage);
			if (result.Success)
			{
				return Ok(result);
			}
			return BadRequest(result);
		}

		[HttpPost("delete")]
		public IActionResult Delete([FromForm(Name = ("carImageId"))] int carImageId)
		{

			var deleteCarImageByCarId = _carImageService.Get(carImageId).Data;
			var result = _carImageService.Delete(deleteCarImageByCarId);

			if (result.Success)
			{
				return Ok(result);
			}
			return BadRequest(result);
		}

		[HttpPost("updateimage")]
		public IActionResult Update([FromForm(Name = "Image")] IFormFile file, [FromForm] CarImage carImage)
		{
			var result = _carImageService.Update(file, carImage);
			if (result.Success)
			{
				return Ok(result);
			}
			return BadRequest(result);

		}

		[HttpGet("getall")]
		public IActionResult GetAll()
		{
			var result = _carImageService.GetAll();
			if (result.Success)
			{
				return Ok(result);
			}
			return BadRequest(result);
		}

		[HttpGet("getbycarid")]
		public IActionResult GetByCarId(int carId)
		{
			var result = _carImageService.GetImagesByCarId(carId);
			if (result.Success)
			{
				return Ok(result);
			}
			return Ok(result);
		}
	}
}
