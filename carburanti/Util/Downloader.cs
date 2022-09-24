#region

using System.Text;

#endregion

namespace carburanti.Util;

internal static class Downloader
{
    public static string Download(string url)
    {
        var uri = new Uri(url);
        HttpClient client = new();
        var t1 = client.GetAsync(uri);
        t1.Wait();
        var response = t1.Result;
        var stream = new MemoryStream();
        response.Content.CopyToAsync(stream).Wait();
        var r = Encoding.UTF8.GetString(stream.ToArray());
        return r;
    }
}