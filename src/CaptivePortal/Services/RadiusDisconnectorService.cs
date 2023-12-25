﻿using Radius;
using System.Net.Sockets;
using System.Net;
using System.Text;
using CaptivePortal.Database;
using CaptivePortal.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Radius.RadiusAttributes;
using Microsoft.Extensions.Configuration;

namespace CaptivePortal.Services
{
    public class RadiusDisconnectorService
    {
        private byte[] secret;
        private byte lastSentIdentifier = 0;

        public RadiusDisconnectorService(
            IConfiguration configuration)
        {
            string? secretString = configuration.GetValue<string>("Radius:AccountingSecret")
                        ?? throw new MissingFieldException("Radius:AccountingSecret");
            secret = Encoding.ASCII.GetBytes(secretString);
        }

        public Task<bool> Disconnect(Device device, CancellationToken cancellationToken = default)
            => Disconnect(device.NasIpAddress, device.NasIdentifier, device.CallingStationId, device.AccountingSessionId, cancellationToken);

        public async Task<bool> Disconnect(
            string? nasIpAddress,
            string? nasIdentifier,
            string? callingStationId,
            string? accountingSessionId,
            CancellationToken cancellationToken = default)
        {
            if (nasIpAddress is null ||
                nasIdentifier is null ||
                callingStationId is null ||
                accountingSessionId is null)
            {
                return false;
            }

            if (!IPAddress.TryParse(nasIpAddress, out IPAddress? nasIpAddressAddress))
            {
                return false;
            }

            RadiusPacket disconnect = RadiusPacket.Create(
                RadiusCode.DISCONNECT_REQUEST,
                lastSentIdentifier++,
                null)
                .AddAttribute(new CallingStationIdAttribute(callingStationId))
                .AddAttribute(new NasIpAddressAttribute(nasIpAddressAddress))
                .AddAttribute(new NasIdentifierAttribute(nasIdentifier))
                .AddAttribute(new AccountingSessionIdAttribute(accountingSessionId));

            disconnect.ReplaceAuthenticator(disconnect.CalculateAuthenticator(secret));
            
            using UdpClient udpClient = new();
            await udpClient.SendAsync(
                disconnect.ToBytes(),
                new IPEndPoint(nasIpAddressAddress, 3799),
                cancellationToken);

            return true;
        }
    }
}
