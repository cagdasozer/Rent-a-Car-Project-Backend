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
    public class CustomerManager : ICustomerService
	{
		ICustomerDal _customerDal;

		public CustomerManager(ICustomerDal customerDal)
		{
			_customerDal = customerDal;
		}

		//[SecuredOperation("admin")]
		[ValidationAspect(typeof(CustomerValidator))]
		public IResult Add(Customer customer)
		{
			_customerDal.Add(customer);
			return new SuccessResult(Messages.CustomerAdded);
		}

		//[SecuredOperation("admin")]
		public IResult Delete(Customer customer)
		{
			_customerDal.Delete(customer);
			return new SuccessResult(Messages.CustomerDeleted);
		}

		//[SecuredOperation("admin,moderator")]
		public IDataResult<List<Customer>> GetAll()
		{
			return new SuccessDataResult<List<Customer>>(_customerDal.GetAll(), Messages.CustomersListed);
		}
		//[SecuredOperation("admin")]
		public IResult Update(Customer customer)
		{
			_customerDal.Update(customer);
			return new SuccessResult(Messages.CustomerUpdated);
		}
	}
}
