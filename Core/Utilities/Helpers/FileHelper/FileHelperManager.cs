using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Helpers.GuidHelper;
using System.IO;

namespace Core.Utilities.Helper.FileHelper
{
	public class FileHelperManager : IFileHelper
	{
		public string Add(IFormFile file, string root)
		{
			if (file.Length > 0)
			{
				if (!Directory.Exists(root))
				{
					Directory.CreateDirectory(root);
				}
				string extension = Path.GetExtension(file.FileName);
				string guid = GuidHelper.CreateGuid();
				string filePath = guid + extension;

				using (FileStream fileStream = File.Create(root + filePath))
				{
					file.CopyTo(fileStream);
					fileStream.Flush();
					return filePath;
				}
			}
			return null;
		}

		public void Delete(string filePath)
		{
			if (File.Exists(filePath))
			{
				File.Delete(filePath);
			}
		}

		public string Update(IFormFile file, string filePath, string root)
		{
			if (File.Exists(filePath))
			{
				File.Delete(filePath);
			}
			return Add(file, root);
		}

	}
}




