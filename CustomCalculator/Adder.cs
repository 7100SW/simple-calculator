namespace CustomCalculator
{
    public class Adder : IMathOperator
    {
        public int Result { get; set; }

        public void Initialize(Token t)
        {
            Result = int.Parse(t.Value);
        }

        public void Execute(Token p)
        {
            int value = int.Parse(p.Value);
            Result += value;
        }
    }
}
