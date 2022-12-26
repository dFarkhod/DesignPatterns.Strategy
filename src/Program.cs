using System;
using System.Reflection;

namespace Virtualdars.DesignPatterns.Strategy
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // 1-misol:
            Context context;

            context = new Context(new ConcreteStrategyA());
            context.RunStrategy();

            context = new Context(new ConcreteStrategyB());
            context.RunStrategy();
            Console.WriteLine();


            // 2-misol:
            var staff = new Staff { Name = "Umar", Level = EngineerLevel.Lead, BaseSalary = 10000, NumberOfSubordinates = 5, NumberOfProjectsDelivered = 9, YearsOfExperience = 8 };
            var engineer = new SoftwareEngineer(staff);
            var salary = engineer.GetMonthlySalary();
            Console.WriteLine(staff.Name + ":" + salary);

            var staff2 = new Staff { Name = "Aziz", Level = EngineerLevel.Middle, BaseSalary = 6000, NumberOfSubordinates = 2, NumberOfProjectsDelivered = 4, YearsOfExperience = 3 };
            var engineer2 = new SoftwareEngineer(staff2);
            var salary2 = engineer2.GetMonthlySalary();
            Console.WriteLine(staff2.Name + ":" + salary2);

            Console.ReadLine();
        }
    }

    public interface IStrategy
    {
        public void AlgorithmStrategy();
    }


    public class Context
    {
        private IStrategy _strategy;

        public Context(IStrategy strategy)
        {
            _strategy = strategy;
        }

        public void RunStrategy()
        {
            _strategy.AlgorithmStrategy();
        }
    }


    public class ConcreteStrategyA : IStrategy
    {
        public void AlgorithmStrategy()
        {
            Console.WriteLine(GetType().Name + "." + MethodBase.GetCurrentMethod().Name);
        }
    }

    public class ConcreteStrategyB : IStrategy
    {
        public void AlgorithmStrategy()
        {
            Console.WriteLine(GetType().Name + "." + MethodBase.GetCurrentMethod().Name);
        }
    }


    public class ConcreteStrategyC : IStrategy
    {
        public void AlgorithmStrategy()
        {
            Console.WriteLine(GetType().Name + "." + MethodBase.GetCurrentMethod().Name);
        }
    }

}
