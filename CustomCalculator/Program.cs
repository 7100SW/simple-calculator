using Microsoft.Extensions.DependencyInjection;
using System;

namespace CustomCalculator
{
    public class Program
    {
        public static IServiceProvider Services { get => _services; set => _services = value; }
        private static IServiceProvider _services;

        private static void RegisterServices()
        {
            var service = new ServiceCollection();
            service.AddCalculator();
            Services = service.BuildServiceProvider();
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

            ICalculator calc = Services.GetService<ICalculator>();
            calc.Configure(args[0]);
            int answer = calc.Execute();
            Console.WriteLine($"Answer: {answer}");

            Console.WriteLine("Please press any key to exit ...");
            Console.Read();
        }
    }

}
