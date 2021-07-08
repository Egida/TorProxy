/* 
    github.com/L1ghtM4n/TorProxy
*/

using System;
using System.Net;

using TorProxy;
using TorBundle;

namespace TorHandler
{
    internal class Program
    {
        static void Main(string[] args)
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
                Print.Info("Trying make HTTP request over tor ...");
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
            Console.BackgroundColor = ConsoleColor.Black;
            // Done
            Console.ReadLine();
        }

        internal sealed class Print
        {
            public static void Info(string text)
            {
                Console.BackgroundColor = ConsoleColor.Green;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("[?] " + text);
                Console.BackgroundColor = ConsoleColor.Black;
            }
            public static void Result(string text)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine(text);
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

    }
}
