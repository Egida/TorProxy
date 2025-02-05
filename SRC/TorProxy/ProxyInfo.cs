﻿
using System;

namespace TorProxy
{
    public class ProxyInfo
    {
        /// <summary>
        /// Proxy server address
        /// </summary>
        public readonly string Hostname;
        /// <summary>
        /// Proxy server port
        /// </summary>
        public readonly int Port;

        /// <summary>
        /// Indicates whether credentials were provided for this <see cref="ProxyInfo"/>
        /// </summary>
        public readonly bool Authenticate = false;
        internal readonly byte[] AuthenticationMessage;

        public ProxyInfo(string hostname)
        {
            string[] splitted = hostname.Split(':');
            Hostname = splitted[0];
            Port = Int32.Parse(splitted[1]);

            if (string.IsNullOrEmpty(Hostname)) throw new ArgumentNullException(nameof(Hostname));
            if (Port < 0 || Port > 65535) throw new ArgumentOutOfRangeException(nameof(Port));
        }

        public ProxyInfo(string hostname, int port)
        {
            if (string.IsNullOrEmpty(hostname)) throw new ArgumentNullException(nameof(hostname));
            if (port < 0 || port > 65535) throw new ArgumentOutOfRangeException(nameof(port));

            Hostname = hostname;
            Port = port;
        }
        public ProxyInfo(string hostname, int port, string username, string password)
            : this(hostname, port)
        {
            if (string.IsNullOrEmpty(username)) throw new ArgumentNullException(nameof(username));
            if (string.IsNullOrEmpty(password)) throw new ArgumentNullException(nameof(password));

            Authenticate = true;
            AuthenticationMessage = Socks5.BuildAuthenticationMessage(username, password);
        }
    }
}

