using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Helper.FileHelper;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.IO;
using Business.Constants;

namespace Business.Concrete
{
	public class CarImageManager : ICarImageService
	{
		ICarImageDal _carImageDal;
		IFileHelper _fileHelper;

		public CarImageManager(ICarImageDal carImageDal, IFileHelper fileHelper)
		{
			_carImageDal = carImageDal;
			_fileHelper = fileHelper;
		}

		[ValidationAspect(typeof(CarImagesValidator))]
		public IResult Add(CarImage carImage, IFormFile file)
		{
			IResult result = BusinessRules.Run(CheckIfCarImageLimit(carImage.CarId));
			if (result != null)
			{
				return result;
			}
			carImage.ImagePath = _fileHelper.Add(file, PathConstants.ImagesPath);
			carImage.Date = DateTime.Now;
			_carImageDal.Add(carImage);
			return new SuccessResult(Messages.CarImagesAdded);
		}

		public IResult Delete(CarImage carImage, IFormFile file)
		{
			_fileHelper.Delete(PathConstants.ImagesPath + carImage.ImagePath);

			_carImageDal.Delete(carImage);
			return new SuccessResult(Messages.CarImagesDeleted);
		}

		public IResult Update(CarImage carImage, IFormFile file)
		{
			carImage.ImagePath = _fileHelper.Update(file, PathConstants.ImagesPath + carImage.ImagePath, PathConstants.ImagesPath);

			_carImageDal.Update(carImage);
			return new SuccessResult(Messages.CarImagesUpdated);
		}

		public IDataResult<List<CarImage>> GetAll()
		{
			return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(), Messages.CarImagesListed);
		}

		public IDataResult<CarImage> GetByImageId(int carImageId)
		{
			return new SuccessDataResult<CarImage>(_carImageDal.Get(c => c.Id == carImageId));
		}

		public IDataResult<List<CarImage>> GetImagesByCarId(int carId)
		{
			var result = BusinessRules.Run(CheckIfCarImage(carId));
			if (result != null)
			{
				return new ErrorDataResult<List<CarImage>>(GetDefaultImage(carId).Data);
			}

			return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(cI => cI.CarId == carId), Messages.CarImagesListed);
		}



		private IResult CheckIfCarImageLimit(int carId)
		{
			var result = _carImageDal.GetAll(c => c.CarId == carId).Count;
			if (result > 5)
			{
				return new ErrorResult();
			}
			return new SuccessResult();
		}

		private IResult CheckIfCarImage(int carId)
		{
			var result = _carImageDal.GetAll(c => c.CarId == carId).Count;
			if (result > 0)
			{
				return new SuccessResult();
			}
			return new ErrorResult();
		}

		private IDataResult<List<CarImage>> GetDefaultImage(int carId)
		{
			List<CarImage> carImage = new List<CarImage>();
			carImage.Add(new CarImage { CarId = carId, Date = DateTime.Now, ImagePath = "DefaultImage.jpg" });
			return new SuccessDataResult<List<CarImage>>(carImage);
		}
	}
}
