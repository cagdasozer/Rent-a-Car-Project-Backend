using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
	public interface IUserService
	{
		List<OperationClaim> GetClaims(User user);

		User GetByMail(string email);

		IDataResult<List<User>> GetAll();		

		void Add(User user);

		IResult Update(User user);

		IResult Delete(int id);

	}
}
