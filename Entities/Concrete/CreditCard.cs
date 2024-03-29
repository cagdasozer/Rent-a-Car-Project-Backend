﻿using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
	public class CreditCard :IEntity
	{
		public int Id { get; set; }

		public int CustomerId { get; set; }

		public string FullName { get; set; }

		public string CardNumber { get; set; }

		public int CardExpMonth { get; set; }

		public int CardExpYear { get; set; }

		public int CVV { get; set; }

		public string CardType { get; set; }

		public int CardLimit { get; set; }
	}
}
