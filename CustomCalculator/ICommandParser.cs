using System.Collections.Generic;

namespace CustomCalculator
{
    public interface ICommandParser
    {
        void Initialize(string line);

        IList<Token> Tokenize();
    }
}
