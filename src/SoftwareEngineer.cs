namespace Virtualdars.DesignPatterns.Strategy
{
    public class SoftwareEngineer
    {
        private Engineer _engineer;

        public SoftwareEngineer(Staff staff)
        {
            _engineer = Engineer.Factory.Create(staff);
        }

        public decimal GetMonthlySalary()
        {
            return _engineer.GetMonthlySalary();
        }
    }

    public class Staff
    {
        public string Name;
        public EngineerLevel Level;
        public int NumberOfSubordinates;
        public int YearsOfExperience;
        public int NumberOfProjectsDelivered;
        public decimal BaseSalary;
    }

    public enum EngineerLevel
    {
        Intern,
        Junior,
        Middle,
        Senior,
        Lead
    }

    public abstract class Engineer
    {
        public Staff Staff;

        public static class Factory
        {
            public static Engineer Create(Staff staff)
            {
                switch (staff.Level)
                {
                    case EngineerLevel.Intern:
                        return new InternEngineer { Staff = staff };
                    case EngineerLevel.Junior:
                        return new JuniorEngineer { Staff = staff };
                    case EngineerLevel.Middle:
                        return new MiddleEngineer { Staff = staff };
                    case EngineerLevel.Senior:
                        return new SeniorEngineer { Staff = staff };
                    case EngineerLevel.Lead:
                        return new LeadEngineer { Staff = staff };
                    default:
                        throw new NotImplementedException("Bunday toifa mavjud emas");
                }
            }
        }
        public abstract decimal GetMonthlySalary();
    }

    public class InternEngineer : Engineer
    {
        public override decimal GetMonthlySalary()
        {
            return Staff.BaseSalary;
        }
    }

    public class JuniorEngineer : Engineer
    {
        public override decimal GetMonthlySalary()
        {
            return Staff.BaseSalary;
        }
    }

    public class MiddleEngineer : Engineer
    {
        public override decimal GetMonthlySalary()
        {
            return Staff.BaseSalary * 1.1M + (decimal)(Staff.NumberOfSubordinates * 0.03M * Staff.BaseSalary);
        }
    }

    public class SeniorEngineer : Engineer
    {
        public override decimal GetMonthlySalary()
        {
            return (Staff.BaseSalary * 1.25M) + (decimal)(Staff.YearsOfExperience * 0.01M * Staff.BaseSalary) + (decimal)(Staff.NumberOfProjectsDelivered * 0.02M * Staff.BaseSalary + (decimal)(Staff.NumberOfSubordinates * 0.03M * Staff.BaseSalary));
        }
    }

    public class LeadEngineer : Engineer
    {
        public override decimal GetMonthlySalary()
        {
            return (Staff.BaseSalary * 1.25M) + (decimal)(Staff.YearsOfExperience * 0.01M * Staff.BaseSalary) + (decimal)(Staff.NumberOfProjectsDelivered * 0.03M * Staff.BaseSalary) + (decimal)(Staff.NumberOfSubordinates * 0.05M * Staff.BaseSalary);
        }
    }
}
