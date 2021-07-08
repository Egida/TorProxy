# :onion: TorProxy
C# http to socks5 tor proxy

# :airplane: Usage example
<p align="center">
  <img src="IMG/example.gif">
</p>

# :computer: Code example
``` C#
// Download tor expert bundle
string torBundleLocation = BundleLoader.Download();
// Initialyze tor expert bundle
BundleHandler torBundleHandler = new BundleHandler(torBundleLocation);
// Initialyze http to socks5 proxy
HttpToSocks5Proxy proxy = new HttpToSocks5Proxy(BundleHandler.defaultAddress);
// Initialyze webclient
using (WebClient webClient = new WebClient())
{
    // Set proxy
    webClient.Proxy = proxy;
    // Make request
    string response = webClient.DownloadString("http://ip-api.com/json");
    Console.WriteLine(response);
}
// Stop http to socks5 proxy server
proxy.StopInternalServer();
// Stop bundle
torBundleHandler.StopBundle();
// Done
Console.ReadLine();
```
