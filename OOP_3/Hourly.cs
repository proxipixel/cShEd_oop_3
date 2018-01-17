namespace OOP3
{
    public class Hourly : Employee
    {
        int hours;
        // hours property
        public int Hours
        {
            get { return hours; }
            set { hours = value < 0 ? -value : value; }
        }
        public Hourly() : base()
        {
        }
        public override void SalCalc()
        {
            Salary = 20.8 * 8 * Hours;
        }
    }
}
