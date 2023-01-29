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
		ICarImagesService _carImagesService;

		public CarImagesController(ICarImagesService carImagesService)
		{
			_carImagesService = carImagesService;
		}

		[HttpGet("GetAll")]
		public IActionResult GetAll()
		{
			var result = _carImagesService.GetAll();
			if (result.Success)
			{
				return Ok(result);
			}
			return BadRequest(result);
		}

		[HttpGet("GetByCarId")]
		public IActionResult GetByCarId(int carImagesId)
		{
			var result = _carImagesService.GetByCarId(carImagesId);
			if (result.Success)
			{
				return Ok(result);
			}
			return BadRequest(result);
		}

		[HttpPost("Add")]
		public IActionResult Add(CarImages carImages)
		{
			var result = _carImagesService.Add(carImages);
			if (result.Success)
			{
				return Ok(result);
			}
			return BadRequest(result);
		}

		[HttpPost("Delete")]
		public IActionResult Delete(CarImages carImages)
		{
			var result = _carImagesService.Delete(carImages);
			if (result.Success)
			{
				return Ok(result);
			}
			return BadRequest(result);
		}

		[HttpPost("Update")]
		public IActionResult Update(CarImages carImages)
		{
			var result = _carImagesService.Update(carImages);
			if (result.Success)
			{
				return Ok(result);
			}
			return BadRequest(result);
		}
	}
}
