using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
	public interface ICarImageService
	{
		IDataResult<List<CarImage>> GetAll();
		IDataResult<List<CarImage>> GetImagesByCarId(int carId);
		IDataResult<CarImage> GetByImageId(int carImageId);


		IResult Add(CarImage carImage, IFormFile file);
		IResult Delete(CarImage carImage, IFormFile file);
		IResult Update(CarImage carImage, IFormFile file);
	}
}
