﻿using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;

namespace Spoofi.FreudBot.Logic.Bot
{
    public static class Config
    {
        private static readonly NameValueCollection Appsettings = ConfigurationManager.AppSettings;

        public static string BotApiKey
        {
            get { return Appsettings["BotApiKey"]; }
        }

        public static string WebHookUrl
        {
            get { return Appsettings["WebHookUrl"]; }
        }

        public static IEnumerable<int> BotAdmins
        {
            get
            {
                var stringArray = Appsettings["BotAdmins"].Split(',');
                foreach (var stringId in stringArray)
                {
                    int id;
                    if (int.TryParse(stringId, out id))
                        yield return id;
                }
            }
        }

        public static string[] BasicCommands =
        {
            "/start",
            "/help",
            "/settings",
            "/list"
        };

        public static string[] UserCommands =
        {
            "/add",
            "/wol",
            "/alias"
        };

        public static string[] AdminCommands =
        {
            "/admin",
            "/allowuser",
            "/disallowuser"
        };
    }
}