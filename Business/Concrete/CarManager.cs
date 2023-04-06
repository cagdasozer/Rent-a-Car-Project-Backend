using Business.Abstract;
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

		//[SecuredOperation("admin,moderator")]
		[CacheAspect]
		public IDataResult<List<Car>> GetAll()
		{
			return new SuccessDataResult<List<Car>>(_carDal.GetAll());
		}

		[CacheAspect]
		public IDataResult<Car> GetById(int carId)
		{
			return new SuccessDataResult<Car>(_carDal.Get(c => c.Id == carId));
		}

		//[SecuredOperation("admin")]
		[ValidationAspect(typeof(CarValidator))]
		[CacheRemoveAspect("ICarService.Get")]
		public IResult Add(Car car)
		{
			_carDal.Add(car);
			return new SuccessResult(Messages.CarAdded);
		}

		//[SecuredOperation("admin,moderator")]
		[CacheRemoveAspect("ICarService.Get")]
		public IResult Update(Car car)
		{
			_carDal.Update(car);
			return new SuccessResult(Messages.CarUpdated);
		}

		[CacheRemoveAspect("ICarService.Get")]
		public IResult Delete(Car car)
		{
			_carDal.Delete(car);
			return new SuccessResult(Messages.CarDeleted);
		}

		[CacheAspect]
		public IDataResult<List<Car>> GetByBrandId(int brandId)
		{
			return new SuccessDataResult<List<Car>>(_carDal.GetByBrandId(p => p.BrandId == brandId));
		}

		[CacheAspect]
		public IDataResult<List<CarDetailDto>> GetCarDetails()
		{
			return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails());
		}

		public IDataResult<List<CarDetailDto>> GetCarDetailsByBrandId(int brandId)
		{
			return new SuccessDataResult<List<CarDetailDto>>(
				_carDal.GetCarDetails().Where(c => c.BrandId == brandId).ToList());
		}

		public IDataResult<List<CarDetailDto>> GetCarDetailsByColorId(int colorId)
		{
			return new SuccessDataResult<List<CarDetailDto>>(
				_carDal.GetCarDetails().Where(c => c.ColorId == colorId).ToList());
		}

		public IDataResult<List<CarDetailDto>> GetCarDetailsByColorAndBrand(int brandId, int colorId)
		{
			return new SuccessDataResult<List<CarDetailDto>>(
				_carDal.GetCarDetails()
				.Where(c => c.BrandId == brandId && c.ColorId == colorId).ToList());
		}

		public IDataResult<CarDetailDto> GetCarDetailById(int carId)
		{
			return new SuccessDataResult<CarDetailDto>(
				_carDal.GetCarDetails().SingleOrDefault(c => c.Id == carId));
		}

		[TransactionScopeAspect]
		public IResult AddTransactionalTest(Car car)
		{
			throw new NotImplementedException();
		}
	}
}
