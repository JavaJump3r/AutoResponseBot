using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChillBot
{
    internal class MatchConfig
    {
        public string DiscordToken;
        public List<Match> AutoAnswers = new List<Match>();
    }
}
