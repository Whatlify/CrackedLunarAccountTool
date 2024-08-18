using System;
using System.Drawing;
using System.IO;
using Console = Colorful.Console;
using CrackedLunarAccountTool.Helpers;

namespace CrackedLunarAccountTool
{
    internal class Program
    {
        public static readonly string userFolder = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
        public static string lunarAcccountsPath = Path.Combine(userFolder, ".lunarclient/settings/game/accounts.json");
        public static readonly string ver = "v1.0";

        public static void Main(string[] args)
        {
            AccountManager.LoadJson();

            bool continueProgram = true;
            while (continueProgram)
            {
                Console.Clear();
                Console.Title = "Cracked Lunar Account Tool " + ver;
                
                int setWidth = 75;
                int setHeight = 20;
                
                int maxWidth = Console.LargestWindowWidth;
                int maxHeight = Console.LargestWindowHeight;
                
                int consoleWidth = Math.Min(setWidth, maxWidth);
                int consoleHeight = Math.Min(setHeight, maxHeight);
                
                Console.SetWindowSize(consoleWidth, consoleHeight);
                Console.SetBufferSize(consoleWidth, consoleHeight);
                
                PrintMenu();

                string choice = Console.ReadLine();
                try
                {
                    switch (int.Parse(choice))
                    {
                        case 1:
                            CreateAccountPrompt();
                            break;
                        case 2:
                            RemoveAccountsMenu();
                            break;
                        case 3:
                            AccountManager.ViewInstalledAccounts();
                            break;
                        case 4:
                            ConsoleHelpers.PrintLine("INFO", "Exiting the program.", Color.FromArgb(135, 145, 216));
                            continueProgram = false;
                            break;
                        default:
                            ConsoleHelpers.PrintLine("ERROR", "Your choice is invalid. Please pick an option (1-4).", Color.FromArgb(224, 17, 95));
                            break;
                    }
                }
                catch (Exception e)
                {
                    ConsoleHelpers.PrintLine("ERROR", "An error occurred: " + e.Message, Color.FromArgb(224, 17, 95));
                }

                if (continueProgram)
                {
                    ConsoleHelpers.PrintLine("INFO", "Press any key to return to the main menu...", Color.FromArgb(135, 145, 216));
                    Console.ReadKey();
                }
            }

            AccountManager.SaveJson();
        }

        private static void PrintMenu()
        {
            ConsoleHelpers.PrintLine("QUERY", "What would you like to do:", Color.FromArgb(135, 145, 216));
            ConsoleHelpers.PrintLine("OPTION", "1. Create Account", Color.FromArgb(135, 145, 216));
            ConsoleHelpers.PrintLine("OPTION", "2. Remove Accounts", Color.FromArgb(135, 145, 216));
            ConsoleHelpers.PrintLine("OPTION", "3. View Installed Accounts", Color.FromArgb(135, 145, 216));
            ConsoleHelpers.PrintLine("OPTION", "4. Exit the program", Color.FromArgb(135, 145, 216));
            ConsoleHelpers.Print("INPUT", "Please type your option (1-4) here: ", Color.FromArgb(135, 145, 216));
        }

        public static void RemoveAccountsMenu()
        {
            Console.Clear();
            ConsoleHelpers.PrintLine("QUERY", "Choose an option to remove accounts:", Color.FromArgb(135, 145, 216));
            ConsoleHelpers.PrintLine("OPTION", "1. Remove All Accounts", Color.FromArgb(135, 145, 216));
            ConsoleHelpers.PrintLine("OPTION", "2. Remove Cracked Accounts (accessToken is not a UUID)", Color.FromArgb(135, 145, 216));
            ConsoleHelpers.PrintLine("OPTION", "3. Remove Premium Accounts (accessToken is a UUID)", Color.FromArgb(135, 145, 216));
            ConsoleHelpers.Print("INPUT", "Please type your option (1-3) here: ", Color.FromArgb(135, 145, 216));

            string choice = Console.ReadLine();
            switch (int.Parse(choice))
            {
                case 1:
                    AccountManager.RemoveAllAccounts();
                    break;
                case 2:
                    AccountManager.RemoveCrackedAccounts();
                    break;
                case 3:
                    AccountManager.RemovePremiumAccounts();
                    break;
                default:
                    ConsoleHelpers.PrintLine("ERROR", "Invalid option. Returning to main menu.", Color.FromArgb(224, 17, 95));
                    break;
            }
            AccountManager.SaveJson();
        }

        private static void CreateAccountPrompt()
        {
            ConsoleHelpers.Print("INPUT", "Enter your desired username: ", Color.FromArgb(135, 145, 216));
            string usernameAdd = Console.ReadLine();
            if (!Validate.IsValidMinecraftUsername(usernameAdd))
            {
                ConsoleHelpers.PrintLine("WARNING", "You may experience issues joining servers because of your username being invalid.", Color.FromArgb(224, 17, 95));
            }

            while (true)
            {
                ConsoleHelpers.Print("INPUT", "Enter a valid UUID: ", Color.FromArgb(135, 145, 216));
                string customuuidAdd = Console.ReadLine();
                if (!Validate.IsValidUUID(customuuidAdd))
                {
                    ConsoleHelpers.PrintLine("WARNING", "The UUID you entered is invalid. Please ensure it follows the correct format.", Color.FromArgb(224, 17, 95));
                    ConsoleHelpers.Print("QUERY", "Would you like to try again? (y/n): ", Color.FromArgb(135, 145, 216));
                    string retry = Console.ReadLine()?.Trim().ToLower();
                    if (retry == "n")
                    {
                        ConsoleHelpers.PrintLine("INFO", "Returning to main menu.", Color.FromArgb(135, 145, 216));
                        return;
                    }
                }
                else
                {
                    AccountManager.CreateAccount(usernameAdd, customuuidAdd);
                    AccountManager.SaveJson();
                    break;
                }
            }
        }
    }
}
