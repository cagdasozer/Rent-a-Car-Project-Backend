using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
	public interface IFindeksScoreService
	{
		IResult Add(FindeksScore findeksScore);
		IResult Update(FindeksScore findeksScore);
		IResult Delete(FindeksScore findeksScore);
		IDataResult<FindeksScore> GetByCustomerId(int customerId);
	}
}
