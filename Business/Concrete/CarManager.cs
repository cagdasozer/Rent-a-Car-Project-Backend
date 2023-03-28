using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
		[ValidationAspect(typeof(CarValidator))]
		public IResult Add(Car car)
		{
			_carDal.Add(car);
			return new SuccessResult(Messages.CarAdded);
		}

		//[SecuredOperation("admin,moderator")]
		public IResult Delete(Car car)
		{
			_carDal.Delete(car);
			return new SuccessResult(Messages.CarDeleted);
		}

		//[SecuredOperation("admin,moderator")]
		public IDataResult<List<Car>> GetAll()
		{
			return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.CarsListed);
		}

		//[SecuredOperation("admin,moderator,customer")]
		public IDataResult<List<CarDetailDto>> GetCarDetails()
		{
			return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(), Messages.CarsListed);
		}

		//[SecuredOperation("admin,moderator,customer")]
		public IDataResult<List<Car>> GetCarsByBrandId(int brandId)
		{
			return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.BrandId == brandId), Messages.CarsListed);
		}

		//[SecuredOperation("admin,moderator,customer")]
		public IDataResult<List<Car>> GetCarsByColorId(int colorId)
		{
			return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ColorId == colorId), Messages.CarsListed);
		}

		//[SecuredOperation("admin,moderator,customer")]
		public IDataResult<List<Car>> GetCarsById(int carId)
		{
			return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.Id == carId), Messages.CarsListed);
		}

		public IDataResult<List<CarDetailDto>> GetCarDetailsByCarId(int carId)
		{
			return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetailsByCarId(carId), Messages.Listed);
		}

		public IDataResult<List<CarDetailDto>> GetCarDetailsByColorId(int colorId)
		{
			return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetailsByColorId(colorId), Messages.Listed);
		}

		public IDataResult<List<CarDetailDto>> GetCarDetailsByBrandId(int brandId)
		{
			return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetailsByBrandId(brandId), Messages.Listed);
		}

		//[SecuredOperation("admin,moderator")]
		public IResult Update(Car car)
		{
			_carDal.Update(car);
			return new SuccessResult(Messages.CarUpdated);
		}
	}
}
