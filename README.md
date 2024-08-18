# CrackedLunarAccountTool

A tool for Lunar Client that can add cracked accounts with your own username & skin.

## How does it work?

Lunar Client doesn't check whether or not your Microsoft Account is valid or even owns a copy of Minecraft. Therefore, you can add accounts via the accounts.json located in your user folder (C:\Users\YourWindowsUsernameHere\\.lunarclient\settings\game) as an example. There's other json values such as localId which also accept any placeholder value so I've set them to whatever UUID you entered as that works fine. You can also does this entire process manually if you have some basic computer knowledge as I mentioned above.

### Update (15/8/24)
Lunar Client has recently added a check which verifies your session token periodically (around every 2 minutes or something like that) and shows a notification which looks like the below:

![Image](/media/ss1.png)
#### Debug Output Message:

![Image](/media/ss3.png)

Currently, it's just a warning and you can still use the cracked account but it can be annoying seeing the notificaion so you can disable lunar client notifications.
There's also another method to fix it which may not work for long which is switching to a branch named "master-old-auth" which doesn't have the warning appear.

### Update (18/8/24)
Lunar Client has either disabled switching branches or they removed the "master-old-auth" branch entirely so there's no fix currently.

![Image](/media/ss4.png)

## Getting Started

### Dependencies

* Windows 10-11 or any windows version compatible with .NET Framework 4.7.2
* .NET Framework 4.7.2 (it's installed by default)
* A brain

### Using It

* Open the executable file.
* Depending on the option you choose it'll either add, remove or view current accounts.
* If you want to add an account choose your username and make sure it's 3-16 characters long and doesn't contain special characters or multiplayer won't work (click [here](https://www.minecraftforum.net/forums/minecraft-java-edition/suggestions/3007464-minecraft-username-rules) for further info).
* Then choose a UUID of a player that has the skin you want by going to [NameMC](https://namemc.com/) and picking your preferred one.
* That's basically it.

## Help

If it doesn't work make sure you have Lunar Client installed and ran any version of Lunar Client or make sure to run the program as administrator.

## Version History

* 1.0
    * Initial Release

## License

This project is licensed under the MIT License - see the LICENSE.md file for details

## Acknowledgments

Inspiration, code snippets, etc.
* Games2day - Originally released his own version of this in python and allowed me to make a rewrite.
