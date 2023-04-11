using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
	public class FindeksScoreManager : IFindeksScoreService
	{
		IFindeksScoreDal _findeksScoreDal;

		public FindeksScoreManager(IFindeksScoreDal findeksScoreDal)
		{
			_findeksScoreDal = findeksScoreDal;
		}

		public IResult Add(FindeksScore findeksScore)
		{
			_findeksScoreDal.Add(findeksScore);
			return new SuccessResult(Messages.FindeksScoreAdded);
		}

		public IResult Delete(FindeksScore findeksScore)
		{
			_findeksScoreDal.Delete(findeksScore);
			return new SuccessResult(Messages.FindeksScoreDeleted);
		}

		public IDataResult<FindeksScore> GetByCustomerId(int customerId)
		{
			return new SuccessDataResult<FindeksScore>(_findeksScoreDal.Get(fc => fc.CustomerId == customerId));
		}

		public IResult Update(FindeksScore findeksScore)
		{
			_findeksScoreDal.Update(findeksScore);
			return new SuccessResult(Messages.FindeksScoreUpdated);
		}
	}
}
