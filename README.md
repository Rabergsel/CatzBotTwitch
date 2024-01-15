# CatzBot for Twitch
A simple chat bot for Twitch

Get Support here: https://discord.com/invite/r9jCkyq4bG

Visit the projects wiki for a lot more detailed information: https://github.com/Rabergsel/CatzBotTwitch/wiki

If you got an idea what should be added, please open an issue here on github with the title beginning with "Feature Request" or "FR:", or head over to my discord server.


## Setting it up
The following steps are required to set up the chatbot:

0. If you haven't, please install the .NET Environment from Microsoft. On a lot of computers running on Windows, it is already preinstalled.

1. Download all the files
  You can find all the releases under "releases". Download the ZIP or - if you have the knowledge to do so and you want it - compile it yourself from the source. Make sure that you extract the ZIP in a folder you will remember.
2. Make the most important settings.
   When starting the TwitchBot.exe for the first time, it will generate some folders and files. Head to the "Settings" folder and look for a settings.json file. Make all the important settings:
   
   2.1. Type your Twitch-Username into the "channel_name" section. It is hereby important to note that this is not necessarily your display name!
   
   2.2. Get a token for your channel:
        https://twitchapps.com/tmi/
        Generate a new token and paste it under "token".
   
   2.3. For more advanced features like chat filter, you have to get a API Client ID and an APIaccess token.
       Go to https://twitchtokengenerator.com and scroll down where you can choose all the scopes. Select ALL of them and press Generate Token. Then copy the Client ID and the Access Token you will then be shown after the CAPTCHA.
   
   2.4. If you let the bot access via your streaming account, make sure the "botIsBroadcaster" tag is set to true.
   
   2.5. Start the bot and see if there is a booting message in your chat.
   
   2.6. Write one message. It will the set the broadcasterID to your twitch ID. This will be acknowledged by a message.


## Punishment setup

### Update since Release 1.2.0-beta: GUI Option
Since the Release of the beta v1.2.0 you can now find a punishment editor under Moderation --> Punishment. Make sure your file is empty before using it the first time. The GUI should be self explanatory.

If you head to the punishments.txt file, you are able to configure all the punishments.
The file will have the following format:

```
BADWORD;0;3;60
BADWORD;3;5;120
BADWORD;5;20;600
BADWORD;20;99999;-1
```
What does this mean?

The first part is the reason for the punishment. Currently, there is only BADWORD (more will be added soon). Then, the "0;3;60" part means, that for the 1st, 2nd and 3rd time the user will be timeouted for 60 seconds. If the duration is set to -1, the user will be banned (as in the last line)

This is it. Have fun with the bot :D

# Troubleshooting and Q&A

### Is this secure?
Yes! All the tokens will only be saved locally, just as the whole bot runs locally. Nothing will be sent to the internet except the Twitch stuff. Just make sure to not show your tokens to the world or something, as someone requires all the power over your account if someone knows the tokens.

### It did work, but not anymore!
It may be that one of your tokens expired. This is usually about every month. Just generate a new token. This is nothing I can change, this is some Twitch internal stuff. It is only for your security, as if someone got your token, they will be kicked out as soon as the token expires.

### Can my PC run this?
As long as you have more than some MB of space and more than 100 MB of free RAM, yes!
