﻿using Core.Utilities.Results;
using Core.Utilities.Security.JWT;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
	public interface IAuthService
	{
		IDataResult<User> Register(UserForRegisterDto userForRegisterDto, string password);
		IDataResult<User> Login(UserForLoginDto userForLoginDto);
		IDataResult<User> UpdatePassword(UserForPasswordDto userForPasswordDto, string password);
		IResult UserExists(string email);
		IDataResult<AccessToken> CreateAccessToken(User user);
	}
}
