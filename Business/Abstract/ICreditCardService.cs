﻿using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
	public interface ICreditCardService
	{
		IResult Add(CreditCard creditCard);
		IResult Delete(CreditCard creditCard);
		IResult Update(CreditCard creditCard);
		IDataResult<List<CreditCard>> GetAll();
		IDataResult<List<CreditCard>> GetByCustomerId(int customerId);
	}
}
