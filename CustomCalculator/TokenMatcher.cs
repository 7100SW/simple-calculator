using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace CustomCalculator
{
    public class TokenMatcher
    {
        public List<TokenPattern> Patterns { get; set; } = new List<TokenPattern>();

        public TokenMatcher()
        {
            Patterns.Add(new DelimiterTokenPattern(TokenType.CommaDelimiter, ","));
            Patterns.Add(new NewLineTokenPattern());
            Patterns.Add(new LiteralTokenPattern());
        }


        /// <summary>
        /// Extract custom delimiter syntax and return the remaining commands
        /// </summary>
        /// <param name="command"></param>
        /// <returns>Command Line without Custom Delimeter</returns>
        public string ExtractCustomDelimiters(string command)
        {
            string line = command;

            if (command.StartsWith("//["))
            {
                bool match = Regex.IsMatch(command, @"\/\/(\[(.+)])*?\\n");
                var collection = Regex.Matches(command, @"(?<=\[).+?(?=\])");
                foreach(Match c in collection)
                {
                    Patterns.Add(new DelimiterTokenPattern(TokenType.CustomDelimiter, c.Value));
                }

                int end = command.IndexOf("\n");
                string custom = command.Substring(2, end - 2);
                line = command.Substring(end + 1);

            }
            else if (command.StartsWith("//"))
            {
                int end = command.IndexOf("\n");
                string custom = command.Substring(2, end - 2);
                line = command.Substring(end + 1);

                Patterns.Add(new DelimiterTokenPattern(TokenType.CustomDelimiter, custom));
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

            foreach (var pattern in Patterns)
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
