using System;

namespace CustomCalculator
{
    public class NewLineTokenPattern : TokenPattern
    {
        public NewLineTokenPattern()
            : base(TokenType.NewLineDelimiter)
        {
        }

        public override bool IsMatch(string line)
        {
            string firstChar = line.Substring(0, Math.Min(line.Length, 2));
            return firstChar == "\n" || firstChar == "\r"; 
        }

        public override Token ReadToken(string line)
        {
            return new Token()
            {
                Type = Type,
                Value = "\n",
                Length = 1
            };
        }
    }
}
