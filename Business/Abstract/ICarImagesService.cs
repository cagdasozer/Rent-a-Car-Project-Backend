using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
	public interface ICarImagesService
	{
		IDataResult<List<CarImages>> GetAll();

		IDataResult<CarImages> GetByCarId(int carImagesId);

		IResult Add(CarImages carImages);

		IResult Delete(CarImages carImages);

		IResult Update(CarImages carImages);
	}
}
