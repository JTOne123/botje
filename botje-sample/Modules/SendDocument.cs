﻿using Botje.Messaging.Models;
using System.IO;

namespace Botje.Sample.Modules
{
    public class SendDocument : ChatCommandModuleBase
    {
        public override void ProcessCommand(Source source, Message message, string command, string[] args)
        {
            if (args.Length == 0)
            {
                Client.SendMessageToChat(message.Chat.ID, $"Usage: /senddocument &lt;local filename on bot fs&gt;");
                return;
            }

            FileStream fs = new FileStream(args[0], FileMode.Open, FileAccess.Read);
            if (fs.Length > 50 * 1024 * 1024)
            {
                Client.SendMessageToChat(message.Chat.ID, $"Maximum supported file size is 50MB.");
                return;
            }
            Client.SendDocument(message.Chat.ID, fs, Path.GetFileName(args[0]), null, fs.Length, "This is a caption");
        }
    }
}
