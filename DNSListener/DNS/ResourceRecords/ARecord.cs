﻿using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using DNSListener.DNS;

namespace DNSListener.DNS.ResourceRecords
{
    [DnsResource(DnsResourceRecordTypes.A)]
    public class ARecord : BaseResourceRecord
    {
        public IPAddress Address
        {
            get
            {
                if (Raw.Value.Length != 4)
                    throw new InvalidOperationException();

                return new IPAddress(Raw.Value);
            }

            set
            {
                byte[] buffer = value.GetAddressBytes();
                if (buffer.Length != 4)
                    throw new ArgumentOutOfRangeException(nameof(value));

                Raw.Value = buffer;
            }
        }

        [SetsRequiredMembers]
        public ARecord(IPAddress address)
        {
            Raw = new()
            {
                Type = DnsResourceRecordTypes.A
            };

            Address = address;
        }

        private ARecord() { }
    }
}
