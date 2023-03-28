using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
	public interface ICarService
	{
		IDataResult<List<Car>> GetAll();

		IDataResult<List<Car>> GetCarsByBrandId(int brandId);

		IDataResult<List<Car>> GetCarsByColorId(int colorId);

		IDataResult<List<CarDetailDto>> GetCarDetails();

		IDataResult<List<Car>> GetCarsById(int carId);

		IDataResult<List<CarDetailDto>> GetCarDetailsByBrandId(int brandId);

		IDataResult<List<CarDetailDto>> GetCarDetailsByColorId(int colorId);

		IDataResult<List<CarDetailDto>> GetCarDetailsByCarId(int carId);

		IResult Add(Car car);

		IResult Delete(Car car);

		IResult Update(Car car);
	}
}
