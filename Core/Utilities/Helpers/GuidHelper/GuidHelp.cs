using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Helpers.GuidHelper
{
	public class GuidHelp
	{
		public static string CreateGuid()
		{
			return System.Guid.NewGuid().ToString();
		}

		/*
          Guid.NewGuid() bu ifade  eşsiz bir değer oluşturur. 
          Amaç: Aynı isimden dosyalar olursa çakışmasın.
         */
	}
}
