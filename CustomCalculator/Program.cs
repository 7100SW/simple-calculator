using Microsoft.Extensions.DependencyInjection;
using System;

namespace CustomCalculator
{
    partial class Program
    {
        public static IServiceProvider Services { get => _services; set => _services = value; }
        private static IServiceProvider _services;

        private static void RegisterServices()
        {
            var collection = new ServiceCollection();
            collection.AddTransient<TokenMatcher>();
            collection.AddTransient<CommandParser>();
            collection.AddTransient<Calculator>();


            Services = collection.BuildServiceProvider();
        }

        /// <summary>
        /// Main Entry Point 
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            if(args.Length == 0)
            {
                Console.WriteLine("Missing command input ...");
                return;
            }

            Console.WriteLine($"Input: {args[0]}");
            RegisterServices();

            

            CommandParser parser = Services.GetService<CommandParser>();
            parser.Initialize(args[0]);
            var tokens = parser.Tokenize();

            Calculator calc = Services.GetService<Calculator>();
            int answer = calc.Execute(tokens);
            Console.WriteLine($"Answer: {answer}");

            Console.WriteLine("Please press any key to exit ...");
            Console.Read();
        }
    }
}
