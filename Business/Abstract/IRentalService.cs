﻿using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
	public interface IRentalService
	{
		IDataResult<List<Rental>> GetAll();
		IDataResult<List<RentalDetailDto>> GetRentalDetails();
		IResult RulesForAdding(Rental rental);

		IResult Add(Rental rental);
		IResult Delete(Rental rental);
		IResult Update(Rental rental);
	}
}
