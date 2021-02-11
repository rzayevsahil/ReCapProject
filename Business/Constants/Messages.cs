using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;

namespace Business.Constants
{
    public static class Messages
    {
        public static string CarAdded = "Araba eklendi";
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

        public static string MaintenanceTime="Sistem bakımda";
    }
}
