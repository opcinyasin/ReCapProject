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
    }
}
