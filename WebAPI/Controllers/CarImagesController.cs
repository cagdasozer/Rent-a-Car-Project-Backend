using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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

		[HttpGet("GetImagesByCarId")]
		public IActionResult GetImagesByCarId(int carId)
		{
			var result = _carImageService.GetImagesByCarId(carId);
			if (result.Success)
			{
				return Ok(result);
			}
			return BadRequest(result);
		}

		[HttpGet("GetByImagesId")]
		public IActionResult GetByImagesId(int carImageId)
		{
			var result = _carImageService.GetByImageId(carImageId);
			if (result.Success)
			{
				return Ok(result);
			}
			return BadRequest(result);
		}

		[HttpPost("Add")]
		public IActionResult Add(CarImage carImage, FormFile fileForm)
		{
			var result = _carImageService.Add(carImage, fileForm);
			if (result.Success)
			{
				return Ok(result);
			}
			return BadRequest(result);
		}

		[HttpPost("Delete")]
		public IActionResult Delete(CarImage carImage, FormFile fileForm)
		{
			var result = _carImageService.Delete(carImage, fileForm);
			if (result.Success)
			{
				return Ok(result);
			}
			return BadRequest(result);
		}

		[HttpPost("Update")]
		public IActionResult Update(CarImage carImage, FormFile fileForm)
		{
			var result = _carImageService.Update(carImage, fileForm);
			if (result.Success)
			{
				return Ok(result);
			}
			return BadRequest(result);
		}
	}
}
