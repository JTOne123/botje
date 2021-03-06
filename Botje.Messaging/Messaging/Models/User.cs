﻿using RestSharp.Deserializers;

namespace Botje.Messaging.Models
{
    /// <summary>
    /// https://core.telegram.org/bots/api#user
    /// </summary>
    public class User : TelegramAPIObjectBase
    {
        //id Integer Unique identifier for this user or bot
        [DeserializeAs(Name = "id")]
        public long ID { get; set; }

        //is_bot  Boolean True, if this user is a bot
        [DeserializeAs(Name = "is_bot")]
        public bool IsBot { get; set; }

        //first_name String  User‘s or bot’s first name
        [DeserializeAs(Name = "first_name")]
        public string FirstName { get; set; }

        //last_name   String Optional.User‘s or bot’s last name
        [DeserializeAs(Name = "last_name")]
        public string LastName { get; set; }

        //username    String Optional. User‘s or bot’s username
        [DeserializeAs(Name = "username")]
        public string Username { get; set; }

        //language_code String  Optional.IETF language tag of the user's language
        [DeserializeAs(Name = "language_code")]
        public string LanguageCode { get; set; }

        /// <summary>
        /// Display name.
        /// </summary>
        /// <returns></returns>
        public string DisplayName()
        {
            string result = $"{Username}";
            if (!string.IsNullOrEmpty(FirstName) || !string.IsNullOrEmpty(LastName))
            {
                result += " (" + $"{FirstName} {LastName}".Trim() + ")";
            }
            if (IsBot)
            {
                result += $"*BOT*";
            }
            return result;
        }

        /// <summary>
        /// If a username is set, return that. Otherwise return the display name. In case of bots indicates that in the result.
        /// </summary>
        /// <returns></returns>
        public string UsernameOrName()
        {
            string result = $"{Username}";
            if (string.IsNullOrWhiteSpace(result) && (!string.IsNullOrEmpty(FirstName) || !string.IsNullOrEmpty(LastName)))
            {
                result = $"{FirstName} {LastName}".Trim();
            }
            if (IsBot)
            {
                result += $" (bot)";
            }
            return result;
        }

        /// <summary>
        /// If a username is set, return that. Otherwise return the display name.
        /// </summary>
        /// <returns></returns>
        public string ShortName()
        {
            if (!string.IsNullOrWhiteSpace(Username)) return Username;
            return $"{FirstName} {LastName}".Trim();
        }
    }
}
