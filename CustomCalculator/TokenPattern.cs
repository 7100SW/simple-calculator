namespace CustomCalculator
{
    public abstract class TokenPattern
    {
        public TokenPattern(TokenType type)
        {
            Type = type;
        }

        public TokenType Type { get; private set; }

        public abstract bool IsMatch(string line);

        public abstract Token ReadToken(string line);
    }
}
