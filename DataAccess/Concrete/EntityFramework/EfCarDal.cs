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
				var result = from car in context.Cars
							 join brand in context.Brands
							 on car.BrandId equals brand.BrandId
							 join color in context.Colors on car.ColorId equals color.ColorId
							 select new CarDetailDto
							 {
								 CarId = car.Id,
								 CarName = car.CarName,
								 BrandName = brand.BrandName,
								 ColorName = color.ColorName,
								 DailyPrice = car.DailyPrice,
								 ModelYear = car.ModelYear,
							 };
				return result.ToList();
			}
		}

		public List<CarDetailDto> GetCarDetailsByBrandId(int brandId)
		{
			using (ReCarContext context = new ReCarContext())
			{
				var result = from car in context.Cars
							 join brand in context.Brands on car.BrandId equals brand.BrandId
							 join color in context.Colors on car.ColorId equals color.ColorId
							 where car.BrandId == brandId
							 select new CarDetailDto
							 {
								 CarId = car.Id,
								 BrandName = brand.BrandName,
								 CarName = car.CarName,
								 ColorName = color.ColorName,
								 DailyPrice = car.DailyPrice,
								 ModelYear = car.ModelYear,

							 };
				return result.ToList();
			}
		}

		public List<CarDetailDto> GetCarDetailsByColorId(int colorId)
		{
			using (ReCarContext context = new ReCarContext())
			{
				var result = from car in context.Cars
							 join brand in context.Brands on car.BrandId equals brand.BrandId
							 join color in context.Colors on car.ColorId equals color.ColorId
							 where car.ColorId == colorId
							 select new CarDetailDto
							 {
								 CarId = car.Id,
								 BrandName = brand.BrandName,
								 CarName = car.CarName,
								 ColorName = color.ColorName,
								 DailyPrice = car.DailyPrice,
								 ModelYear = car.ModelYear,
							 };
				return result.ToList();
			}
		}

		public List<CarDetailDto> GetCarDetailsByCarId(int carId)
		{
			using (ReCarContext context = new ReCarContext())
			{
				var result = from car in context.Cars
							 join brand in context.Brands on car.BrandId equals brand.BrandId
							 join color in context.Colors on car.ColorId equals color.ColorId
							 where car.Id == carId
							 select new CarDetailDto
							 {
								 CarId = car.Id,
								 BrandName = brand.BrandName,
								 CarName = car.CarName,
								 ColorName = color.ColorName,
								 DailyPrice = car.DailyPrice,
								 ModelYear = car.ModelYear,
							 };
				return result.ToList();
			}
		}
	}
}
