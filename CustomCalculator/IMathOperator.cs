namespace CustomCalculator
{
    partial class Program
    {
        public interface IMathOperator
        {
            void Initialize(Token t);
            void Execute(Token t);

            int Result { get; set; }
        }
    }
}
