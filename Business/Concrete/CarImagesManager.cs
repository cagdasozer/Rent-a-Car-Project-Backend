using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
	public class CarImagesManager : ICarImagesService
	{
		ICarImagesDal _carImagesDal;

		public CarImagesManager(ICarImagesDal carImagesDal)
		{
			_carImagesDal = carImagesDal;
		}

		[ValidationAspect(typeof(CarImagesValidator))]
		public IResult Add(CarImages carImages)
		{
			_carImagesDal.Add(carImages);
			return new SuccessResult(Messages.CarImagesAdded);
		}

		public IResult Delete(CarImages carImages)
		{
			_carImagesDal.Delete(carImages);
			return new SuccessResult(Messages.CarImagesDeleted);
		}

		public IDataResult<List<CarImages>> GetAll()
		{
			return new SuccessDataResult<List<CarImages>>(_carImagesDal.GetAll(), Messages.CarImagesListed);
		}

		public IDataResult<CarImages> GetByCarId(int carImagesId)
		{
			return new SuccessDataResult<CarImages>(_carImagesDal.Get(cı => cı.CarId == carImagesId), Messages.CarImagesListed);
		}

		public IResult Update(CarImages carImages)
		{
			_carImagesDal.Update(carImages);
			return new SuccessResult(Messages.CarImagesUpdated);
		}
	}
}
