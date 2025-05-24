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
    class Seller : Employee, IWorkable
    {
        

        bool isWorking  = true;
        public bool IsWorking
        {
            get
            {
                return isWorking;
            }
        }

        public string Work()
        {
            return "Selling some products";
        }
    }

    class Cashier: Employee, IWorkable
    {

        bool isWorking = true;
        public bool IsWorking
        {
            get
            {
                return isWorking;
            }
        }

        public string Work()
        {
            return "Getting pay for products";
        }
    }

    class StoreKeeper : Employee, IWorkable
    {
        private bool _IsWorking;
        public bool IsWorking => _IsWorking;

        public string Work()
        {
            return "Organize product store";
        }
    }
    class Administrator : Employee, IWorkable, IManager
    {
        public bool IsWorking { get; }

        public List<IWorkable> listOfWorkers { get ; set; }

        public void Control()
        {
            Console.WriteLine("Amd controling work"); ;
        }

        public void MakeBudget()
        {
            Console.WriteLine("Adm making budget");
        }

        public void Organize()
        {
            Console.WriteLine("Adm organizing work"); ;
        }

        public string Work()
        {
            return "Adm make some work";
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            TestWork(new Cashier());

            IManager director = new Director
            {
                LastName = "Doe",
                FirstName = "John",
                BirthDate = new DateTime(1990, 12, 31),
                Position = "Director",
                Salary = 7000
            };
            IWorkable seller = new Seller
            {
                LastName = "Bim",
                FirstName = "Jim",
                BirthDate = new DateTime(2000, 12, 31),
                Position = "Seller",
                Salary = 6000
            };

            Console.WriteLine(seller.Work());
            //TestWork(seller);
            if(seller is Employee)
                Console.WriteLine($"Seller salary : {(seller as Employee).Salary}");

            director.listOfWorkers = new List<IWorkable>
            {
                seller,
                new Cashier
                {
                    LastName = "Casha",
                    FirstName = "Cash",
                    BirthDate = new DateTime(2005, 9, 30),
                    Position = "Cashier",
                    Salary = 8000
                },
                new StoreKeeper
                {
                    LastName = "StoreKeep",
                    FirstName = "Vasyl",
                    BirthDate = new DateTime(1980, 11, 25),
                    Position = "StoreKeeper",
                    Salary = 10000
                }
            };


        }
        static void TestWork(IWorkable worker)
        {
            if(worker.IsWorking)
            {
                Console.WriteLine(worker.Work());
            }
            else
            {
                Console.WriteLine("Not working...");
            }
        }
    }
}
