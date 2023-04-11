using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
	public static class Messages
	{
		public static string CarAdded = "Araba eklendi";
		public static string BrandAdded = "Marka eklendi";
		public static string ColorAdded = "Renk eklendi";
		public static string RentalAdded = "Rental eklendi";
		public static string UserAdded = "Kullanıcı eklendi";
		public static string CustomerAdded = "Müşteri eklendi";
		public static string CarImageAdded = "Araba resmi eklendi.";
		public static string CreditCardAdded = "Kredi kartı eklendi";
		public static string FindeksScoreAdded = "Findeks skoru eklendi";
		public static string PaymentAdded = "Ödeme alındı";

		public static string CarUpdated = "Araba güncellendi";
		public static string BrandUpdated = "Marka güncellendi";
		public static string ColorUpdated = "Renk güncellendi";
		public static string RentalUpdated = "Rental güncellendi";
		public static string UserUpdated = "Kullanıcı güncellendi";
		public static string CustomerUpdated = "Müşteri güncellendi";
		public static string CarImageUpdated = "Araba resmi güncellendi";
		public static string CreditCardUpdated = "Kredi kartı güncellendi";
		public static string FindeksScoreUpdated = "Findeks skoru güncellendi";

		public static string CarDeleted = "Araba silindi";
		public static string BrandDeleted = "Marka silindi";
		public static string ColorDeleted = "Renk silindi";
		public static string CarNotFound = "Araba bulunamadı";
		public static string RentalDeleted = "Rental silindi";
		public static string UserDeleted = "Kullanıcı silindi";
		public static string CustomerDeleted = "Müşteri silindi";
		public static string CarImageDeleted = "Araba resmi silindi";
		public static string CreditCardDeleted = "Kredi kartı silindi";
		public static string FindeksScoreDeleted = "Findeks skoru silindi";

		public static string MaintenanceTime = "Sistem Bakımda!";
		public static string DescriptionInvalid = "Açıklama en az 10 karakter içerebilir!";
		public static string FindeksScoreIsInsufficient = "Findeks skoru yetersiz";
		public static string CarHired = "Araba kiralandı";
		public static string CarNotReturned = "Araba geri teslim edilmedi";

		public static string CarsListed = "Arabalar listelendi";
		public static string BrandsListed = "Markalar listelendi";
		public static string ColorsListed = "Renkler listelendi";
		public static string CustomersListed = "Müşteriler listelendi";
		public static string UsersListed = "Müşteriler listelendi";

		public static string UserNotFound = "Kullanıcı bulunamadı";
		public static string PasswordError = "Şifre hatalı";
		public static string SuccessfulLogin = "Sisteme giriş başarılı";
		public static string UserAlreadyExists = "Bu kullanıcı zaten mevcut";
		public static string UserRegistered = "Kullanıcı başarıyla kaydedildi";
		public static string AccessTokenCreated = "Access token başarıyla oluşturuldu";

		public static string AuthorizationDenied = "Yetkiniz yok";
		public static string ProductNameAlreadyExists = "Araba ismi zaten mevcut";

		public static string ThisCarIsAlreadyRentedInSelectedDateRange = "Araba bu tarihler arasında zaten kiralanmıştır.";

		public static string RentalSuccessful = "Araç kiralandı.";

		public static string ReturnDateCannotBeEarlierThanRentDate = "Dönüş tarihi kiralama tarihinden önce olamaz!";

		public static string ReturnDateCannotBeLeftBlankAsThisCarWasAlsoRentedAtALaterDate = "Bu araç daha sonra bir tarihte kiralanmış olduğu için iade tarihi boş bırakılamaz";

		public static string RentalDateCannotBeBeforeToday = "Kiralama tarihi geçmiş bir tarih olamaz!";

		public static string ThisCarHasNotBeenReturnedYet = "Araç bu tarihler arasında galerimizde değil!";

		public static string CardNumberMustConsistOfLettersOnly = "Kart Numarası Sadece Numaralardan Oluşmalıdır!";

		public static string LastTwoDigitsOfYearMustBeEntered = "Yılın Son İki Hanesi Girilmelidir!";

		public static string CardInformationIsIncorrect = "Kart bilgileri yanlış!";

		public static string PayIsSuccessfull = "Ödeme Başarılı ile gerçekleşti!";
		public static string CustomerNotFound = "Müşteri bulunamadı!";
		public static string CustomerFindeksPointIsNotEnoughForThisCar = "Müşteri Findeks puanı bu araba için yeterli değil!";
		public static string UserPasswordUpdated = "Şifre değiştirildi";
	}
}
