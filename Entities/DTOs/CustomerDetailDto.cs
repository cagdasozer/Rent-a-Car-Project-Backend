﻿using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
	public class CustomerDetailDto : IDto
	{
		public int Id { get; set; }

		public string CompanyName { get; set; }

		public int FindeksPoint { get; set; }
	}
}
