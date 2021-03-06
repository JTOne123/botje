﻿namespace Botje.Messaging.Models
{
    /// <summary>
    /// https://core.telegram.org/bots/api#inputmessagecontent
    /// </summary>
    public class InputMessageContent : TelegramAPIObjectBase
    {
        public string message_text { get; set; }
        public string parse_mode { get; set; }
        public bool? disable_web_page_preview { get; set; }
    }
}
