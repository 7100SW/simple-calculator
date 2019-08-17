namespace CustomCalculator
{
    public class LiteralTokenPattern : TokenPattern
    {
        public LiteralTokenPattern() 
            : base(TokenType.Literal)
        {

        }

        public override bool IsMatch(string line)
        {
            return char.IsLetterOrDigit(line[0]);
        }

        public override Token ReadToken(string line)
        {
            string temp = string.Empty;
            foreach(char c in line.ToCharArray())
            {
                if (!char.IsLetterOrDigit(c))
                    break;

                temp += c;
            }

            int value;
            bool result = int.TryParse(temp, out value);

            return new Token()
            {
                Type = Type,
                Value = value.ToString(),
                Length = temp.Length
            };
        }

    }
}
