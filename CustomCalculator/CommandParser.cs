using System;
using System.Collections.Generic;

namespace CustomCalculator
{

    public class CommandParser : ICommandParser
    {
        private readonly TokenMatcher _tokenMatcher;
        private string _lineBuffer;

        public CommandParser(TokenMatcher matcher)
        {
            _tokenMatcher = matcher;
        }

        public void Initialize(string line)
        {
            _lineBuffer = _tokenMatcher.ExtractCustomDelimiters(line);
        }

        public IList<Token> Tokenize()
        {
            List<Token> tokens = new List<Token>();

            while (!string.IsNullOrEmpty(_lineBuffer))
            {
                TokenPattern pattern = _tokenMatcher.DetectPattern(_lineBuffer);
                if(pattern != null)
                {
                    Token t = pattern.ReadToken(_lineBuffer);
                    string temp = Read(t.Length);

                    tokens.Add(t);
                    Console.WriteLine(temp);
                }
                else
                {
                    throw new Exception("Syntax error: Unrecognized pattern");
                }
            }

            return tokens;
        }

        private string Read(int count)
        {
            string buffer = _lineBuffer.Substring(0, count);
            if (_lineBuffer.Length - count > 0)
                _lineBuffer = _lineBuffer.Substring(count, _lineBuffer.Length - count);
            else
                _lineBuffer = string.Empty;

            return buffer;
        }
    }
}
