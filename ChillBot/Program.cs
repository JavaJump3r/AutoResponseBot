using DSharpPlus;
using Newtonsoft.Json;

namespace ChillBot
{
    class ChillBot
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                args = new string[] { "-config", "config.json" };
            }
            Dictionary<string, string> arguments = ParseArguments(args);

            string configDirectory = arguments["config"];
            if(!File.Exists(configDirectory))
            {
                Console.WriteLine("Please create config.json or specify config using \"-config configfile.json\"");
                Console.WriteLine("There is config example in program folder");
                return;
            }
            string json = String.Join("", File.ReadAllLines(configDirectory));
            MatchConfig matchConfig = JsonConvert.DeserializeObject<MatchConfig>(json);

            var botConfig = new DiscordConfiguration();
            botConfig.Token = matchConfig.DiscordToken;
            botConfig.TokenType = TokenType.Bot;

            var bot = new DiscordClient(botConfig);
            new BotMatchProcess(bot, matchConfig);

            bot.ConnectAsync().Wait();
            Task.Delay(-1).Wait();
        }
        static Dictionary<string,string> ParseArguments(string[] args)
        {
            var output = new Dictionary<string, string>();
            for (int i = 0; i < args.Length;i++)
            {
                if (args[i].StartsWith("-"))
                {
                    string key = args[i].Substring(1);
                    string value = args[i+1];
                    output.Add(key, value);
                    i++;
                }
            }
            return output;
        }
    }
}