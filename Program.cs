namespace InterfacesSPR421
{
    public interface IPhone
    {
        public int MyProperty { get; set; }

        void Phone();
        void GetSMS();

    }
    public interface IClone
    {
        
    }
    class Person : IPhone, IClone
    {
        public int MyProperty { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void GetSMS()
        {
            throw new NotImplementedException();
        }

        public void Phone()
        {
            throw new NotImplementedException();
        }
    }
    abstract class Human
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }

        public override string ToString()
        {
            return $"Name : {FirstName} Surname : {LastName} Date of birth {BirthDate.ToLongDateString()}";
        }
    }

    abstract class Employee : Human
    {
        public double Salary { get; set; }
        public string Position { get; set; }
        public override string ToString()
        {
            return base.ToString() + $"\nPosition : {Position} Salary : {Salary}";
        }
    }
    interface IWorkable
    {
        bool IsWorking { get; }
        string Work();
    }
    interface IManager
    {
        List<IWorkable> listOfWorkers { get; set; }
        void Organize();
        void MakeBudget();
        void Control();
    }
    class Director : Employee, IManager
    {
        public List<IWorkable> listOfWorkers { get; set; }

        public void Control()
        {
            Console.WriteLine("Controling some work...");
        }

        public void MakeBudget()
        {
            Console.WriteLine("Making some budget....");
        }

        public void Organize()
        {
            Console.WriteLine("Organize some work...");
        }
    }




    internal class Program
    {
        static void Main(string[] args)
        {
            
        }
    }
}
