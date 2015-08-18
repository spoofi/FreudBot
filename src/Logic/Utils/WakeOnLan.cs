using System;
using System.Net.Sockets;

namespace Spoofi.FreudBot.Logic.Utils
{
    public static class WakeOnLan
    {
        public static void Up(string ip, string mac, int? port = null)
        {
            var client = new UdpClient();
            var data = new byte[102];

            for (var i = 0; i <= 5; i++)
                data[i] = 0xff;

            var macDigits = GetMacDigits(mac);
            if (macDigits.Length != 6)
                throw new ArgumentException("Incorrect MAC address supplied!");

            const int start = 6;
            for (var i = 0; i < 16; i++)
                for (var x = 0; x < 6; x++)
                    data[start + i * 6 + x] = (byte)Convert.ToInt32(macDigits[x], 16);
            
            client.Send(data, data.Length, ip, port ?? 7);
        }

        private static string[] GetMacDigits(string mac)
        {
            return mac.Split(mac.Contains("-") ? '-' : ':');
        }

        public static bool ValidateMac(string mac)
        {
            return GetMacDigits(mac).Length == 6;
        }
    }
}