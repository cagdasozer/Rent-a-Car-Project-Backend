﻿using Core.DataAccess.EntityFtamework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
	public class EfUserDal : EfEntityRepositoryBase<User, ReCarContext>, IUserDal
	{
		public List<OperationClaim> GetClaims(User user)
		{
			using (var context = new ReCarContext())
			{
				var result = from operationClaim in context.OperationClaims
							 join userOperationClaim in context.UserOperationClaims
								 on operationClaim.Id equals userOperationClaim.OperationClaimId
							 where userOperationClaim.UserId == user.Id
							 select new OperationClaim { Id = operationClaim.Id, Name = operationClaim.Name };
				return result.ToList();

			}
		}

		public UserDetailDto GetUserDetailsByEmail(string email)
		{
			using (var context = new ReCarContext())
			{
				var result = from user in context.Users.Where(u => u.Email == email)
							 select new UserDetailDto
							 {
								 Id = user.Id,
								 FirstName = user.FirstName,
								 LastName = user.LastName,
								 Email = user.Email
							 };
				return result.FirstOrDefault();
			}
		}
	}
}
