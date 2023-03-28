using Business.Abstract;
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
		private static string _currentDirectory = Environment.CurrentDirectory + "\\wwwroot";
		private static string _folderName = "\\Uploads\\DefaultImage.jpg";
		private string _defaultPath = _currentDirectory + _folderName;

		ICarImageService _carImageService;

		public CarImagesController(ICarImageService serviceBase)
		{
			_carImageService = serviceBase;
		}

		[HttpGet("GetAll")]
		public IActionResult GetAll()
		{
			var result = _carImageService.GetAll();
			if (result.Success)
			{
				return Ok(result);
			}
			return BadRequest(result);

		}

		[HttpGet("GetById")]
		public IActionResult GetById(int id)
		{
			var result = _carImageService.GetById(id);

			if (result.Success)
			{
				return Ok(result.Data);
			}
			return BadRequest(result);
		}

		[HttpGet("GetByCarId")]
		public IActionResult GetByCarId(int carId)
		{
			var result = _carImageService.GetByCarId(carId);
			if (result.Success)
			{
				return Ok(result);
			}
			return BadRequest(result);
		}

		[HttpPost("Add")]
		public IActionResult Add([FromForm(Name = "Image")] IFormFile file, [FromForm] CarImage carImage)
		{
			var result = _carImageService.Insert(file, carImage);
			if (result.Success)
			{
				return Ok(result);
			}
			return BadRequest(result);
		}

		[HttpPost("Update")]
		public IActionResult Update([FromForm(Name = "Image")] IFormFile file, [FromForm] CarImage carImage)
		{
			var result = _carImageService.Update(file, carImage);
			if (result.Success)
			{
				return Ok(result);
			}

			return BadRequest(result);
		}

		[HttpPost("delete")]
		public IActionResult Delete([FromForm] int id)
		{
			var entity = _carImageService.GetById(id);
			var result = _carImageService.Delete(entity.Data);
			if (result.Success)
			{
				return Ok(result);
			}

			return BadRequest(result);
		}
	}
}
