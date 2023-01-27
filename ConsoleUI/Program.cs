using Business.Concrete;
using Business.Constants;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;

namespace ConsoleUI
{
	public class Program
	{
		static void Main(string[] args)
		{
			//CarTest();
			//CarBrandTest();
			//CarTest2();
			//BrandTest();
			//ColorTest();
			//UserTest();
			//CustomerTest();
		}

		private static void CustomerTest()
		{
			CustomerManager customerManager = new CustomerManager(new EfCustomerDal());

			var result = customerManager.GetAll();

			foreach (var customer in result.Data)
			{
				Console.WriteLine(customer.UserId + "->" + customer.CompanyName);
			}
			Console.WriteLine(result.Message);
		}

		private static void UserTest()
		{
			UserManager userManager = new UserManager(new EfUserDal());

			var result = userManager.GetAll();

			foreach (var user in result.Data)
			{
				Console.WriteLine(user.UserId + " -> " + user.FirstName + " " + user.LastName);
			}
			Console.WriteLine(result.Message);
		}

		private static void ColorTest()
		{
			ColorManager colorManager = new ColorManager(new EfColorDal());
			{
				var result = colorManager.GetAll();

				foreach (var color in result.Data)
				{
					Console.WriteLine(color.ColorId + " -> " + color.ColorName);
				}
				Console.WriteLine(result.Message);
			}
		}

		private static void BrandTest()
		{
			BrandManager brandManager = new BrandManager(new EfBrandDal());

			var result = brandManager.GetAll();

			foreach (var brand in result.Data)
			{
				Console.WriteLine(brand.BrandId + " -> " + brand.BrandName);
			}
			Console.WriteLine(result.Message);
		}

		private static void CarTest2()
		{
			CarManager carManager = new CarManager(new EfCarDal());

			var result = carManager.GetCarDetails();

			if (result.Success)
			{
				foreach (var car in result.Data)
				{
					Console.WriteLine(car.CarName + " -> " + car.DailyPrice);
				}
				Console.WriteLine(result.Message);
			}
			else
			{
				Console.WriteLine(result.Message);
			}

		}

		private static void CarBrandTest()
		{
			CarManager carManager = new CarManager(new EfCarDal());

			foreach (var car in carManager.GetCarDetails().Data)
			{
				Console.WriteLine(car.CarName + " -> " + car.BrandName);
			}
		}

		private static void CarTest()
		{
			CarManager carManager = new CarManager(new EfCarDal());

			var result = carManager.GetAll();
			if (result.Success)
			{
				foreach (var car in result.Data)
				{
					Console.WriteLine(car.Description + " -> " + car.ModelYear + " MODEL");
				}
				Console.WriteLine(result.Message);
			}
			else
			{
				Console.WriteLine(result.Message);
			}

		}
	}
}