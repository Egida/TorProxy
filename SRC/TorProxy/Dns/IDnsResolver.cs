
using System.Net;

namespace TorProxy.Dns
{
    public interface IDnsResolver
    {
       IPAddress TryResolve(string hostname);
    }
}

