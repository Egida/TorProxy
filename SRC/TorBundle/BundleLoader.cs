/* 
    github.com/L1ghtM4n/TorProxy
*/

using System.IO;
using System.Net;
using System.IO.Compression;

namespace TorBundle
{
    internal sealed class BundleLoader
    {
        private const string BundleLocation = "https://github.com/L1ghtM4n/TorProxy/blob/main/LIB/Tor.zip?raw=true";

        /// <summary>
        /// Download tor expert bundle
        /// </summary>
        /// <returns>Bundle location</returns>
        public static string Download()
        {
            string tempTorBundleDir = Path.Combine(Path.GetTempPath(), "Tor");
            string tempTorBundleExecutable = Path.Combine(tempTorBundleDir, "Tor.exe");
            if (!File.Exists(tempTorBundleExecutable))
            {
                using (WebClient webClient = new WebClient())
                {
                    byte[] data = webClient.DownloadData(BundleLocation);
                    using (MemoryStream ms = new MemoryStream(data))
                    {
                        ZipStorer torZip = ZipStorer.Open(ms, FileAccess.Read);
                        foreach (ZipStorer.ZipFileEntry zfe in torZip.ReadCentralDir())
                        {
                            torZip.ExtractFile(zfe, Path.Combine(tempTorBundleDir, zfe.FilenameInZip));
                        }
                    }
                }
            }
            return tempTorBundleExecutable;
        }
    }
}
