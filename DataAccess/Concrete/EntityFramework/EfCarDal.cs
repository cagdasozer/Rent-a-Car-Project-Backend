using Core.DataAccess.EntityFtamework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
	public class EfCarDal : EfEntityRepositoryBase<Car, ReCarContext>, ICarDal
	{
		public List<CarDetailDto> GetCarDetails()
		{
			using (ReCarContext context = new ReCarContext())
			{
				var result = from c in context.Cars
							 join b in context.Brands on c.BrandId equals b.Id
							 join a in context.Colors on c.ColorId equals a.Id
							 select new CarDetailDto
							 {
								 Id = c.Id,
								 BrandId = b.Id,
								 ColorId = a.Id,
								 CarName = c.CarName,
								 BrandName = b.BrandName,
								 ColorName = a.ColorName,
								 ModelYear = c.ModelYear,
								 DailyPrice = c.DailyPrice,
								 Description = c.Description,
							 };
				return result.ToList();
			}
		}
	}
}
