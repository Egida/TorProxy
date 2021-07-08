/* 
    github.com/L1ghtM4n/TorProxy
*/

using System.IO;
using System.Net;
using System.Diagnostics;

namespace TorBundle
{
    internal sealed class BundleLoader
    {
        private const string BundleLocation = "https://github.com/L1ghtM4n/TorProxy/blob/main/LIB/Tor.exe?raw=true";

        /// <summary>
        /// Download tor expert bundle
        /// </summary>
        /// <returns>Bundle location</returns>
        public static string Download()
        {
            string tempTorBundle = Path.Combine(Path.GetTempPath(), "Tor", "tor.exe");
            string tempSfxFile = Path.Combine(Path.GetTempPath(), "Tor.exe");
            if (!File.Exists(tempTorBundle))
            {
                using (WebClient webClient = new WebClient())
                {
                    webClient.DownloadFile(BundleLocation, tempSfxFile);
                    Process.Start(new ProcessStartInfo() 
                    { 
                        FileName = tempSfxFile,
                        UseShellExecute = false,
                        CreateNoWindow = true
                    }).WaitForExit();
                }
            }
            return tempTorBundle;
        }
    }
}
