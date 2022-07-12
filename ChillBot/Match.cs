using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChillBot
{
    internal class Match
    {
        public string[] Matches;
        public int MinimumMatchCount;
        public string Answer;
        public Match(string[] matches, int minimumMatchCount,string answer)
        {
            Matches = matches;
            MinimumMatchCount = minimumMatchCount;
            Answer = answer;
        }
        public bool IsMatch(string checkMatch)
        {
            int matches = 0;
            checkMatch = checkMatch.ToLower();
            foreach (string match in Matches)
            {
                string lowerMatch = match.ToLower();
                if (checkMatch.Contains(lowerMatch))
                {
                    matches++;
                }
            }
            return matches>=MinimumMatchCount;
        }
    }
}
