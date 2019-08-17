using System.Collections.Generic;

namespace CustomCalculator
{
    partial class Program
    {
        public class Calculator
        {
            public int Execute(IList<Token> tokens)
            {
                var operands = CreateOperandStack(tokens);
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

                foreach(var t in tokens)
                {
                    if(t.Type == TokenType.Literal)
                    {
                        int value;
                        int.TryParse(t.Value, out value);

                        if(value <= 1000)
                            stack.Push(t);
                    }
                }

                return stack;
            }
        }
    }
}
