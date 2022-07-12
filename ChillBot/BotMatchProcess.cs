using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSharpPlus;
using DSharpPlus.Entities;
namespace ChillBot
{
    internal class BotMatchProcess
    {
        public BotMatchProcess(DiscordClient bot,MatchConfig config)
        {            
            bot.MessageCreated += async (client, messageEvent) =>
            {
                DiscordMessage message = messageEvent.Message;
                if (message.Author.IsBot)
                    return;
                List<Match> matches = config.AutoAnswers;
                foreach(Match match in matches)
                {
                    if (match.IsMatch(message.Content))
                    {
                        await message.RespondAsync(match.Answer);
                    }
                }
            };
        }
    }
}
