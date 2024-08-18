using Newtonsoft.Json.Linq;
using System;
using System.Drawing;
using System.IO;
using System.Threading;

namespace CrackedLunarAccountTool.Helpers
{
    internal class AccountManager
    {
        private static JObject json;
        public static void CreateAccount(string username, string uuid)
        {
            // the account data to be added
            JObject newAccount = new JObject
            {
                ["accessToken"] = uuid,
                ["accessTokenExpiresAt"] = "2050-07-02T10:56:30.717167800Z",
                ["eligibleForMigration"] = false,
                ["hasMultipleProfiles"] = false,
                ["legacy"] = true,
                ["persistent"] = true,
                ["userProperites"] = new JArray(),
                ["localId"] = uuid,
                ["minecraftProfile"] = new JObject
                {
                    ["id"] = uuid,
                    ["name"] = username
                },
                ["remoteId"] = uuid,
                ["type"] = "Xbox",
                ["username"] = username
            };

            // add the new account to the existing accounts
            JObject accounts = (JObject)json["accounts"];
            accounts[uuid] = newAccount;

            ConsoleHelpers.PrintLine("SUCCESS", "Your account has successfully been created.", Color.FromArgb(135, 145, 216));
        }

        public static void RemoveAllAccounts()
        {
            json["accounts"] = new JObject();
            ConsoleHelpers.PrintLine("SUCCESS", "All accounts have been successfully removed.", Color.FromArgb(135, 145, 216));
        }

        public static void RemoveCrackedAccounts()
        {
            JArray accountsToRemove = new JArray();
            JObject accounts = (JObject)json["accounts"];

            foreach (var account in accounts)
            {
                if (Validate.IsValidUUID((string)account.Value["accessToken"]))
                {
                    accountsToRemove.Add(account.Key);
                }
            }

            foreach (var key in accountsToRemove)
            {
                accounts.Remove(key.ToString());
            }

            ConsoleHelpers.PrintLine("SUCCESS", "Cracked accounts have been successfully removed.", Color.FromArgb(135, 145, 216));
        }

        public static void RemovePremiumAccounts()
        {
            JArray accountsToRemove = new JArray();
            JObject accounts = (JObject)json["accounts"];

            foreach (var account in accounts)
            {
                if (!Validate.IsValidUUID((string)account.Value["accessToken"]))
                {
                    accountsToRemove.Add(account.Key);
                }
            }

            foreach (var key in accountsToRemove)
            {
                accounts.Remove(key.ToString());
            }

            ConsoleHelpers.PrintLine("SUCCESS", "Premium accounts have been successfully removed.", Color.FromArgb(135, 145, 216));
        }

        public static void ViewInstalledAccounts()
        {
            ConsoleHelpers.PrintLine("INFO", "Installed Accounts:", Color.FromArgb(135, 145, 216));
            JObject accounts = (JObject)json["accounts"];
            foreach (var account in accounts)
            {
                ConsoleHelpers.PrintLine("ACCOUNT", account.Key + ": " + account.Value["username"], Color.FromArgb(135, 145, 216));
            }
        }

        public static void LoadJson()
        {
            try
            {
                if (File.Exists(Program.lunarAcccountsPath))
                {
                    json = JObject.Parse(File.ReadAllText(Program.lunarAcccountsPath));
                }
                else
                {
                    json = new JObject { ["accounts"] = new JObject() };
                }
            }
            catch (Exception e)
            {
                ConsoleHelpers.PrintLine("ERROR", "Failed to load accounts file: " + e.Message, Color.FromArgb(224, 17, 95));
                ConsoleHelpers.PrintLine("NOTICE", "Please check that you have Lunar Client installed." + e.Message, Color.FromArgb(224, 17, 95));
                ConsoleHelpers.PrintLine("NOTICE", "Exiting in 3 seconds..." + e.Message, Color.FromArgb(242, 140, 40));
                Thread.Sleep(3000);
                Environment.Exit(1);
            }
        }

        public static void SaveJson()
        {
            try
            {
                File.WriteAllText(Program.lunarAcccountsPath, json.ToString());
            }
            catch (Exception e)
            {
                ConsoleHelpers.PrintLine("ERROR", "Failed to save accounts file: " + e.Message, Color.FromArgb(224, 17, 95));
            }
        }
    }
}
