using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using Entities.Concrete;

namespace Business.Constants
{
    public static class Messages
    {
        public static string CarAdded = "Araba eklendi";
        public static string CarNotFound = "Araba bulunamadı";
        public static string CarDailyPriceInvalid = "Arabanın günlük fiyatı 0'dan büyük olmalıdır";
        public static string CarDeleted= "Araba silindi";
        public static string CarUpdated = "Araba güncellendi";
        public static string CarList = "Arabalar listesi";

        public static string ColorAdded = "Renk eklendi";
        public static string ColorDeleted = "Renk silindi";
        public static string ColorUpdated = "Renk güncellendi";
        public static string ColorList = "Renkler listesi";

        public static string BrandAdded = "Marka eklendi";
        public static string BrandNameInvalid = "Marka ismi en az 2 harfden oluşmalıdır";
        public static string BrandDeleted = "Marka silindi";
        public static string BrandUpdated = "Marka güncellendi";
        public static string BrandList = "Markalar listesi";

        public static string UserAdded = "Kullanıcı eklendi";
        public static string UserDeleted = "Kullanıcı silindi";
        public static string UserUpdated = "Kullanıcı güncellendi";
        public static string UserList = "Kullanıcılar listesi";

        public static string RentalAdded = "Kira eklendi";
        public static string RentalDeleted = "Kira silindi";
        public static string RentalUpdated = "Kira güncellendi";
        public static string RentalList = "Kira listesi";

        public static string MaintenanceTime="Sistem bakımda";

        public static string FailAddedImageLimit = "Resim limiti aşıldı";
        public static string AuthorizationDenied = "Yetkiniz yok";

        public static string UserRegistered = "Kayıt oldu";
        public static string UserNotFound = "Kullanıcı bulunamadı";
        public static string PasswordError = "Parola hatası";
        public static string SuccessfulLogin = "Başarılı giriş";
        public static string UserAlreadyExists = "Kullanıcı mevcut";

        public static string AccessTokenCreated = "Token oluşturuldu";

        public static string CarImageAdded = "Resim başarıyla eklendi";
        public static string CarImageDeleted = "Resim başarıyla silindi";
        public static string CarImageUpdated = "Resim başarıyla güncellendi";

        public static string PaymentGetAll = "Ödemeler listelendi";
        public static string RentalUndeliveredCar = "Araç henüz teslim edilmedi";
        public static string RentalListed = "Kiralamalar Lİstelendi";
        public static string RentedCarAlreadyExists = "Bu kiralık araba zaten var";

        public static string CardAdded = "Kart eklendi";

        public static string CustomerUpdated = "Müşteri güncellendi";
    }
}
