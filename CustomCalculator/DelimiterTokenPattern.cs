using System;

namespace CustomCalculator
{
    public class DelimiterTokenPattern : TokenPattern
    {
        public string Pattern { get; private set; }

        public DelimiterTokenPattern(TokenType type, string pattern) 
            :base(type)
        {
            Pattern = pattern;
        }

        public override bool IsMatch(string line)
        {
            return line.StartsWith(Pattern);
        }

        public override Token ReadToken(string line)
        {
            return new Token()
            {
                Type = Type,
                Value = Pattern,
                Length = Pattern.Length
            };
        }

    }

}
