using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Com.Wiseape.Gateway.FileManager.Webservice
{
    public class Configuration
    {
        public const string GoogleCaptchaVerificationUrl = "https://www.google.com/recaptcha/api/siteverify";
        public const string GoogleCaptchaSecret = "6LcwCBkUAAAAAIdp9k-DIARl28HoWshuE0ve7EF_";
        public const string FromEmail = "lafonte.notification@gmail.com";
        public const string EmailSubject = "[pastabisa.com] Password Pastabisa untuk {{fullname}}";
        public const string EmailBody = "Pasword anda adalah : {{password}}. Gunakan password ini untuk login ke pastabisa.com";
        public static int SMTPPort = 587;
        public static bool EnableSsl = true;
        public static string EmailAccountPassword = "rotikeju98";
    }
}