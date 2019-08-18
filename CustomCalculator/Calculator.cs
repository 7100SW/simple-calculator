using System;
using System.Collections.Generic;
using static CustomCalculator.Program;

namespace CustomCalculator
{
    public class Calculator : ICalculator
    {
        private readonly ICommandParser _parser ;

        public IList<Token> Tokens { get; set; }

        public Calculator(ICommandParser parser)
        {
            _parser = parser;
        }

        public void Configure(string command)
        {
            _parser.Initialize(command);
            Tokens = _parser.Tokenize();
        }

        public int Execute()
        {
            var operands = CreateOperandStack(Tokens);
            Token first = operands.Pop();

            IMathOperator calc = new Adder();
            calc.Initialize(first);

            while (operands.Count > 0)
            {
                Token next = operands.Pop();
                calc.Execute(next);
            }

            return calc.Result;
        }

        private Stack<Token> CreateOperandStack(IList<Token> tokens)
        {
            Stack<Token> stack = new Stack<Token>();

            foreach (var t in tokens)
            {
                if (t.Type == TokenType.Literal)
                {
                    int value;
                    int.TryParse(t.Value, out value);

                    if (value < 0)
                        throw new Exception("Invalid operand literal:  Negative value not allowed");

                    if (value <= 1000)
                        stack.Push(t);
                }
            }

            return stack;
        }
    }
}
