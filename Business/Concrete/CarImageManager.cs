using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Helpers.FileHelper;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
	public class CarImageManager : ICarImageService
	{
		private const string DefaultCarImagePath = "/Uploads/DefaultImage.jpg";
		private ICarImageDal _carImageDal;
		private IFileHelper _fileHelper;

		public CarImageManager(ICarImageDal carImageDal, IFileHelper fileHelper)
		{
			_carImageDal = carImageDal;
			_fileHelper = fileHelper;
		}

		[ValidationAspect(typeof(CarImagesValidator))]
		public IResult Delete(CarImage carImages)
		{
			var result = BusinessRules.Run(IsCarExisted(carImages.Id));

			if (result != null)
			{
				return new ErrorResult(Messages.CarNotExisted);
			}

			_fileHelper.Delete(carImages.ImagePath);
			_carImageDal.Delete(carImages);
			return new SuccessResult(Messages.CarImageDeleted);
		}

		public IDataResult<CarImage> Get(Expression<Func<CarImage, bool>> filter)
		{
			return new SuccessDataResult<CarImage>(_carImageDal.Get(filter), Messages.SuccessfullyRetrieved);
		}

		public IDataResult<List<CarImage>> GetAll()
		{
			return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
		}

		public IDataResult<CarImage> GetById(int id)
		{
			return new SuccessDataResult<CarImage>(_carImageDal.Get(x => x.Id == id));
		}

		public IDataResult<List<CarImage>> GetByCarId(int carId)
		{

			return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(c => c.CarId == carId));
		}

		[ValidationAspect(typeof(CarImagesValidator))]
		public IResult Insert(IFormFile file, CarImage carImages)
		{
			var result = BusinessRules.Run(GetCarImagesLimitExceeded(carImages.CarId));

			if (result != null)
			{
				return result;
			}
			SetDefaultCarImageOrNot(file, carImages);
			_carImageDal.Add(carImages);
			return new SuccessResult(Messages.CarImageAdded);
		}

		[ValidationAspect(typeof(CarImagesValidator))]
		public IResult Update(IFormFile file, CarImage carImages)
		{
			UpdateImage(file, carImages);
			_carImageDal.Update(carImages);
			return new SuccessResult(Messages.CarImageUpdated);
		}

		//RULES
		private IResult GetCarImagesLimitExceeded(int carId)
		{
			var result = _carImageDal.GetAll(x => x.CarId == carId).Count();
			if (result >= 5)
			{
				return new ErrorResult(Messages.CarImagesLimitExceeded);
			}

			return new SuccessResult();
		}

		private void SetDefaultCarImageOrNot(IFormFile file, CarImage carImages)
		{
			if (file == null)
			{
				carImages.ImagePath = "/Uploads/Images/defaultImage.jpg";
			}
			else
			{
				var imageResult = _fileHelper.Upload(file);
				carImages.ImagePath = imageResult.Message;
			}
		}

		private void UpdateImage(IFormFile file, CarImage carImages)
		{
			var result = _carImageDal.GetAll().Single(x => x.Id == carImages.Id).ImagePath;


			if (carImages.ImagePath == DefaultCarImagePath && file != null)
			{
				var imageResult = _fileHelper.Upload(file);
				carImages.ImagePath = imageResult.Message;
			}
			else if (file == null && result == DefaultCarImagePath)
			{
				carImages.ImagePath = "/Uploads/DefaultImage.jpg";
			}
			else if (file == null && result != DefaultCarImagePath)
			{
				FileHelperManager fileHelper = new FileHelperManager();
				fileHelper.Delete(result);
				carImages.ImagePath = "/Uploads/DefaultImage.jpg";
			}
			else
			{
				var imageResult = _fileHelper.Update(file, carImages.ImagePath);
				carImages.ImagePath = imageResult.Message;
			}
		}

		public IResult IsCarExisted(int id)
		{
			var result = _carImageDal.GetAll(x => x.Id == id);
			if (result == null)
			{
				return new ErrorResult();
			}

			return new SuccessResult();
		}
	}
}
