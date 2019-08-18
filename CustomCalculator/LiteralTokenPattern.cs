using System;
using System.Text.RegularExpressions;

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
            bool result = Regex.IsMatch(line, @"^-?\d+");
            return result;
        }

        public override Token ReadToken(string line)
        {
            Match match = Regex.Match(line, @"^-?\d+");
            if(match != null)
            {
                string temp = match.Value;

                int value;
                bool result = int.TryParse(temp, out value);

                return new Token()
                {
                    Type = Type,
                    Value = value.ToString(),
                    Length = temp.Length
                };
            }
            else
            {
                throw new Exception("Unexpected literal");
            }


            //string temp = string.Empty;
            //foreach(char c in line.ToCharArray())
            //{
            //    if (!char.IsLetterOrDigit(c))
            //        break;

            //    temp += c;
            //}

            //int value;
            //bool result = int.TryParse(temp, out value);

            //return new Token()
            //{
            //    Type = Type,
            //    Value = value.ToString(),
            //    Length = temp.Length
            //};
        }

    }
}
