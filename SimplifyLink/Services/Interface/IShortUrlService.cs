using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplifyLink.Services.Interface
{
    public interface IShortUrlService
    {
        public Task GetShortUrl(Action<string> GetUrl, string longUrl);
    }
}
