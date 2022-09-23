using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace carburanti.Util
{
    internal class Downloader
    {
        public static string Download(string url)
        {

            var uri = new Uri(url);
            HttpClient client = new();
            var t1 = client.GetAsync(uri);
            t1.Wait();
            var response = t1.Result;
            MemoryStream stream = new MemoryStream();
            response.Content.CopyToAsync(stream).Wait();
            var r = Encoding.UTF8.GetString(stream.ToArray());
            return r;
        }
    }
}
