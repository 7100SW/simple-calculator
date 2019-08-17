using System.Collections.Generic;

namespace CustomCalculator
{
    public class TokenMatcher
    {
        private readonly List<TokenPattern> patterns;

        public TokenMatcher()
        {
            patterns = new List<TokenPattern>();

            patterns.Add(new DelimiterTokenPattern(TokenType.Literal, "*"));
            patterns.Add(new DelimiterTokenPattern(TokenType.AddOperator, "+"));
            patterns.Add(new DelimiterTokenPattern(TokenType.CommaDelimiter, ","));
            patterns.Add(new NewLineTokenPattern());
            patterns.Add(new LiteralTokenPattern());
        }


        public string SetupCustomDelimiters(string command)
        {
            string line = command;

            if (command.StartsWith("//["))
            {
                int end = command.IndexOf("\\n");
                string custom = command.Substring(3, end - 4);
                line = command.Substring(end + 4);

                patterns.Add(new DelimiterTokenPattern(TokenType.CommaDelimiter, custom));
            }
            else if (command.StartsWith("//"))
            {
                int end = command.IndexOf("\\n");
                string custom = command.Substring(2, end - 2);
                line = command.Substring(end + 4);

                patterns.Add(new DelimiterTokenPattern(TokenType.CommaDelimiter, custom));
            }


            return line;
        }

        /// <summary>
        /// Find the first token pattern that matches the line
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        public TokenPattern DetectPattern(string line)
        {
            TokenPattern result = null;

            foreach (var pattern in patterns)
            {
                if (pattern.IsMatch(line))
                {
                    result = pattern;
                    break;
                }
            }

            return result;
        }
    }
}
