namespace CustomCalculator
{
    public interface ICalculator
    {
        void Configure(string command);

        int Execute();
    }
}
