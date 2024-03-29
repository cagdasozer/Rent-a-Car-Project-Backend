﻿using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
	public class CarManager : ICarService
	{
		ICarDal _carDal;

		public CarManager(ICarDal carDal)
		{
			_carDal = carDal;
		}


		[ValidationAspect(typeof(CarValidator))]
		[CacheRemoveAspect("ICarService.Get")]
		public IResult Add(Car car)
		{
			_carDal.Add(car);
			return new SuccessResult(Messages.CarAdded);
		}

		public IResult Delete(Car car)
		{
			_carDal.Delete(car);
			return new SuccessResult();
		}

		public IDataResult<List<Car>> GetAll()
		{
			return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.CarsListed);
		}

		public IDataResult<List<Car>> GetByDailyPrice(int min, int max)
		{
			return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.DailyPrice < max && p.DailyPrice > min));
		}

		public IDataResult<Car> GetById(int Id)
		{
			return new SuccessDataResult<Car>(_carDal.Get(p => p.Id == Id));
		}

		public IDataResult<List<CarDetailDto>> GetCarDetail()
		{
			return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetail());
		}

		public IDataResult<CarDetailDto> GetCarDetailByCarId(int carId)
		{
			return new SuccessDataResult<CarDetailDto>(_carDal.GetCarDetail().Where(c => c.Id == carId).FirstOrDefault());
		}

		public IDataResult<List<CarDetailDto>> GetCarDetailsByBrandId(int brandId)
		{
			return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetail().Where(cd => cd.BrandId == brandId).ToList());
		}

		public IDataResult<List<CarDetailDto>> GetCarDetailsByColorId(int colorId)
		{
			return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetail().Where(cd => cd.ColorId == colorId).ToList());
		}

		public IDataResult<List<CarDetailDto>> GetCarDetailsByFiltered(CarFilter carFilter)
		{
			return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetail().Where(cd => cd.BrandId == carFilter.BrandId && cd.ColorId == carFilter.ColorId).ToList());
		}

		public IDataResult<List<Car>> GetCarsByFiltered(CarFilter carFilter)
		{
			return new SuccessDataResult<List<Car>>(_carDal.GetAll().Where(c => c.BrandId == carFilter.BrandId && c.ColorId == carFilter.ColorId).ToList());
		}

		[ValidationAspect(typeof(CarValidator))]
		public IResult Update(Car car)
		{
			_carDal.Update(car);
			return new SuccessResult();
		}
	}
}
