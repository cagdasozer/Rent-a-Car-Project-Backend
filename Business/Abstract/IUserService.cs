using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
	public interface IUserService
	{
		IDataResult<User> GetByEmailWithResult(string email);
		List<OperationClaim> GetClaims(User user);
		User GetByMail(string email);
		IDataResult<User> GetById(int userId);

		void Add(User user);
		IResult Update(User user);
		IResult UpdateUserNames(User user);
		IResult Delete(User user);
		IDataResult<List<User>> GetAll();
	}
}
