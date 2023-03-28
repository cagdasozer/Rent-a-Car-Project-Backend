using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
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
	public class UserManager : IUserService
	{
		IUserDal _userDal;

		public UserManager(IUserDal userDal)
		{
			_userDal = userDal;
		}

		//[SecuredOperation("admin")]
		public List<OperationClaim> GetClaims(User user)
		{
			return _userDal.GetClaims(user);
		}

		//[SecuredOperation("admin,moderator")]
		public User GetByMail(string email)
		{
			return _userDal.Get(u => u.Email == email);
		}

		//[SecuredOperation("admin,moderator")]
		public IDataResult<List<User>> GetAll()
		{
			return new SuccessDataResult<List<User>>(_userDal.GetAll(), Messages.UsersListed);
		}

		//[SecuredOperation("admin,moderator")]
		[ValidationAspect(typeof(UserValidator))]
		public void Add(User user)
		{
			_userDal.Add(user);
			new SuccessResult(Messages.UserAdded);
		}

		//[SecuredOperation("admin")]
		public IResult Update(User user)
		{
			_userDal.Update(user);
			return new SuccessResult(Messages.UserUpdated);
		}

		//[SecuredOperation("admin")]
		public IResult Delete(int id)
		{
			var delete = _userDal.Get(u => u.Id == id);
			if (delete != null)
			{
				_userDal.Delete(delete);
				return new SuccessResult(Messages.UserDeleted);
			}
			return new ErrorResult(Messages.UserNotFound);
			
		}
	}
}
