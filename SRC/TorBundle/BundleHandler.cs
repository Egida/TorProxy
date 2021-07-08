/* 
    github.com/L1ghtM4n/TorProxy
*/

using System;
using System.Threading;
using System.Diagnostics;

namespace TorBundle
{
    internal sealed class BundleHandler
    {
        public Process torprocess { get; private set; }
        public const string defaultAddress = "127.0.0.1:9050";

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="torBundle">Tor expert bundle location on disk</param>
        public BundleHandler(string torBundle)
        {
            torprocess = new Process()
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = torBundle,
                    UseShellExecute = false,
                    CreateNoWindow = true,
                    RedirectStandardOutput = true
                }
            };
            torprocess.Start();
            // Waiting for tor bundle
            while (!bundleIsReady)
            {
                Thread.Sleep(1000);
            }
        }


        /// <summary>
        /// Stop tor bundle process
        /// </summary>
        public void StopBundle()
        {
            try 
            {
                torprocess.Kill();
                torprocess.WaitForExit();
            } catch { }
        }


        /// <summary>
        /// Check if tor bundle was initialyzed
        /// </summary>
        private bool bundleIsReady { get 
            {
                while (!this.torprocess.StandardOutput.EndOfStream && !this.torprocess.HasExited)
                {
                    string standard_output = this.torprocess.StandardOutput.ReadLine();
#if DEBUG
                    Console.WriteLine(standard_output);
#endif
                    return standard_output.Contains("Bootstrapped 100");
                }
                return false;
            } 
        }

    }
}
