namespace OOP3
{
    public abstract class Employee
    {
        static int id;
       
        // id property
        public int Id { get; set; }

        // name property
        public string Name { get; set; }

        // salary property
        public double Salary { get; set; }

        // constructor
        public Employee()
        {
            id++;
            Id = id;
        }

        // salary calculation method
        public abstract void SalCalc();
    }
}