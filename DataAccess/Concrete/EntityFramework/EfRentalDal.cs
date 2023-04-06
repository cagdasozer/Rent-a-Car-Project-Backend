using Core.DataAccess.EntityFtamework;
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
	public class EfRentalDal : EfEntityRepositoryBase<Rental, ReCarContext>, IRentalDal
	{
		public List<RentalDetailDto> GetRentalDetails()
		{
			throw new NotImplementedException();
		}

		public List<RentalDetailDto> GetRentalsDetails()
		{
			using (ReCarContext context = new ReCarContext())
			{
				var result = from rental in context.Rentals
							 join car in context.Cars on rental.CarId equals car.Id
							 join brand in context.Brands on car.BrandId equals brand.Id
							 join customer in context.Customers on rental.CustomerId equals customer.Id
							 join user in context.Users on customer.UserId equals user.Id
							 select new RentalDetailDto
							 {
								 Id = rental.Id,
								 BrandName = brand.BrandName,
								 FirstName = user.FirstName,
								 LastName = user.LastName,
								 RentDate = rental.RentDate,
								 ReturnDate = rental.ReturnDate
							 };
				return result.ToList();
			}
		}
	}
}
