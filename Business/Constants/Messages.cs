using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
	public class Messages
	{
		public static string CarAdded = "ARABA EKLENDİ.";
		public static string CarDeleted = "ARABA SİLİNDİ.";
		public static string CarUpdated = "ARAÇ BİLGİLERİ GÜNCELLENDİ.";
		public static string CarNameInvalid = "ARABA İSMİ GEÇERSİZ.";
		public static string CarPriceInvalid = "GÜNLÜK FİYAT 0 OLAMAZ.";
		public static string MaintenanceTime = "SİSTEM BAKIMDA.";
		public static string CarsListed = "ARABALAR LİSTELENDİ.";
		public static string BrandAdded = "MARKA EKLENDİ.";
		public static string BrandsListed = "MARKALAR lİSTELENDİ.";
		public static string BrandDeleted = "MARKA SİLİNDİ.";
		public static string BrandUpdated = "MARKA GÜNCELLENDİ.";
		public static string ColorAdded = "RENK EKLENDİ.";
		public static string ColorsListed = "RENKLER lİSTELENDİ.";
		public static string ColorDeleted = "RENK SİLİNDİ.";
		public static string ColorUpdated = "RENK GÜNCELLENDİ.";
		public static string UserAdded = "KULLANICI EKLENDİ.";
		public static string UsersListed = "KULLANICILAR LİSTELENDİ.";
		public static string UserDeleted = "KULLANICI SİLİNDİ.";
		public static string UserUpdated = "KULLANICI GÜNCELLENDİ.";
		public static string CustomerAdded = "MÜŞTERİ EKLENDİ.";
		public static string CustomersListed = "MÜŞTERİLER lİSTELENDİ.";
		public static string CustomerDeleted = "MÜŞTERİ SİLİNDİ.";
		public static string CustomerUpdated = "MÜŞTERİ GÜNCELLENDİ.";
		public static string RentalAdded = "KİRALAMA EKLENDİ.";
		public static string RentalsListed = "KİRALAMALAR lİSTELENDİ.";
		public static string RentalDeleted = "KİRALAMA SİLİNDİ.";
		public static string RentalUpdated = "KİRALAMA GÜNCELLENDİ.";
		public static string RentalInvalidRequest = "KİRALAMA GEÇERSİZ";
		public static string CarImagesAdded = "ARAÇ FOTOSU EKLENDİ.";
		public static string CarImagesDeleted = "ARAÇ FOTOSU SİLİNDİ.";
		public static string CarImagesUpdated = "ARAÇ FOTOSU GÜNCELLENDİ.";
		public static string CarImagesListed = "ARAÇ FOTOSU LİSTELENDİ";
		public static string UserRegistered = "KULLANICI KAYIT OLDU.";
		public static string UserNotFound = "KULLANICI BULUNAMADI.";
		public static string PasswordError = "PAROLA HATALI";
		public static string SuccessfulLogin = "BAŞARILI GİRİŞ";
		public static string UserAlreadyExists = "KULLANICI MEVCUT.";
		public static string AccessTokenCreated = "TOKEN OLUŞTURULDU.";
		public static string AuthorizationDenied = "YETKİNİZ YOK.";
		
	}
}
