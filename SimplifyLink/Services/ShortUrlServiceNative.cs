using FirebaseAdmin;
using FirebaseAdmin.Messaging;
using Google.Apis.Auth.OAuth2;
using Google.Cloud.Firestore;
using SimplifyLink.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SimplifyLink.Services
{
    public class ShortUrlServiceNative: IShortUrlService
    {
        
        public async Task GetShortUrl(Action<string> GetUrl, string longUrl)
        {
            string apiUrl = "http://tinyurl.com/api-create.php?url=" + longUrl;

            string shortUrl = "";
            using (WebClient client = new WebClient())
            {
                shortUrl = client.DownloadString(apiUrl);
            }
            GetUrl?.Invoke(shortUrl);
        }
    }
}
