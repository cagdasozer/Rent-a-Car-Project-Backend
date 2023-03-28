using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CarsController : ControllerBase
	{
		ICarService _carService;

		public CarsController(ICarService carService)
		{
			_carService = carService;
		}

		[HttpGet("GetAll")] 
		public IActionResult GetAll()
		{
			Thread.Sleep(700);
			var result = _carService.GetAll();
			if (result.Success)
			{
				return Ok(result);
			}
			return BadRequest(result);
		}

		[HttpGet("GetCarsById")]
		public IActionResult GetCarsById(int carId)
		{
			var result = _carService.GetCarsById(carId);
			if (result.Success)
			{
				return Ok(result);
			}
			return BadRequest(result);
		}

		[HttpGet("GetCarsByBrandId")] 
		public IActionResult GetCarsByBrandId(int brandId) 
		{
			var result = _carService.GetCarsByBrandId(brandId);
			if (result.Success)
			{
				return Ok(result);
			}
			return BadRequest(result);
		}

		[HttpGet("GetCarsByColorId")]
		public IActionResult GetCarsByColorId(int colorId)
		{
			var result = _carService.GetCarsByColorId(colorId); 
			if (result.Success) 
			{
				return Ok(result);
			}
			return BadRequest(result);
		}

		[HttpGet("GetCarDetails")]
		public IActionResult GetCarDetails()
		{
			var result = _carService.GetCarDetails();
			if (result.Success)
			{
				return Ok();
			}
			return BadRequest(result);
		}

		[HttpGet("GetCarDetailsByBrandId")]
		public IActionResult GetCarDetailsByBrandId(int brandId)
		{
			var result = _carService.GetCarDetailsByBrandId(brandId);
			if (result.Success)
			{
				return Ok(result);
			}
			return BadRequest(result);
		}

		[HttpGet("GetCarDetailsByColorId")]
		public IActionResult GetCarDetailsByColorId(int colorId)
		{
			var result = _carService.GetCarDetailsByColorId(colorId);
			if (result.Success)
			{
				return Ok(result);
			}
			return BadRequest(result);
		}

		[HttpGet("GetCarDetailsByCarId")]
		public IActionResult GetCarDetailsByCarId(int carId)
		{
			var result = _carService.GetCarDetailsByCarId(carId);
			if (result.Success)
			{
				return Ok(result);
			}
			return BadRequest(result);
		}

		[HttpPost("Add")]
		public IActionResult Add(Car car)
		{
			var result = _carService.Add(car);
			if (result.Success) 
			{
				return Ok(result);
			}
			return BadRequest(result);
		}

		[HttpPost("Delete")]
		public IActionResult Delete(Car car)
		{
			var result = _carService.Delete(car);
			if (result.Success)
			{
				return Ok(result);
			}
			return BadRequest(result);
		}

		[HttpPost("Update")]
		public IActionResult Update(Car car)
		{
			var result = _carService.Update(car);
			if (result.Success)
			{
				return Ok(result);
			}
			return BadRequest(result);
		}
	}
}
