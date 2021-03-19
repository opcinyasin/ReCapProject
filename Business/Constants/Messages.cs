using Core.Entities.Concrete;
using System.Runtime.Serialization;

namespace Business.Constants
{
    public static class Messages
    {
        public static string CarAdded = "Aracınız eklendi.";
        public static string CarModelYearInvalid = "Model yılını kontrol ediniz.";
        public static string CarPriceInvalid = "Aracın fiyatı 0 dan büyük olmalı";
        public static string CarDescriptionInvalid = "Araç açıklaması 2 karakterden uzun olmalı.";
        public static string CarListed = "Arabalar listelendi.";
        public static string UserNotFound = "Kullanıcı bulunamadı";
        public static string PasswordError = "Şifre hatalı";
        public static string SuccessfulLogin = "Sisteme giriş başarılı";
        public static string UserAlreadyExists = "Bu kullanıcı zaten mevcut";
        public static string UserRegistered = "Kullanıcı başarıyla kaydedildi";
        public static string AccessTokenCreated = "Access token başarıyla oluşturuldu";

        public static string AuthorizationDenied = "Yetkiniz yok";
        public static string CarImageLimitExceeded= "Bir araç için en fazla beş resim oluşturulabilir";

        public static string RentalAdded = "Kiralama Bilgisi Eklendi";
        public static string RentalAddedError = "Araç teslim edilmediği için tekrar kiraya verilemez";
        public static string RentalUpdateReturnDate = "Araç Teslim Alındı";
        public static string RentalUpdateReturnDateError = "Araç Teslim Alınmış";
        public static string RentalUpdated = "Kiralama Bilgisi Güncellendi";
        public static string RentalListed = "Kiralama Bilgileri Listeleniyor...";
        public static string RentalDeleted = "Kiralama Bilgisi Silindi";
    }
}
