﻿using Core.Utilities.Results;
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
		IDataResult<Car> GetById(int Id);
		IDataResult<List<CarDetailDto>> GetCarDetail();
		IDataResult<List<Car>> GetByDailyPrice(int min, int max);
		IDataResult<List<CarDetailDto>> GetCarDetailsByBrandId(int brandId);
		IDataResult<List<CarDetailDto>> GetCarDetailsByColorId(int colorId);
		IDataResult<CarDetailDto> GetCarDetailByCarId(int carId);
		IDataResult<List<Car>> GetCarsByFiltered(CarFilter carFilter);
		IDataResult<List<CarDetailDto>> GetCarDetailsByFiltered(CarFilter carFilter);

		IResult Add(Car car);
		IResult Delete(Car car);
		IResult Update(Car car);
	}
}
