﻿using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
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

		[ValidationAspect(typeof(UserValidator))]
		public void Add(User user)
		{
			_userDal.Add(user);
		}

		public IResult Delete(User user)
		{
			_userDal.Delete(user);
			return new SuccessResult(Messages.UserDeleted);
		}

		public IDataResult<List<User>> GetAll()
		{
			return new SuccessDataResult<List<User>>(_userDal.GetAll(), Messages.UsersListed);
		}

		public User GetByEmail(string email)
		{
			return _userDal.Get(u => u.Email == email);
		}

		public IDataResult<User> GetByUserId(int id)
		{
			return new SuccessDataResult<User>(_userDal.Get(u => u.Id == id));
		}

		public List<OperationClaim> GetClaims(User user)
		{
			return _userDal.GetClaims(user);
		}

		public IDataResult<List<OperationClaim>> GetClaimsByUserId(int userId)
		{
			User user = _userDal.Get(u => u.Id == userId);
			return new SuccessDataResult<List<OperationClaim>>(_userDal.GetClaims(user));
		}

		public IDataResult<UserDetailDto> GetUserDetailsByEmail(string email)
		{
			return new SuccessDataResult<UserDetailDto>(_userDal.GetUserDetailsByEmail(email));
		}

		[ValidationAspect(typeof(UserValidator))]
		public IResult Update(UserUpdateDto userUpdateDto)
		{
			var userForUpdate = GetByUserId(userUpdateDto.Id).Data;
			userForUpdate.FirstName = userUpdateDto.FirstName;
			userForUpdate.LastName = userUpdateDto.LastName;
			userForUpdate.Email = userUpdateDto.Email;
			_userDal.Update(userForUpdate);
			return new SuccessResult();
		}
	}
}
