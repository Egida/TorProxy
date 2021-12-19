/* 
    github.com/L1ghtM4n/TorProxy
*/

using System;
using System.Net;

using TorProxy;
using TorBundle;
using TorHandler.Utils;

namespace TorHandler
{
    internal sealed class Program
    {
        public static void Main(string[] args)
        {
            // Download tor expert bundle
            Print.Info("Downloading tor expert bundle ...");
            string torBundleLocation = BundleLoader.Download();
            Print.Info("Starting tor expert bundle ...");
            BundleHandler torBundleHandler = new BundleHandler(torBundleLocation);
            // Initialyze http to socks5 proxy
            Print.Info("Starting http to socks5 proxy server ...");
            HttpToSocks5Proxy proxy = new HttpToSocks5Proxy(BundleHandler.defaultAddress);
            // Initialyze webclient
            using (WebClient webClient = new WebClient())
            {
                // Set proxy
                webClient.Proxy = proxy;
                // Make request
                Print.Info("Trying make HTTP request over Tor ...");
                string response = webClient.DownloadString("http://ip-api.com/json");
                Print.Result(response);
            }
            // Stop http to socks5 proxy server
            Print.Info("Stopping http to socks5 proxy server ...");
            proxy.StopInternalServer();
            // Stop bundle
            Print.Info("Stopping tor expert bundle ...");
            torBundleHandler.StopBundle();
            // Info
            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine("[#] Coded by L1ghtM4n with <3");
            Console.ResetColor();
            // Done
            Console.ReadLine();
        }

        

    }
}
