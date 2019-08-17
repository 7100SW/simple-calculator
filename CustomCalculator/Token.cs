namespace CustomCalculator
{
    public class Token
    {
        public TokenType Type { get; set; }

        public string Value { get; set; }

        public int Length { get; set; }

        public bool HasError { get; set; }
    }
}
