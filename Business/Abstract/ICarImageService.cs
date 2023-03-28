using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
	public interface ICarImageService
	{
		IResult Insert(IFormFile file, CarImage entity);
		IResult Update(IFormFile file, CarImage entity);
		IResult Delete(CarImage entity);

		IDataResult<List<CarImage>> GetAll();
		IDataResult<CarImage> Get(Expression<Func<CarImage, bool>> filter);
		IDataResult<CarImage> GetById(int id);
		IDataResult<List<CarImage>> GetByCarId(int carId);


	}
}
