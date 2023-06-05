using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplifyLink.Services
{
    public class ShortLinkService
    {
        public ShortLinkService() {
            var credential = GoogleCredential.FromFile("path/to/serviceAccountKey.json");
            FirebaseAdmin.FirebaseApp.Create(new AppOptions()
            {
                Credential = credential,
            });
            var dynamicLink = new DynamicLink()
            {
                DomainUriPrefix = "https://example.page.link",
                Link = new Uri("https://example.com"),
                AndroidInfo = new AndroidInfo()
                {
                    AndroidPackageName = "com.example.android",
                },
                IosInfo = new IosInfo()
                {
                    IosBundleId = "com.example.ios",
                },
            };
        }

        public string GetShortLink()
        {
            
        }

        // Получение сокращенной ссылки
        var shortLink = await FirebaseAdmin.Messaging.FirebaseMessaging.DefaultInstance
            .GetShortLinkAsync(dynamicLink);
        Console.WriteLine("Сокращенная ссылка: " + shortLink.ShortLink);
        }
}
}
