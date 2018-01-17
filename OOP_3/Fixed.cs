namespace OOP3
{
    public class Fixed : Employee
    {
        public Fixed() : base()
        {
        }

        public override void SalCalc()
        {
            Salary = 20.8 * 8 * 16;
        }
    }
}
